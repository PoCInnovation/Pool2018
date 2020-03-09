<div><img src="images/POC.png" width="20%"/></div>
<div style="text-align:center" ><img src ="images/ETH.png" width="30%" /></div>

# Blockchain Pool Day 1

## Rendu

 Nom du repo: `bc_pool_1`.
 
 Droits : `rotaru_i` et `guyard_r` en `r`.
 
 Ne pushez pas vos `node_modules`.
 
 `npm install` sera lancé avant l'exécution de votre exercice, veillez à avoir un `package.json` correct.
 
 Vous avez le droit uniquement aux modules s'installant via npm, et aux fonctions JS basiques.


## Introduction

La cryptographie est un des moteurs principaux du fonctionnement de la Blockchain. Aujourd'hui nous allons voir plus en détails comment les signatures cryptographiques fonctionnent, et quels sont les bonnes habitudes à prendre lorsque l'on s'occupe de créer des wallets dans nos applications.

#### Exercice 1: Wallet Generator (2.5 pt)

Dans un dossier `WalletGenerator`, créez un generateur de wallet ayant comme nom `wallet_generator.js`.



```shell
//Générer un wallet dans le fichier wallet.save, ayant pour mot de passe BCPool!, en affichant l'addresse du nouveau wallet.

$ node wallet_generator.js wallet.save BCPool!
Address: 0xad13730076c7317eb977be64afb0b894f36c5b63

$ cat wallet.save | python -m json.tool
{
    "address": "ad13730076c7317eb977be64afb0b894f36c5b63",
    "crypto": {
        "cipher": "aes-128-ctr",
        "cipherparams": {
            "iv": "b41785f6ac274e1b87359d566907c5bb"
        },
        "ciphertext": "6ae8f200b1494ebb9a10478166c056159f202b35dfec653c7efed0614f5592a6",
        "kdf": "scrypt",
        "kdfparams": {
            "dklen": 32,
            "n": 262144,
            "p": 1,
            "r": 8,
            "salt": "a7088ce36338fef6973bbc5b1646f13a8b13f7b2b843aec0dd3c9fb6d938455f"
        },
        "mac": "b23c68477c132fd0086303321f0ed74eef8e393027a0c6b093a30a345b891ff7"
    },
    "id": "3abe9129-952a-49e3-a88c-538e022963b0",
    "version": 3
}
```



#### Exercice 2: Wallet Loader (2.5 pt)

Dans un dossier `WalletLoader`, créez un loader de wallet ayant comme nom `wallet_loader.js` capable d'effectuer les actions suivantes.

