const Wallet = require("ethereumjs-wallet");
const Tx = require("ethereumjs-tx");
const Fs = require("fs");
const _Web3 = require("web3");
const Web3 = new _Web3(new _Web3.providers.HttpProvider(process.argv[2]));

const wallet = Wallet.fromV3(JSON.parse(Fs.readFileSync(process.argv[3])), process.argv[4]);
const to = process.argv[5];
const value = process.argv[6];

async function main() {
  const latest = (await Web3.eth.getBlock("latest"));
  const gasLimit = latest.gasLimit;
  const gasPrice = (await Web3.eth.getGasPrice());
  const tx_count = await Web3.eth.getTransactionCount("0x" + wallet.getAddress().toString('hex'));

  var txParams = {
    from: "0x" + wallet.getAddress().toString('hex'),
    to: to,
    value: Web3.utils.toHex(value),
    nonce: Web3.utils.toHex(tx_count + 1),
    gasPrice: Web3.utils.toHex(gasPrice),
    gasLimit: Web3.utils.toHex(gasLimit)
  }


  var tx = new Tx(txParams);
  tx.sign(wallet.getPrivateKey());
  console.log("Generating Tx from 0x" + wallet.getAddress().toString("hex") + " to " + to + " with value " + Web3.utils.fromWei(value, 'ether') + " Ether\n");
  const JSONed_tx = tx.toJSON();
  console.log(" - Nonce: " + JSONed_tx[0]);
  console.log(" - GasPrice: " + JSONed_tx[1]);
  console.log(" - GasLimit: " + JSONed_tx[2]);
  console.log(" - To: " + JSONed_tx[3]);
  console.log(" - Value: " + JSONed_tx[4]);
  console.log(" - r: " + JSONed_tx[6]);
  console.log(" - v: " + JSONed_tx[7]);
  console.log(" - s: " + JSONed_tx[8]);
}

main();
