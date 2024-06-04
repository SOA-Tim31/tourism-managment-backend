package handlers

import (
	"example/gateway/proto/greeter"
	"sync"
)

var (
	stakeHoldersRPCClient greeter.StakeholderServiceClient
	followersRPCClient greeter.FollowerServiceClient
)

var once sync.Once

func InjectRPCClients(stHolderRPCClient greeter.StakeholderServiceClient, fllwrsRpcClient greeter.FollowerServiceClient) {
	once.Do(func() {
		stakeHoldersRPCClient = stHolderRPCClient
		followersRPCClient = fllwrsRpcClient
	})
}