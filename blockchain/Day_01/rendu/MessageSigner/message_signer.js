const Fs = require("fs");
const Wallet = require("ethereumjs-wallet");
const HDKEY = require("ethereumjs-wallet/hdkey");
const BIP39 = require("bip39");
const Util = require("ethereumjs-util");
const N_DIV_2 = new Util.BN('7fffffffffffffffffffffffffffffff5d576e7357a4501ddfe92f46681b20a0', 16);


const arg = process.argv[2];

function signMessage(_message, _wallet) {
  const hash = Util.sha3(_message);
  const ecsign = Util.ecsign(hash, _wallet.getPrivateKey());
  signature = Buffer.concat([ ecsign.r, ecsign.s, Util.toBuffer(ecsign.v - 27) ]);
  return ({hash: hash.toString('hex'), signature: signature.toString('hex')});
}

function _getSigMaker (hash, r, s, v) {
    var pubKey = Util.ecrecover(
        Util.toBuffer(hash),
        v,
        Util.toBuffer(r),
        Util.toBuffer(s)
    );

    if (new Util.BN(s).cmp(N_DIV_2) === 1) {
        console.warn('Invalid signature on Homestead and later versions.');
        return null
    }

    return (Util.publicToAddress(pubKey));
}

// verifySignature : Takes Message and Hash from signMessage, and verify against supposed raw
// message and signer
function verifySignature(_messageHash, _signer, _signature) {

    var v = _signature[64];

    if (v < 27) {
        v += 27;
    }

    var signer = _getSigMaker(_messageHash, _signature.slice(0, 32), _signature.slice(32, 64), v);
    _signer = _signer.slice(0, 2).toString() == "0x" ? _signer.slice(2) : _signer;

    if (signer.compare(_signer))
        return (false);
    return (true);
}

const config = JSON.parse(Fs.readFileSync("./config.json"));
const password = config.password;
const wallet = Wallet.fromV3(JSON.parse(Fs.readFileSync(config.wallet)), password);

switch (arg) {

  case "sign":
    // Load Wallet
    const message = Fs.readFileSync(process.argv[3]);
    const dest = process.argv[4];
    try
    {
      const signature = signMessage(message, wallet);
      Fs.writeFileSync(dest, JSON.stringify(signature), "utf8");
      console.log("Signature OK");
    }
    catch (e)
    {
      console.log("Signature Failed");
    }

    break ;

  case "verify":
    var signature = JSON.parse(Fs.readFileSync(process.argv[3]));
    signature.hash = new Buffer(signature.hash, "hex");
    signature.signature = new Buffer(signature.signature, "hex");
    if (verifySignature(signature.hash, wallet.getAddress(), signature.signature))
      console.log("Signature matches");
    else
      console.log("Signature not matching");
    break ;
  default:
    console.log("Unknown Command");
}
