const _Web3 = require("web3");
const Web3 = new _Web3(new _Web3.providers.HttpProvider(process.argv[2]));


async function main() {
  const blockNumber = await Web3.eth.getBlockNumber();
  console.log("Current Block Number: " + blockNumber);
  const gasPrice = await Web3.eth.getGasPrice();
  console.log("Current Gas Price: " + gasPrice);
}

main();
