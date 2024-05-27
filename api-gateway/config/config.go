package config

import "os"

type Config struct {
	Address                   string
	GreeterServiceAddress     string
	StakeholderServiceAddress string
}

func GetConfig() Config {
	return Config{
		GreeterServiceAddress:     os.Getenv("GREETER_SERVICE_ADDRESS"),
		Address:                   os.Getenv("GATEWAY_ADDRESS"),
		StakeholderServiceAddress: os.Getenv("STAKEHOLDERS_SERVICE_ADDRESS"),
	}
}