(/!\ Si jamais vous travaillez sur un projet nécessitant l'utilisation de paires de clés, il ne faut jamais, **JAMAIS**, afficher une clé privée)

```shell
//Prends en paramètre un fichier précédemment générer et son mot de passe, et affiche la clé privée.

$ node wallet_loader.js wallet.save BCPool!
Secret Private Key: 0x482bbf004d2c0c2e769c5be8c12fd56f110e1e4e3659f0e6f809c8272f925ebe

$ node wallet_loader.js wallet.save BCPool?
Invalid File or Password

$ node wallet_loader.js non-existing-file BCPool!
Invalid File or Password
```

#### Exercice 3: Mnemonic (7.5 pt)

BIP39 est un protocol de génération de `Seed` pour paires de clés. Il est utilisé pour permettre une restauration d'un wallet perdu à partir d'une suite de mots lisibles. Cette suite de mot est littéralement votre wallet, si quelqu'un recupère cette suite de mots, il pourra générer votre wallet **MÊME SANS VOTRE MOT DE PASSE**.
En effet, l'utilisation de la `Seed` a lieu avant même la définition du mot de passe. Il est donc impératif de garder sa suite de mots en sécurité si vous voulez protéger votre wallet.

Dans cette exercice, vous devez fournir dans un dossier `Mnemonic`, un fichier `mnemo.js`.

```shell
// Génère un wallet dans wallet.save, et sauvegarde le mnemonic dans mnemonic.save

$ node mnemo.js new_wallet mnemonic.save wallet.save BCPool!
Address: 0x9afac213a5d45017b7b5ede8bfcbb9dfc27c1df1

$ cat mnemonic.save
wave umbrella elite juice orange nature strong poet kitchen pipe divide modify

$ cat wallet.save | python -m json.tool
{
    "address": "9afac213a5d45017b7b5ede8bfcbb9dfc27c1df1",
    "crypto": {
        "cipher": "aes-128-ctr",
        "cipherparams": {
            "iv": "22054656a093d7cdbadf428fe69f7f1c"
        },
        "ciphertext": "04e5c8f177d83eef70bff64d24732f74f5c5368ad77298d8f33e94b85f2bfa0f",
        "kdf": "scrypt",
        "kdfparams": {
            "dklen": 32,
            "n": 262144,
            "p": 1,
            "r": 8,
            "salt": "9ddf54b3b485fb82f13a0c44c6630b402420cc38bfcd1e350b7d1db9a31ebcf9"
        },
        "mac": "879f7bf7cdf75697beae8483c42d1ddb3dea7c0281aed305620446430f1efcb0"
    },
    "id": "bbbe500b-bb63-4e21-b3da-0c7b0007c101",
    "version": 3
}

// Restaure un wallet à partir d'un mnemonic, en lui donnant un nouveau mot de passe

$ node mnemo.js restore_wallet mnemonic.save restored_wallet.save !looPCB
Recovered Address: 0x9afac213a5d45017b7b5ede8bfcbb9dfc27c1df1

$ cat restored_wallet.save | python -m json.tool
{
    "address": "9afac213a5d45017b7b5ede8bfcbb9dfc27c1df1",
    "crypto": {
        "cipher": "aes-128-ctr",
        "cipherparams": {
            "iv": "b91380c1afdfb94fef7f66babedce777"
        },
        "ciphertext": "4753c6d025491cb6a986f73c9b66ab02a595e5a5ae272c1c0c5dacd06013f3f0",
        "kdf": "scrypt",
        "kdfparams": {
            "dklen": 32,
            "n": 262144,
            "p": 1,
            "r": 8,
            "salt": "4f36890c6383462bce8c825d0fcd96ae44b0c71dff88875616599b133e9186c8"
        },
        "mac": "baf7993935f3fa67957d22518ce459574bee597fc7f3ad9f014b21c1e6cb2c2f"
    },
    "id": "f0e0dab1-3d79-40db-9b1d-ab731417a74f",
    "version": 3
}
```

Vous devez donc pouvoir regénérer un wallet uniquement à partir de son mnemonic. Chaque restauration a son propre mot de passe et doit être loadable avec le `WalletLoader` et le mot de passe approprié.

#### Exercice 4: Message Signer (7.5 pt)

Dans cet exercice, nous allons utiliser ces paires de clés que nous avons générer auparavant.
Une signature cryptographique consiste à utiliser sa clé privée pour signer de la donnée. En recupérant la signature, nous pouvont dire quelle est la clé publique associée à la signature.

Si l'on expose donc publiquement notre clé publique, n'importe qui pourrait vérifier l'authenticité d'un message signé par notre clé privée. C'est ainsi que fonctionne l'identité dans la Blockchain.

Ethereum utilise des paires de clés [`ECDSA`](https://fr.wikipedia.org/wiki/Elliptic_curve_digital_signature_algorithm) ([Elliptic Curve](https://fr.wikipedia.org/wiki/Cryptographie_sur_les_courbes_elliptiques) Digital Signature Algorithm) pour créer des signatures.


Dans un dossier `MessageSigner`, créez le fichier `message_signer.js` capable d'effectuer les actions suivantes.

```shell
// Configuration de l'outil

$ cat config.json | python -m json.tool
{
  "wallet": "./wallet.save",
  "password": "BCPool!"
}

// Un Wallet au format habituel

$ cat wallet.save | python -m json.tool
{
    "address": "9afac213a5d45017b7b5ede8bfcbb9dfc27c1df1",
    "crypto": {
        "cipher": "aes-128-ctr",
        "cipherparams": {
            "iv": "22054656a093d7cdbadf428fe69f7f1c"
        },
        "ciphertext": "04e5c8f177d83eef70bff64d24732f74f5c5368ad77298d8f33e94b85f2bfa0f",
        "kdf": "scrypt",
        "kdfparams": {
            "dklen": 32,
            "n": 262144,
            "p": 1,
            "r": 8,
            "salt": "9ddf54b3b485fb82f13a0c44c6630b402420cc38bfcd1e350b7d1db9a31ebcf9"
        },
        "mac": "879f7bf7cdf75697beae8483c42d1ddb3dea7c0281aed305620446430f1efcb0"
    },
    "id": "bbbe500b-bb63-4e21-b3da-0c7b0007c101",
    "version": 3
}

// Message de test

$ cat message
This is a test message

// Prends un fichier contenant un message et un fichier de sortie, signe le message avec le wallet spécifié dans config.json

$ node message_signer.js sign message signature.save
Signature OK

// Signature générée

$ cat signature.save | python -m json.tool
{
    "hash": "c15c907600828b7257e920be06909c1a1717d833e0b822359f360797c18d739f",
    "signature": "fca73737ae0d231c5fc0ce0e6da8c5581a6e9b720a330ff46c11de19061c177d275e4f0b4cf235babb3a13e8cd8b3f81218884e3fcd9e75d11184d87e8ebe77b00"
}

// Verifie que la signature a bien été produite par le wallet dans config.json

$ node message_signer.js verify signature.save
Signature matches

// Test avec une signature totalement fake

$ cat fake_signature.save | python -m json.tool
{
    "hash": "aaaaaaaaaa828b7257e920be06909c1a1717d833e0b822359f360797c18d739f",
    "signature": "fca73737ae0d231c5fc0ce0e6da8c5581a6e9b720a330ff46c11de19061c177d275e4f0b4cf235babb3a13e8cd8b3f81218884e3fcd9e75d11184d87e8ebe77b00"
}

// Signale une signature qui ne correspond pas

$ node message_signer.js verify fake_signature.save
Signature not matching

```
