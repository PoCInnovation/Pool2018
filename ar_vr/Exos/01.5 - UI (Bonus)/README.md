# Piscine VR Mobile : Jour 3 -- VR Mobile

- Nom du répertoire: VRPool_d03
- Fichier à rendre: d03.apk
- Droits: christian.chaux@epitech.eu (droits de lecture)

Ce jour fait suite au précédent, cependant les projets se feront par groupes de 2, le chef de groupe créera le répo et mettra le projet dedans.  
Son binôme aura un répertoire qui contiendra un fichier texte nommé "Binômed" qui contiendra l’adresse mail du chef de groupe.

> Votre but est d’intégrer de la VR avec les Google Cardboard sur le projet que vous avez fait hier.

## Etape 1: Android Studio
Compilez votre projet et exportez le sur votre téléphone.  
Vous pouvez venir chercher une casque Cardboard en échange de votre carte étudiant.

## Etape 2: Tirs
Créer un objet au dessus de votre carte qui sera votre joueur.  
Ce dernier tirera à intervalle régulier dans la direction dans lequel regarde le joueur.

## Etape 3: Déplacements
Vous devez implémenter un système de déplacement en respectant la consigne suivante:
- Le joueur est immobile pendant 2 secondes pour charger son tir
- Puis tir un laser dans la direction vers lequel le joueur regarde
- Enfin le joueur à 3 secondes pour déplacer son vaisseau dans la direction dans lequel il regarde (uniquement sur les axes X et Z, à vous de faire quelque chose de maniable)
