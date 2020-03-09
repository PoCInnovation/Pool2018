#<center>PoC Pool: Computer Security</center>
#<center>Web Client</center>

## Introduction

Une application web conduit généralement à de l'exécution de code coté
serveur mais également coté client. Le langage le plus répandu est alors
le Javascript.

Vous allez analyser du code Javascript vulnérable afin d'identifier de
mauvaises pratiques de programmation qui peuvent conduire à l'introduction de
failles de sécurité dans une application web.

Vous allez également découvrir deux familles de vulnérabilités : les XSS et les
CSRF.

## Exercice -1

Installez la dernière version du logiciel Firefox.

Les gens de la sécurité utilisent généralement deux navigateurs : un pour aller
normalement sur internet et un autre pour le "sale boulot". En effet, vous
serez surement ammenés à installer des plugins ou modifier les parametres
de votre proxy et ces modifications n'ont pas besoin de polluer votre
environnement de travail.

## Exercice 0

Si vous n'avez pas encore de compte sur root-me, créez en un.

Explorez rapidement le site et prenez vos marques.

Rendez-vous dans la catégorie "Web-Client" du site.

## Exercice 1

Réalisez les épreuves suivantes :

  - HTML - boutons désactivés
  - Javascript - Source
  - Javascript - Authentification
  - Javascript - Authentification 2

Vous ne devez utiliser que les outils de développement de Firefox afin de
réussir ces épreuves.

Il est rare de voir ce genre de systèmes dans la nature. Passons à des
vulnérabilités un peu plus réalistes.

## Exercice 2

Réalisez l'épreuve suivante :

  - XSS - Stored 1

Vous avez besoin d'un serveur WEB ? On m'a dit que
[RequestBin](https://requestb.in/) fonctionne pas mal.

## Exercice 3

Réalisez l'épreuve suivante :

  - CSRF - 0 protection

Comprenez ce que vous devez faire avant d'essayer de le faire.

## Exercice 4

Revenons sur du Javascript. Avec du code un peu plus exotique cette-fois.

Réalisez les épreuves suivantes :

  - Javascript Obfuscation 1
  - Javascript Obfuscation 2
  - Javascript Obfuscation 3
  - Javascript Native Code

Ces exercices ne sont plus vraiment directement liés à la sécurité web coté
client. Il s'agit plutot d'étudier des algorithmes plus ou moins obfusqués.

Renseignez vous sur les méthodes permettant d'obfusquer du Javascript. Jouez
avec la console du navigateur, factorisez le code et manipulez copieusement
les variables. Les outils de développement du navigateur sont surement plus
puissants que ce que vous pensez.