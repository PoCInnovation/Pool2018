#<center>PoC Pool: Computer Security</center>
#<center>Cracking</center>

## Introduction

Vous allez aujourd’hui découvrir le milieu du « cracking ».

Le terme en lui même a des origines plutôt nobles mais a assez mal évolué. Il est souvent aujourd’hui utilisé comme synonyme de cybercriminalité par de nombreux médias et autres experts.

Le cracking désigne en fait l’art de contourner une limitation logicielle. Les plus communes sont : une demande de mot de passe (ou de clé produit ? ;)) ou bien une interdiction d’utiliser une fonctionnalité lorsque une ou plusieurs conditions ne sont pas remplies.

Lorsque l’on crack un logiciel, le procédé est souvent en deux étapes : le contournement des protections anti-debug d’une part et l’analyse de la cible en elle même d’autre part.

En effet, les éditeurs de logiciel connaissent les techniques utilisés pour analyser leurs produits et se munissent alors de protections supplémentaires appelées anti-debug. Ces protections peuvent être statiques si elles empêchent la simple lecture statique de code (sans exécution dans un debugger ou ailleurs) ou dynamiques si elles empêchent le debugger de correctement travailler.

La seconde étape est donc l’analyse de la cible en elle même. C’est alors un problème purement algorithmique qui demande de bien connaitre ses outils, la machine et l’assembleur.

## Exercice 1

Commençons par quelques exercices d'échauffement.

* ELF : 0 protection
* ELF : x86 basique

ELF ? Qu'est c'que c'est ?

## Exercice 2

Voyons maintenant comment vous vous débrouillez avec des protections anti-debug :

* ELF : Fake instruction
* ELF : ptrace()
* ELF : Pas de point d'arrêt
* Elf : Crackpass

## Exercice 3

Et si on faisait un peu de Windows ?

* PE : 0 protection
* PE : Dotnet 0 protection

Bon courage ! :D