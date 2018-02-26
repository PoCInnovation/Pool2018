#<center>PoC Pool: Computer Security</center>
#<center>Web Client: Cheatsheet</center>

## Sécurité coté client

Vous avez compris qu'on ne fait pas de sécurité coté client et surtout pas
du controle d'accès. HTML, Javascript ainsi que toutes les autres technologies
web clientes ne peuvent rien pour la sécurité ne votre application.

A partir du moment où l'utilisateur peut accéder à la routine de vérification,
celle ci n'est plus fiable. Il convient donc de **toujours** faire ce genre
de vérification exclusivement coté serveur.

Les navigateurs web modernes embarquent une impressionante collection d'outils
permettant de jouer avec la partie cliente d'une application web : console
Javascript, environnement de débogage (breakpoints), inspecteur... On peut
y accéder en appuyant sur "F12" dans Firefox.

## Javascript obfusqué

On tombe parfois sur du Javascript obfusqué donnant l'illusion que le
mécanisme de sécurité alors mis en place ne peut etre contourné. On entend par là que le code a été lourdement réécrit, le rendant peu lisible. L'obfusquation n'est qu'une contrainte de temps et n'est pas un mécanisme de sécurité satisfaisant. Voici quelques trucs sympas
quand il s'agit d'analyser du code Javascript :

* Être attentif aux blocs en hexadécimal, base64 ou autre représentation en apparence peu agréable mais en réalité facile à déchiffrer
* `unescape()` et `String.fromCharCode()`
* `.toString()`
* Tous les outils que vous trouverez en ligne avec des mots clés comme "javascript deobfuscator"

## Cross-Site Scripting

Wikipédia nous dit :

> Le cross-site scripting (abrégé XSS) est un type de faille de sécurité des sites web permettant d'injecter du contenu dans une page, provoquant ainsi des actions sur les navigateurs web visitant la page. Les possibilités des XSS sont très larges puisque l'attaquant peut utiliser tous les langages pris en charge par le navigateur (JavaScript, Java, Flash...) et de nouvelles possibilités sont régulièrement découvertes notamment avec l'arrivée de nouvelles technologies comme HTML5. Il est par exemple possible de rediriger vers un autre site pour de l'hameçonnage ou encore de voler la session en récupérant les cookies.

Bref, on regroupe sous le terme XSS la plupart des injections de code qu'il est possible de faire sur des technologies WEB. Une XSS est dite **stored** si elle peut être exploitée de manière "permanente" : c'est à dire, si l'entrée malveillante se retrouve stockée côté serveur (par exemple dans une base de données) puis rejouée. Une XSS est dite **reflected** si le payload peut se présenter sous la forme d'un lien malveillant qu'il est ensuite possible de distribuer : par exemple dans les paramètres d'une URL.

On retrouve ce type de vulnérabilité dans les URL, les formulaires et plus généralement tout endroit où l'utilisateur peut inscrire une entrée.

De nombreux exemples de payload sont disponibles [sur ce site](https://github.com/swisskyrepo/PayloadsAllTheThings/tree/master/XSS%20injection).

[RequestBin](https://requestb.in/) est un super outil qui évite d'avoir un déployer un serveur WEB.

## Cross-Site Request Forgery

Wikipédia nous dit : 

> En sécurité informatique, le Cross-Site Request Forgery, abrégé CSRF (parfois prononcé sea-surfing en anglais) ou XSRF, est un type de vulnérabilité des services d'authentification web.
>
> L’objet de cette attaque est de transmettre à un utilisateur authentifié une requête HTTP falsifiée qui pointe sur une action interne au site, afin qu'il l'exécute sans en avoir conscience et en utilisant ses propres droits. L’utilisateur devient donc complice d’une attaque sans même s'en rendre compte. L'attaque étant actionnée par l'utilisateur, un grand nombre de systèmes d'authentification sont contournés.
> 

Une faille de type CSRF consiste donc à envoyer un lien frauduleux à un utilisateur hautement privilégié sur une application WEB afin de profiter de ces droits lors qu'il cliquera sur le lien en question et exécutera l'action associé. Le lien est le plus souvent **fraudleux** et non **malveillant** car l'action qui lui est associée est bien prévue dans la conception de l'application.

Vous trouverez des exemples de payload [sur ce site](https://github.com/swisskyrepo/PayloadsAllTheThings/tree/master/CRLF%20injection).