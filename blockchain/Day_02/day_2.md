<div><img src="images/POC.png" width="20%"/></div>
<div style="text-align:center" ><img src ="images/ETH.png" width="30%" /></div>

# Blockchain Pool Day 2

## Rendu

 Nom du repo: `bc_pool_2`.
 
 Droits : `rotaru_i` et `guyard_r` en `r`.
 
 Ne pushez pas vos `node_modules`.
 
 `npm install` sera lancé avant l'exécution de votre exercice, veillez à avoir un `package.json` correct.
 
 Vous avez le droit uniquement aux modules s'installant via npm, et aux fonctions JS basiques.

## Introduction

Maintenant que vous savez comment les Wallets et l'identité sont gérés, il est maintenant temps pour vous d'apprendre à intéragire avec la Blockchain Ethereum.

#### Ethereum Nodes

La Blockchain est gérée par des noeuds qui contiennent l'intégralité des informations depuis sa création. Au fur et à mesure des Blocks, l'état de la Blockchain est mis à jour dans chacun des noeuds. Lorsque l'on lance un noeud, on va donc se connecter à d'autres noeuds pour récupérer les précédents Blocks. Actuellement, il n'existe pas encore de version stable pour ce qu'on appele des noeuds légers, c'est à dire des noeuds qui ne contiennent que les headers des Blocks et qui récupèrent dynamiquement les informations chez leurs peers. Ce type de noeuds serait intégrable facilement en client side. Il faut donc avoir un noeud pour pouvoir communiquer avec la Blockchain.

### INFURA

INFURA est un projet permettant à quiconque aillant un compte INFURA d'accéder à des noeuds publics Ethereum. Nous allons donc utiliser INFURA pour pouvoir nous connecter à la Blockchain directement depuis le client side. Allez sur le site d'INFURA et créez vous un compte, vous receverez votre token d'accès dans votre boîte mail par la suite.

#### Exercice 1: Ethereum Relay (1.5 pt)

###### Gas

La notion de Gas est très importante dans la Blockchain d'Ethereum. Toute transaction va payer une taxe. Cette taxe est la multiplication de la quantité de Gas nécéssaire à l'éxécution de la transaction et du prix du Gas que l'on souhaite donner.
Les mineurs choisissent les transactions à vérifier et à intégrer en fonction du prix du Gas. Plus il est élevé, plus la transaction sera vite éxécutée.
La quantité de Gas nécéssaire dépend de l'action que la transaction va effectuer. En effet, on parle de transaction même lorsque l'on va intéragir avec un Smart Contract. La valeur du Gas est donnée en Wei, une sous-unité de l'Ether.

###### Blocks

Les Blocks possèdent une chronologie, et donc un nombre. Ce nombre s'incrémente à chaque nouveau Block. On a donc un nombre de Blocks en constante évolution.

Dans cet exercice, vous devez écrire un script js `eth_infos.js` dans un dossier `EthereumRelay` ayant le comportement suivant.

```
$ node eth_infos.js https://rinkeby.infura.io/VOTRE_TOKEN
Current Block Number: 1690899
Current Gas Price: 11100000000
```

Vous devez donc trouver un moyen pour communiquer avec la Blockchain et demander des informations comme le nombre de blocks courrant ou le prix de gas moyen actuel.



#### Exercice 2: Account Infos (3.5 pt)

###### Balance

Chaque addresse dans la Blockchain possède une Balance. Il s'agit de la quantité d'Ethers que l'addresse possède. Ici pas de magie, tout le monde a les mêmes informations sur chaque compte, et pour pouvoir bouger et utiliser les Ethers associés à son compte, il faut donner au réseau un transaction signée par la clé privée associée à l'addresse. Un Wallet ne contient donc pas réelement d'Ethers, il n'est que la preuve de propriété d'une certaine addresse.

###### Nonce

Chaque addresse possède une nonce, c'est à dire un nombre de transactions éffectuées.



Dans cet exercice, vous devez écrire un script js `eth_account_infos.js` dans un dossier `AccountInfos` ayant le comportement suivant.


```
$ node eth_account_infos.js https://rinkeby.infura.io/VOTRE_TOKEN 0xB279182D99E65703F0076E4812653aaB85FCA0f0
Information Log for address: 0xB279182D99E65703F0076E4812653aaB85FCA0f0
 - Account Balance: 4240.812867821322067248 ETH
 - Transaction Count: 0
 - Not a Smart Contract

 $ node eth_account_infos.js https://rinkeby.infura.io/VOTRE_TOKEN 0x684d7898E565Ee105f7402aeCf1b7E59c2d73322
Information Log for address: 0x684d7898E565Ee105f7402aeCf1b7E59c2d73322
 - Account Balance: 0.9 ETH
 - Transaction Count: 1
 - Is a Smart Contract
```

###### Question

(Dans un fichier `nonce`)

- En sachant qu'à chaque transaction, le nonce est inclu dans les champs transmis, donner l'utilité d'avoir une nonce et de toujours devoir l'inclure dans une transaction (1 pt).

#### Exercice 3: Block Infos (2.5 pt)


Dans cet exercice, vous devez écrire un script js `eth_block_infos.js` dans un dossier `BlockInfos` ayant le comportement suivant.

