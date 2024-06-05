package main

import (
	"context"
	"example/gateway/config"
	"example/gateway/handlers"
	"example/gateway/proto/greeter"
	"fmt"
	"log"
	"net/http"
	"os"
	"os/signal"
	"syscall"

	"github.com/grpc-ecosystem/grpc-gateway/v2/runtime"
	"google.golang.org/grpc"
	"google.golang.org/grpc/credentials/insecure"
)

func allowCORS(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		w.Header().Set("Access-Control-Allow-Origin", "*")
		w.Header().Set("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS")
		w.Header().Set("Access-Control-Allow-Headers", "Content-Type, Authorization")

		// Handle preflight request
		if r.Method == http.MethodOptions {
			w.WriteHeader(http.StatusOK)
			return
		}

		next.ServeHTTP(w, r)
	})
}

func main() {

	cfg := config.GetConfig()

	connStakeholders, err := grpc.DialContext(
		context.Background(),
		cfg.StakeholderServiceAddress,
		grpc.WithBlock(),
		grpc.WithTransportCredentials(insecure.NewCredentials()),
	)

	if err != nil {
		log.Fatalln("Failed to dial server:", err)
	}

	connTours, err := grpc.DialContext(
		context.Background(),
		cfg.ToursServiceAddress,
		grpc.WithBlock(),
		grpc.WithTransportCredentials(insecure.NewCredentials()),
	)

	if err != nil {
		log.Fatalln("Failed to dial server:", err)
	}

	gwmux := runtime.NewServeMux()

	clientTour := greeter.NewTourServiceClient(connTours)
	err = greeter.RegisterTourServiceHandlerClient(
		context.Background(),
		gwmux,
		clientTour,
	)
	if err != nil {
		log.Fatalln("Failed to register gateway:", err)
	}

	clientStakeholder := greeter.NewAuthServiceClient(connStakeholders)
	err = greeter.RegisterAuthServiceHandlerClient(
		context.Background(),
		gwmux,
		clientStakeholder,
	)
	if err != nil {
		log.Fatalln("Failed to register gateway:", err)
	}

	clientUser := greeter.NewStakeholderServiceClient(connStakeholders)
	err = greeter.RegisterStakeholderServiceHandlerClient(
		context.Background(),
		gwmux,
		clientUser,
	)
	if err != nil {
		log.Fatalln("Failed to register gateway:", err)
	}

	connFollowers, err := grpc.DialContext(
		context.Background(),
		cfg.FollowersServiceAddress,
		grpc.WithBlock(),
		grpc.WithTransportCredentials(insecure.NewCredentials()),
	)
	clientFollowers := greeter.NewFollowerServiceClient(connFollowers)
	err = greeter.RegisterFollowerServiceHandlerClient(
		context.Background(), gwmux, clientFollowers,
	)
	if err != nil {
		log.Fatalln("Failed to register gateway:", err)
	}

	handlers.InjectRPCClients(clientUser, clientFollowers)
	// Register custom rest handlers
	fmt.Println("Registering custom rest paths")
	gwmux.HandlePath("POST", "/follower/create", handlers.CreateUser)

	fmt.Println("gas")
	gwServer := &http.Server{	
		Addr:    cfg.Address,
		Handler: gwmux,
	}

	go func() {
		if err := gwServer.ListenAndServe(); err != nil {
			log.Fatal("server error: ", err)
		}
	}()

	stopCh := make(chan os.Signal)
	signal.Notify(stopCh, syscall.SIGTERM)

	<-stopCh
	if err := gwServer.Close(); err != nil {
		log.Fatalln("error while stopping server: ", err)
	}
}
