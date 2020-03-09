<div><img src="images/POC.png" width="20%"/></div>
<div style="text-align:center" ><img src ="images/ETH.png" width="30%" /></div>

# PoCDapps

Le projet PoCDapps a pour but de créer un ensemble de services décentralisés.

## Introduction

Par petits groupes, nous allons mettre en place chaque service. Chacun de ces services devra utiliser le Core qui s'occupera des identités et qui est déjà construit.
Vous devez donc gérer l'identité des utilisateurs via le Core.

## Core

<div style="text-align:center" ><img src ="images/CORE.png" width="30%" /></div>

Le Core est la partie principale de PoCDapp, qui s'occupe de l'identité des utilisateurs.

Vous travaillerez sur vos propres branches dérivants de `dev`. Vous aurez donc l'intégralité du Core fonctionnel.

Vous devrez donc ajouter votre propre Migration de vos Smart Contracts, ainsi que l'ajout de l'addresse de vos Smart Contract dans le Smart Contract `Indexer` déjà déployé.

Inspirez vous du déploiement du Smart Contract `Identifier`.

Ensuite, lors de la mise en place de votre application, récupérez l'addresse de votre Smart Contract via l'`Indexer` que vous aurez au préalable rempli.

## Group Accounts

<div style="text-align:center" ><img src ="images/GROUPACCOUNTS.jpg" width="30%" /></div>


Ce service listera les MultiSigWallets de l'utilisateur et lui proposera une interface pour proposer des transaction, accepter ou refuser des transactions ou annuler ses transactions.

## Lotto

<div style="text-align:center" ><img src ="images/LOTTO.jpeg" width="30%" /></div>

Ce service utilisera un Oracle pour récuperer un nombre aléatoire en dehors de la Blockchain. Il s'agit d'un système de Lotto simple, où le gain est la somme des couts des tickets. Vous êtes libres d'imaginer son fonctionnement en details.

## Cryptter

<div style="text-align:center" ><img src ="images/CRYPTTER.jpg" width="30%" /></div>


Un twitter version Blockchain, où chaque tweet est public, où l'on peut suivre des gens, chercher des gens à suivre. Le système est simple et tient en une page, pas de profile etc ... Il s'agit juste d'afficher un flux de messages dans l'ordre correspondant et de gérer les follows etc ...

## VidéoClub

<div style="text-align:center" ><img src ="images/VIDEOCLUB.jpg" width="30%" /></div>


Service le plus complexe, il faudra mettre en place un système d'enregistrement de vidéo et de streaming de vidéo sur une machine du Hub. Lors de l'upload, l'utilisateur choisi un cout de lecture. Pour visionner les vidéo il faudra donc payer ce cout pour pouvoir voir la vidéo en streaming dans son browser.

## Morpion

<div style="text-align:center" ><img src ="images/MORPION.png" width="30%" /></div>


Mettre en place un système de morpion, avec des parties à durées non déterminées. Un cout d'entrée, le gagnant récupère son cout d'entrée et celui de l'adversaire.

## The Map

<div style="text-align:center" ><img src ="images/THEMAP.jpg" width="30%" /></div>


Une map de 1920*1080, ou chaque pixel est achetable. Le challenge ici est la façon avec laquelle l'utilisateur va pouvoir acheter des pixels en groupe pour y mettre une image. Plus il y'a de pixels achetés, plus les suivants coutent cher.

## Poll

<div style="text-align:center" ><img src ="POLL.png" width="30%" /></div>

Un système de vote sur des sujets totalement définissables par l'utilisateur. Il peut choisir le nombre de réponse et leur contenu.

