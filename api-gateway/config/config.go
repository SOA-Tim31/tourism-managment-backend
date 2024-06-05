package config

import "os"

type Config struct {
	Address                   string
	GreeterServiceAddress     string
	StakeholderServiceAddress string
	FollowersServiceAddress string
	ToursServiceAddress string
}

func GetConfig() Config {
	return Config{
		GreeterServiceAddress:     os.Getenv("GREETER_SERVICE_ADDRESS"),
		Address:                   os.Getenv("GATEWAY_ADDRESS"),
		StakeholderServiceAddress: os.Getenv("STAKEHOLDERS_SERVICE_ADDRESS"),
		FollowersServiceAddress: os.Getenv("FOLLOWERS_SERVICE_ADDRESS"),
		ToursServiceAddress: os.Getenv("TOURS_SERVICE_ADDRESS"),
	}
	// return Config{
	// 	GreeterServiceAddress:     os.Getenv("GREETER_SERVICE_ADDRESS"),
	// 	Address:                   "localhost:8001",
	// 	StakeholderServiceAddress: "localhost:8082",
	// 	FollowersServiceAddress: "localhost:8089",
	// 	ToursServiceAddress: "localhost:8000",
	// }
}
