const Wallet = require("ethereumjs-wallet");
const Tx = require("ethereumjs-tx");
const Fs = require("fs");
const _Web3 = require("web3");
const Web3 = new _Web3(new _Web3.providers.HttpProvider(process.argv[2]));
const BigNumber = require("bignumber.js");

const wallet = Wallet.fromV3(JSON.parse(Fs.readFileSync(process.argv[3])), process.argv[4]);
const to = process.argv[5];
const method = process.argv[6];
const args = process.argv.slice(7);

function computeBool(val) {
  if (val === "true") {
    return ("00000000000000000000000000000000000000000000000000000000000001");
  } else if (val === "false") {
    return ("00000000000000000000000000000000000000000000000000000000000000");
  }
}

function genZeroes(amount) {
  var ret = "";
  var idx = 0;
  while (idx < amount) {
    ret += "0";
    ++idx;
  }
  return ret;
}

function computeUint(val) {
  const number = new BigNumber(val);
  const hexed = number.toString(16);
  return (genZeroes(64 - hexed.length) + hexed);
}

function computeAddress(val) {
  return (genZeroes(64 - val.length - 2) + val.substr(2));
}

const funcs = {
  'bool': computeBool,
  'uint256': computeUint,
  'address': computeAddress
}

function computeArgs(sig, args) {
  const header = Web3.utils.sha3(sig).substr(2, 8);
  var ret = "0x" + header;
  var types = sig.substr(sig.indexOf("(") + 1, sig.length - sig.indexOf("(") - 2).split(",");
  let idx = 0;
  args.forEach((arg) => {
    ret += funcs[types[idx]](arg);
    idx += 1;
  });
  return ret;
}

async function main() {
  const latest = (await Web3.eth.getBlock("latest"));
  const gasLimit = latest.gasLimit;
  const gasPrice = (await Web3.eth.getGasPrice());
  const tx_count = await Web3.eth.getTransactionCount("0x" + wallet.getAddress().toString('hex'));
  const data = computeArgs(method, args);

  var txParams = {
    from: "0x" + wallet.getAddress().toString('hex'),
    to: to,
    nonce: Web3.utils.toHex(tx_count + 1),
    gasPrice: Web3.utils.toHex(gasPrice),
    gasLimit: Web3.utils.toHex(gasLimit),
    data: data
  }


  var tx = new Tx(txParams);
  tx.sign(wallet.getPrivateKey());
  console.log("Generating Tx from 0x" + wallet.getAddress().toString("hex") + " to " + to + " Smart Contract\n");
  const JSONed_tx = tx.toJSON();
  console.log(" - Nonce: " + JSONed_tx[0]);
  console.log(" - GasPrice: " + JSONed_tx[1]);
  console.log(" - GasLimit: " + JSONed_tx[2]);
  console.log(" - To: " + JSONed_tx[3]);
  console.log(" - Data: " + JSONed_tx[5]);
  console.log(" - r: " + JSONed_tx[6]);
  console.log(" - v: " + JSONed_tx[7]);
  console.log(" - s: " + JSONed_tx[8]);
}

main();