```
$ node eth_block_infos.js https://rinkeby.infura.io/VOTRE_TOKEN 1693463
Information Log for Block: 0x162a16cf8b0b1a571c53614688f826fc6983e338e2c20a6ccb09549545ebbb4e
 - Block size: 6270
 - Block was mined by: 0x0000000000000000000000000000000000000000
 - Block contains 4 transactions
   - [1]: Transaction from 0x0cb510E2F16C36ce039Ee3164330D5F00ECf9eAC to 0x4eaC9A8c7a6c3a869CDBff4E06cb552148749206 with a value of 0.000000000001083409 Ether
   - [2]: Transaction from 0xCf6aAF4B498b348645F46Ed855F5c8B8c8b136Cb to 0x025D0bF795B2Fd8F5551AC34205F30b7CA554625 with a value of 0 Ether
   - [3]: Transaction from 0xE89C39E4F9Bd49941B7A9ED0f790Be20103B8f7b to 0xc03B79AF54eE0eC89E05Cd383D3cf35707F505F8 with a value of 0.4 Ether
   - [4]: 0x889042536aa9347eA84Bd6e84c969e56156F2CE4 created a new Smart Contract at address 0x5Cb57331dD24760861352Fb5b87e38e2DA170A43

$ node eth_block_infos.js https://rinkeby.infura.io/VOTRE_TOKEN 1693464
Information Log for Block: 0xf8e0587f8a806ce92b0324296f665ceb8c8f52c55a59b74800615e5defea6b95
 - Block size: 609
 - Block was mined by: 0x0000000000000000000000000000000000000000
 - Block contains 0 transactions
```

#### Exercice 4: Transaction Generator (5 pt)

Dans cet exercice, vous devez écrire un script js `eth_gen_tx.js` dans un dossier `Transaction Generator` ayant le comportement suivant.

La transaction générée doit être signée !
`wallet.save` est un wallet au format V3, son mot de passe doit être ensuite fourni.
Les deux derniers paramètres sont l'addresse de destination et la quantité de Wei à envoyer

```
$ node eth_gen_tx.js  https://rinkeby.infura.io/VOTRE_TOKEN wallet.save BCPool! 0x889042536aa9347ea84bd6e84c969e56156f2ce4 123
Generating Tx from 0xad13730076c7317eb977be64afb0b894f36c5b63 to 0x889042536aa9347ea84bd6e84c969e56156f2ce4 with value 0.000000000000000123 Ether

 - Nonce: 0x01
 - GasPrice: 0x3b9aca00
 - GasLimit: 0x6ad07d
 - To: 0x889042536aa9347ea84bd6e84c969e56156f2ce4
 - Value: 0x7b
 - r: 0x1b
 - v: 0x15bb450f30bb8151001aad2bdcdb0875518fc2ffbcc6c748afcf70249598384f
 - s: 0x62b08dd546a403665c751b31beb19dc3abc02902ae403eee532513365ffa7670

```

#### Exercice 5: Contract Transaction Generator (7.5 pt)


###### Contracts

Les Smart Contracts sont des morceaux de codes pouvant être éxécutés lors d'une transaction. Le code est stocké dans les listes des Comptes qui contiennent des informations sur toutes les addresses (nombres de transaction, balances ...). En effet, comme toute addresse, un Smart Contract peut avoir une balance. Un Smart Contract ne peut pas générer de transaction tout seul, il faudra une intervention exterieure pour pouvoir éxécuter du code. On peut donc avoir une chaîne d'action lors de l'appel à un Smart Contract. Attention, la moindre action effectuée par un Smart Contract a un coût en gas. Plus le Contract est complexe, plus la transaction va vous coûter. De plus, si la quantité de gas nécéssaire à l'éxécution dépasse la Gas Limit, la transaction va échouer.

Ce code compilé est au format EVM ([Ethereum Virtual Machine](https://github.com/ethereum/wiki/wiki/Ethereum-Development-Tutorial)), et comme l'assembleur, se compose de bytecodes. 

[--> HELP <--](https://github.com/ethereum/wiki/wiki/Ethereum-Contract-ABI)

Dans cet exercice, vous devez écrire un script js `eth_gen_contract_tx.js` dans un dossier `ContractTransactionGenerator` ayant le comportement suivant.

Sans avoir d'autres informations que la signature de la méthode à appeler, générez une transaction pouvant éxécuter du code d'un Smart Contract.

Votre script doit pouvoir gérer les uint256, les bool et les addresses.

L'exemple appele la méthode `test` d'un smart contract situé à l'addresse `0x889042536aa9347ea84bd6e84c969e56156f2ce4`, ayant pour arguments `(uint256, bool, address)` avec `1200300300302`, `true` et `0x889042536aa9347ea84bd6e84c969e56156f2ce4`

```
$ node eth_gen_contract_tx.js  https://rinkeby.infura.io/VOTRE_TOKEN wallet.save BCPool! 0x889042536aa9347ea84bd6e84c969e56156f2ce4 "test(uint256,bool,address)" 1200300300302 true 0x889042536aa9347ea84bd6e84c969e56156f2ce4
Generating Tx from 0xad13730076c7317eb977be64afb0b894f36c5b63 to 0x889042536aa9347ea84bd6e84c969e56156f2ce4 Smart Contract

 - Nonce: 0x01
 - GasPrice: 0x8dea733c
 - GasLimit: 0x6acfc0
 - To: 0x889042536aa9347ea84bd6e84c969e56156f2ce4
 - Data: 0x0b7d9d86000000000000000000000000000000000000000000000000000001177779180e0000000000000000000000000000000000000000000000000000000000000100000000000000000000889042536aa9347ea84bd6e84c969e56156f2ce4
 - r: 0x1c
 - v: 0x6e4af53e23b47c6e5554cef440ab40c93dd8fe9234a0701cbb50e668e59945aa
 - s: 0x3681e0178c657a07294da18eeaed65d13941c007b9ee7558807bc07308fdb7ca
```
