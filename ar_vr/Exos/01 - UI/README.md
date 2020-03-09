# Piscine VR Mobile : Jour 2 -- Scripting

- Nom du répertoire: VRPool_d02
- Droits: christian.chaux@epitech.eu (droits de lecture)

**But**: Survivre le plus longtemps possible à une série de vagues.

## Etape 1: GetClosest
Implémentez `GetClosest(List<T>, out float)` dans `NPC.cs`  
La fonction prend une List de NPC (ou des classes filles) et retourne le plus proche, avec sa distance en paramètre.

## Etape 2: Algo
Modifiez la fonction `Update` de Alliee dans `Alliee.cs`  
Vous n’avez pas le droit de modifier les autres fonctions.  
Vous devez faire en sorte de survivre un minimum contre vos ennemies.

## Etape 3: Munitions
Implémentez un système de munitions:
- Le gunner commencera avec 500 munitions.
- Le sniper avec 10.
- Le spécialiste avec 25.

Des packs de vie tombent actuellement du ciel, vous devez faire en sorte qu’il y ai une chance sur 2 que ce soit un pack de munition à la place qui redonnera toutes les munitions.  
Évidemment un personnage à court de munition ne peux plus tirer.  

Pour cette exercice, vous êtes autorisé à modifier les fichiers `NPC.cs`, `Alliees.cs`, `Enemy.cs`, `NPCController.cs` et `FallingBonus.cs` ainsi que d’ajouter des préfabs de modifier les variables public de la scène.

## Etape 4: Algo v2
Améliorer l’algorithme de vos IA pour qu’elles récupèrent les packs de vie et de munitions si elles en ont besoin.
