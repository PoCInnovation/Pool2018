#<center>PoC Pool: Computer Security</center>
#<center>Web Server</center>

## Introduction

Nous avons vu que la sécurité d'une application web ne se joue pas côté client.
Au contraire, tous les mécanismes de sécurité doivent être implémentés côté
serveur.

Seulement, il convient de faire également très attention lorsqu'on implémente
des vérifications côté serveur. En effet, le fait de vérifier une entrée
utilisateur implique de d'abord récupérer cette entrée. Comme pour le côté
client, cela peut conduire à différentes injections.

## Exercice 0

Commençons par un petit échauffement.

Réalisez les épreuves suivantes :

  - HTML
  - Injection de commande
  - User-agent

Ces épreuves présentent des systèmes assez peu réalistes. Mais vous
comprenez le principe : derrière l'application web se trouve une machine.
Le back-end de l'application interragit directement avec cette machine
et il convient donc d'etre particulièrement prudent avec les entrées
utilisateur si on ne veut pas se retrouver avec une
[RCE](https://en.wikipedia.org/wiki/Arbitrary_code_execution).

De plus, on ne fait pas de sécurité avec des informations que l'utilisateur
controle totalement (ou meme partiellement). Bien que la vérification d'un
user-agent se fasse coté serveur, c'est une méthode totalement inefficace.

## Exercice 1

Voyons quelques failles un peu plus réalites :

  - HTTP verb tampering
  - HTTP directory indexing
  - HTTP cookies

Il va falloir vous renseigner sur le protocole HTTP et les différents
systèmes qui l'entourent pour réussir ces épreuves. Vous devez comprendre
que votre navigateur, en plus de pouvoir vous afficher des pages HTML,
est surtout capable de recevoir et parser des réponses HTTP, suite à ses
requètes. Essayez donc d'utiliser **curl**, peut etre que ça changera votre
vision du web !

Vous vous demandez si vous n'etes pas passé à coté d'une ressource
intéressante dans l'arborescence d'une application web ? Intéressant ! Vous
connaissez [dirb](https://tools.kali.org/web-applications/dirb) ?

## Exercice 2

Intéressons nous maintenant à quelques erreurs de programmation que l'on
retrouve encore très souvent :

  - File upload - null byte
  - File upload - type MIME
  - File upload - double extensions
  - Local File Inclusion
  - Remote File Inclusion

Toutes ces vulnérabilités sont hyper documentées sur internet. Vous n'avez
pas besoin de mon aide ici ! ;)

Profitez de ces épreuves pour jeter un coup d'oeil à Burp si ce n'est pas
déjà fait. Il est souvent beucoup plus efficace de travailler directement
dans Burp plutot que dans son navigateur. Des outils comme le **proxy** ou
le **repeater** font plutot le café.

## Exercice 3

Continuons avec d'autres erreurs de programmation un peu plus spécifiques à
PHP.

  - PHP assert()
  - PHP preg_replace()
  - PHP type juggling

PHP est un langage ultra populaire quant il s'agit d'écrire une application
web. On entend beaucoup parler de frameworks PHP comme Symfony ou Laravel.
Ces frameworks ont l'avantage de masquer de nombreuses faiblesses de PHP
tels que sa gestion des types.

## Exercice 4

Il est temps de nous intéresser aux injections SQL.

SQL est un langage de base de données ultra répandu qui s'est assez rarement
montré vulnérable en soi. Cependant, une mauvaise intégration entre PHP et
SQL peut conduire à d'importantes fuites d'informations.

  - SQL injection - authentification
  - SQL injection - string
  - SQL injection - numérique
  - SQL injection - en aveugle

On raconte que Python combiné aux modules `requests`, `string` et `itertools`
permet d'etre super efficace. Burp est aussi une très bonne solution !
