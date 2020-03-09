#! /bin/bash

geth --datadir ./datadir --keystore ./keystore --unlock 0 --password ./password --rpc --rpcapi admin,eth,web3 --preload ./mining.js console
