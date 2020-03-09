const Fs = require("fs");
const Wallet = require("ethereumjs-wallet");
const HDKEY = require("ethereumjs-wallet/hdkey");
const BIP39 = require("bip39");

const arg = process.argv[2];

switch (arg) {
  case "new_wallet":
    const mnemo_file = process.argv[3];
    const new_file = process.argv[4];
    const new_pass = process.argv[5];
    const mnemonic = BIP39.generateMnemonic();
    const new_wallet = HDKEY.fromMasterSeed(BIP39.mnemonicToSeedHex(mnemonic)).getWallet();
    console.log("Address: 0x" + new_wallet.getAddress().toString('hex'));
    const new_v3_wallet = JSON.stringify(new_wallet.toV3(new_pass));
    Fs.writeFileSync(mnemo_file, mnemonic, 'utf8');
    Fs.writeFileSync(new_file, new_v3_wallet, 'utf8');
    break ;
  case "restore_wallet":
    const load_mnemo = process.argv[3];
    const load_file = process.argv[4];
    const load_pass = process.argv[5];
    try 
    {
      const restored_mnemo = Fs.readFileSync(load_mnemo).toString();
      const load_wallet = HDKEY.fromMasterSeed(BIP39.mnemonicToSeedHex(restored_mnemo)).getWallet();
      console.log("Recovered Address: 0x" + load_wallet.getAddress().toString('hex'));
      Fs.writeFileSync(load_file, JSON.stringify(load_wallet.toV3(load_pass)));
    }
    catch (e)
    {
      console.log("Invalid File or Password");
    }
    break ;
  default:
    console.log("Unknown Command");
}
