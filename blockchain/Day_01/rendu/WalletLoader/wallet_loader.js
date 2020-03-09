const Fs = require("fs");
const Wallet = require("ethereumjs-wallet");
const HDKEY = require("ethereumjs-wallet/hdkey");

const load_file = process.argv[2];
const load_pass = process.argv[3];
try 
{
  const load_wallet = Wallet.fromV3(JSON.parse(Fs.readFileSync(load_file)), load_pass);
  console.log("Secret Private Key: 0x" + load_wallet._privKey.toString('hex'));
}
catch (e)
{
  console.log("Invalid File or Password");
}
