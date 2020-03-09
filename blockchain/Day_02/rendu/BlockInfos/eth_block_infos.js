const _Web3 = require("web3");
const Web3 = new _Web3(new _Web3.providers.HttpProvider(process.argv[2]));
const block_nb = process.argv[3];

async function main() {
  const content = await Web3.eth.getBlock(block_nb);
  console.log("Information Log for Block: " + content.hash);
  console.log(" - Block size: " + content.size);
  console.log(" - Block was mined by: " + content.miner);
  console.log(" - Block contains " + content.transactions.length + " transactions");
  var idx = 0;
  content.transactions.forEach(async (tx) => {
    const transaction_data = await Web3.eth.getTransaction(tx);
    if (transaction_data.to !== null)
      console.log("   - [" + (idx + 1) + "]: Transaction from " + transaction_data.from + " to " + transaction_data.to + " with a value of " + Web3.utils.fromWei(transaction_data.value, 'ether') + " Ether");
    else
    {
      const contract_receipt = await Web3.eth.getTransactionReceipt(tx);
      console.log("   - [" + (idx + 1) + "]: " + transaction_data.from + " created a new Smart Contract at address " + contract_receipt.contractAddress);
    }
    ++idx;
  });
}

main();
