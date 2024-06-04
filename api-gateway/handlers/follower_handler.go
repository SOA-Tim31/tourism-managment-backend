package handlers

import (
	"context"
	"encoding/json"
	"example/gateway/proto/greeter"
	"fmt"
	"net/http"
)

func CreateUser(w http.ResponseWriter, r *http.Request, pathParams map[string]string) {
	fmt.Println("Http Request hit")
	var registrationRequest greeter.RegistrationRequest

	err := json.NewDecoder(r.Body).Decode(&registrationRequest)
	if err != nil {
		http.Error(w, err.Error(), http.StatusBadRequest)
		return
	}

	res, err := stakeHoldersRPCClient.RegistrationRpc(context.TODO(), &registrationRequest)
	if err != nil {
		http.Error(w, err.Error(), http.StatusBadRequest)
		return
	}

	followersRes, err := followersRPCClient.CreateUser(context.TODO(), &greeter.UserRequest{Id: res.Id, Username: registrationRequest.Username})
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	if followersRes.MessageConfirmation == "SUCCESS" {
		w.WriteHeader(http.StatusOK)
		return
	} else {
		w.WriteHeader(http.StatusInternalServerError)
		return
	}
}