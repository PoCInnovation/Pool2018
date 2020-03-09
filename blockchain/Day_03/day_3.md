<div><img src="images/POC.png" width="20%"/></div>
<div style="text-align:center" ><img src ="images/ETH.png" width="30%" /></div>

# Blockchain Pool Day 3

## Rendu

 Nom du repo: `bc_pool_3`.
 
 Droits : `rotaru_i` et `guyard_r` en `r`.
 
 Ne pushez pas vos `node_modules`.
 
 `npm install` sera lancé avant l'exécution de votre exercice, veillez à avoir un `package.json` correct.
 
 Vous avez le droit uniquement aux modules s'installant via npm, et aux fonctions JS basiques.

## Introduction

Maintenant que vous savez comment communiquer avec la Blockchain d'Ethereum et comment générer des transaction, il est temps pour vous de commencer à écrire vos premiers Smart Contracts.

Pour cela, installez [Solc](http://solidity.readthedocs.io/en/develop/installing-solidity.html), le compilateur [Solidity](http://solidity.readthedocs.io/en/develop/solidity-in-depth.html) officiel.

Solidity est un langage de programmation très simple à prendre en main. En effet, son usage étant très limité pour des raisons de sécurité, les Smart Contracts sont souvent très simples à écrire et à comprendre.

Passez quelques minutes à lire la doc du langage avant de commencer.

Nous utiliseront Solidity 0.4.18 (`pragma solidity^0.4.18;`)

`solc Contract.sol` compilera votre Smart Contract, et vous indiquera vos erreurs / warnings.

Un Smart Contract valide est un Smart Contract sans warnings !

Pour pouvoir déployer et tester vos Smart Contracts, vous allez devoir mettre en place un noeud Ethereum local.

Commencez par installer [`geth`](https://github.com/ethereum/go-ethereum/wiki/Installing-Geth), et suivez ce [tutoriel](https://hackernoon.com/heres-how-i-built-a-private-blockchain-network-and-you-can-too-62ca7db556c0) pour lancer votre noeud.

Petit conseil, au lieu de miner vos Ethers sur votre Blockchain locale, cherchez plutôt comment pré-allouer des fonds à une addresse dans le Genesis file.

Pour que vos transactions puissent être enregistrées sur votre Blockchain locale, vous devrez miner. Pour éviter de miner dans le vent, regardez ce [topic](https://ethereum.stackexchange.com/questions/3151/how-to-make-miner-to-mine-only-when-there-are-pending-transactions) et choisissez la solution du script qui mine uniquement lorsqu'une nouvelle transaction surgit.

Créez un dossier `Config` qui contiendra tous les fichiers nécéssaires au lancement de geth en local et les scripts `init.sh` et `run.sh`.

#### Exercice 1: User Registry (5 pt)

Écrivez un Smart Contract `UserRegistry.sol` capable de stocker une liste d'utilisateurs, ayant les méthodes suivantes:

```
function isOwner(address) constant returns (bool)
// Return true si l'addresse correspond au propriétaire du Smart Contract

function addUser(address)
// Ajoute l'utilisateur si la personne appelant la méthode est le propriétaire

function removeUser(address)
// Supprime l'utilisateur si la personne appelant la méthode est le propriétaire

function isUser(address) constant returns (bool)
// Return true si l'utilisateur est inscrit

function kill()
// Détruit le Smart Contract, appelable uniquement par le propriétaire
```

Regardez ce qu'est une méthode constante, et quelles variables sont disponibles par défaut dans un Smart Contract.

Lorsque votre Smart Contract vous semble correct, passez à l'exercice suivant pour enfin le déployer et l'utiliser.

#### Exercice 2: Smart Contract Deployer (7.5 pt)

Écrivez un script js `deploy.js` qui prend en paramètre un ou plusieurs fichiers `.sol`, les compile et les déploie sur une Blockchain.

Votre script doit pouvoir fonctionner avec tout Smart Contract ne nécessitant pas d'arguments à la construction.

Vous devrez au préalable avoir une instance de `geth` en local avec votre propre Blockchain, et un wallet avec des fonds disponibles. Le Wallet doit être unlock dans votre instance de `geth`.

```
$ node deploy.js http://127.0.0.1:8545 ../UserRegistry/UserRegistry.sol
Deployed Contract Instance of UserRegistry at address 0xd9A97dd3EC3385A8773780d301fA8CABeBcE7deC
```

Fournissez ensuite un script js `test.js` qui prend en paramètre un autre script js de tests que vous écrirez.

```
$ node test.js http://127.0.0.1:8545 ./tests/UserRegistry_test.js ../UserRegistry/UserRegistry.sol
Deployed Contract Instance of UserRegistry at address 0xb2a2ff047a43469f45e6d7274ebE7D050fb623bd

Running tests ...

Testing Ownership ...
Testing Ownership OK.
Testing If Owner is User ...
Testing If Owner is User OK.
Testing If Random User is User ...
Testing If Random User is User OK.
Adding Random User ...
Testing If Random User is User ...
Testing If Random User is User OK.
Removing Random User ...
Testing If Random User is User ...
Testing If Random User is User OK.
```

Dans un dossier `tests`, créez un fichier pour chaque Smart Contract que vous avez écrit dans la journée sous la forme `NOM_DU_SMART_CONTRACT_test.js`.

Voici à quoi devra ressembler votre fichier de test

```
module.exports = async function(Web3, Instance, Name) {
	// Ecrivez vos tests ici
}
```

`Web3` est une instance web3 connectée à votre relais.
`Instance` est l'instance de votre Smart Contract déployé.
`Name` est le nom de votre Smart Contract.

Votre script test devra donc charger ce fichier et lui fournir les paramètres requis pour fonctionner, puis devra éxécuter la fonction exportée.

Vous devez `catch` les erreurs dans les scripts de test dans votre `test.js`, et vous devez `throw` dans vos fichiers de tests en cas d'erreur.

#### Exercice 3: Basic Multi Sig Wallet (7.5pt)

Un MultiSig Wallet est un Smart Contract conçu pour contenir des fonds au nom de plusieurs personnes. Lorsqu'une transaction est demandée, le Smart Contract s'assure que tous les membres du groupe ont accepté la transaction.

Ecrivez dans un dossier `BasicMultiSigWallet`, un Smart Contract `Democracy.sol`  implémentant les méthodes suivantes.


```
function addMemberRequest(address)
// Crée une demande d'ajout

function votePendingUser(address, bool)
// Vote sur une demande d'ajout

function removeMemberRequest(address)
// Crée une demande de suppression

function votePendingRemoveUser(address, bool)
// Vote sur une demande de suppression

function isUser(address) constant returns (bool)
// Return true si l'utilisateur est dans la liste
```

Lorsque vous pensez avoir fini votre `Democracy.sol`, commencez votre `BasicMultiSigWallet.sol`, qui héritera de `Democracy.sol` et de sa gestion d'utilisateur et implémentera les méthodes suivantes.

```
function send(address, uint256)
// Crée une demande d'envoi de fonds
// Est effectuée lorsque tout le monde vote oui ou annulée lorsque tout le monde vote non, utilisable par les membres enregistrés

function validate(uint256)
// Vote oui pour la demande d'envoi avec l'ID envoyé en paramétre, utilisable par les membres enregistrés

function unvalidate(uint256)
// Vote non du coup, utilisable par les membres enregistrés

function cancel(uint256)
// Appelable uniquement par la personne ayant créé la demande d'envoi, l'annule immédiatement
```

Libre à vous d'ajouter des getters custom (et **constants** !) pour faire des tests plus simples. N'oubliez pas d'ajouter votre script de test au dossier `tests` de l'exercice 2 !




