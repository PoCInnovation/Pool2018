const _Web3 = require("web3");
const Web3 = new _Web3(new _Web3.providers.HttpProvider(process.argv[2]));
const address = process.argv[3];


async function main() {
  console.log("Information Log for address: " + address);
  const balance = Web3.utils.fromWei(await Web3.eth.getBalance(address), 'ether');
  console.log(" - Account Balance: " + balance + " ETH");
  const tx_count = await Web3.eth.getTransactionCount(address);
  console.log(" - Transaction Count: " + tx_count);
  const code = await Web3.eth.getCode(address);
  if (code === "0x")
    console.log(" - Not a Smart Contract");
  else
    console.log(" - Is a Smart Contract");


}

main();
