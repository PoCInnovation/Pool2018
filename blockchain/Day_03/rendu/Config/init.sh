#! /bin/bash

geth --datadir ./datadir --keystore ./keystore --unlock 0 --password ./password init ./genesis.json
