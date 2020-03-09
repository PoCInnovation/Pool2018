const Fs = require("fs");
const Wallet = require("ethereumjs-wallet");
const HDKEY = require("ethereumjs-wallet/hdkey");

const new_file = process.argv[2];
const new_pass = process.argv[3];
const new_wallet = Wallet.generate();
console.log("Address: 0x" + new_wallet.getAddress().toString('hex'));
const new_v3_wallet = JSON.stringify(new_wallet.toV3(new_pass));
Fs.writeFileSync(new_file, new_v3_wallet, 'utf8');
