module.exports = async function(Web3, Instance, Name) {
  const Chai = require("chai");
  const Expect = Chai.expect;
  const coinbase = await Web3.eth.getCoinbase();
  const user = "0x00156cd84776616BCc0bc5F78867cC2b67f8a285";

  console.log("Testing Ownership ...");
  Expect(await Instance.methods.isOwner(coinbase).call({from: coinbase})).to.equal(true);
  console.log("Testing Ownership OK.");

  console.log("Testing If Owner is User ...");
  Expect(await Instance.methods.isUser(coinbase).call({from: coinbase})).to.equal(true);
  console.log("Testing If Owner is User OK.");

  console.log("Testing If Random User is User ...");
  Expect(await Instance.methods.isUser(user).call({from: coinbase})).to.equal(false);
  console.log("Testing If Random User is User OK.");

  console.log("Adding Random User ...");
  await Instance.methods.addUser(user).send({from: coinbase});

  console.log("Testing If Random User is User ...");
  Expect(await Instance.methods.isUser(user).call({from: coinbase})).to.equal(true);
  console.log("Testing If Random User is User OK.");

  console.log("Removing Random User ...");
  await Instance.methods.removeUser(user).send({from: coinbase});

  console.log("Testing If Random User is User ...");
  Expect(await Instance.methods.isUser(user).call({from: coinbase})).to.equal(false);
  console.log("Testing If Random User is User OK.");
}


