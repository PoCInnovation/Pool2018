const _Web3 = require("web3");
const Web3 = new _Web3(new _Web3.providers.HttpProvider(process.argv[2]));
const Solc = require("solc");
const Fs = require("fs");
const Tx = require("ethereumjs-tx");

async function main() {

  const files = process.argv.slice(3);

  var files_data = {};
  files.forEach((file) => {
    files_data[file] = Fs.readFileSync(file).toString();
  });

  const compiled = Solc.compile({sources: files_data}, 1);

  Object.keys(compiled.contracts).forEach(async (key) => {
    if (key.length >= files[0].length && files[0] === key.substr(0, files[0].length)) {

      const bytecode = compiled.contracts[key].bytecode;
      const abi = JSON.parse(compiled.contracts[key].interface);
      const Contract = new Web3.eth.Contract(abi);
      const gas_limit = (await Web3.eth.getBlock("latest")).gasLimit;
      const coinbase = await Web3.eth.getCoinbase();
      const ContractInstance = await Contract.deploy({
	data: "0x" + bytecode,
      }).send({
	from: coinbase,
	gas: gas_limit
      });
      ContractInstance.setProvider(new _Web3.providers.HttpProvider(process.argv[2]));
      console.log("Deployed Contract Instance of " + key.substr(key.indexOf(':') + 1) + " at address " + ContractInstance.options.address);
    }
  });

}

main();
