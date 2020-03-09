# Piscine VR Mobile : Jour 0 -- C#

- Nom du répertoire: VRPool_d00
- Droits: christian.chaux@epitech.eu (droits de lecture)

Vous avez déjà tous fait du C en première année, pour cette piscine, nous allons faire du C#.  
Il est à noter que nous serons en C# 6 pour cette piscine.  
Bien qu’une partie de la syntaxe vous sera assez familière, le C# va nous apporter 2 grandes nouvelles notions:  
- Les pointeurs sont considéré "unsafe" en C#, nous n’en utiliserons donc aucun.
- Le C# est un langage objet, contrairement au C. Cela nous amènera donc plein de nouveautés, comme les class.

> Le fichier rendu sera `Part1.cs`  
> Un fichier `Help.cs` vous sera fourni, vous ne devez pas le rendre


## Exercice 01 : Concaténation
### Implémentez Add.

Concatène les 2 chaines de caractère et les retourne.  
Une chaîne null doit être considéré comme une chaîne vide.

## Exercice 02 : Exceptions (En envoyer)
### Implémentez GetNbOccurance.

Renvoie le nombre de fois que le char c est présent dans la string str.  
Si str est null, str throw une exception de type ArgumentNullException.

## Exercice 03 : Exceptions (En recevoir)
### Implémentez PublicWriteInFile.

Appelle `WriteInFile` et catch les exceptions qu’il envoie.  
Si exception de type ArgumentNullException, retourne "Argument is null"  
Si exception de type FileNotFoundException, retourne "File not found"  
Sinon retourne `null`

## Exercice 04 : Tableaux statiques
### Implémentez MakeArray.

Prend 3 chaînes de caractères en paramètre et retourne un tableau contenant les 3.

## Exercice 05 : Tableaux dynamiques
### Implémentez AddIntToStringList.

Prend une `List` et un int, et rajoute le int à la `List` avant de renvoyer cette dernière.
Si la `List` est `null`, retournez `null`.

## Exercice 06 : Passage par référence
### Implémentez Swap

Échange la valeur des deux variables passé en paramètre.

## Exercice 07 : Algo
### Implémentez NbStrstr

Retourne le nombre de fois que b est trouvé dans a.
(Aide: Combien de fois y a t-il "aba" dans "ababa" ?)

## Exercice 08 : Algo
### Implémentez AddInf.

Prend deux chaine de caractère qui sont des nombres entier et retourne l’addition des 2.  
Vous n’avez pas à gérer les nombres négatif.  
Retournez `null` dans le cas d’un chaine `null`.  

## Exercice 11 : Classes
### Implémentez Character.

- Le constructeur, initialise toutes les variables de la classe. De base, l’arme d’un personnage fait 10 points de dégâts.
- La fonction `TakeDamage`, qui retire des points de vie au personnage selon la valeur passé en paramètre. Un personnage ne peut pas avoir moins de 0 points de vie.
- La fonction Attack, qui prend un personnage et lui inflige des dégâts en passant par la fonction `TakeDamage`. Si l’attaque est impossible, il ne se passe rien.
- L’override de la fonction `ToString`, qui retourne une chaîne de caractère dans ce format:
    - NAME (PDV%)
    - NAME étant le nom du personnage et PDV sa vie en pourcentage (doit être un nombre entier, arrondi par défaut).

## Exercice 12 : Héritage
### Implémentez Ship, Destroyer, Submarine, AircraftCarrier et Battleship.

- Un destroyer commence avec 100 points de vie, 2 torpilles, 4 grenades anti-sous-marines, une puissance antiaérienne de 1 et une puissance de feu de 30.
- Un sous-marin commence avec 75 points de vie et 5 torpilles, 0 grenade anti-sous-marine, une puissance antiaérienne de 0 et une puissance de feu de 0..
- Un porte-avion commence avec 200 points de vie et 0 torpilles, 0 grenade anti-sous-marines, une puissance antiaérienne de 1, une puissance de feu de 0 et 25 avions.
- Un cuirassé commence avec 300 points de vie et 0 torpilles, 0 grenades anti-sous-marines, une puissance antiaérienne de 3 et une puissance de feu de 80.
- GetShipType doit retourner le préfixe associé au navire en se basant sur cette [page](https://en.wikipedia.org/wiki/Hull_classification_symbol)
- ToString retourne une chaine de charactère dans ce formet:
    - NAME - SHIPTYPE (PDV%)
    - NAME étant le nom du navire
    - SHIPTYPE étant son prefix
    - PDV étant sa vie (doit être un nombre entier, arrondi par défaut)
(Nous nous baserons sur la nomination durant la seconde guerre mondiale).
- Un navire qui attaque lancera une torpille si il peut. Si il ne peut pas il attaquera avec ses canons.
- Une torpille fait 70 points de dégâts et une grenade anti-sous-marin en fait 80 (et évidemment une torpille ou une grenade-anti-sous-marin utilisé ne peut pas être réutiliser.)
- Il y a cependant quelques cas spéciaux:
- Si le navire fait face à un sous-marin il ne pourra le toucher uniquement en utilisant une grenade-anti-sous-marin.
- Si le navire fait face à un avion (tous les avions seront des torpilleurs dans notre cas), nous calculerons les dégâts de la manière suivante:
- Tout d’abord nous ferons nbAvions - puissanceAntiAerienne pour calculer le nombre d’avions qui passeront à travers les canons antiaérien, puis nous ferons avionsRestant * dégâtDuneTorpille. Les avions non détruit seront de nouveaux soustrait à la puissance de feu des canons antiaérien, et les survivants pourront rentrer sur le porte-avion.
- Les porte-avions peuvent uniquement attaquer en déployant des escadrille de 5 avions ou moins.
- Évidemment un navire coulé ne peut pas attaquer.


