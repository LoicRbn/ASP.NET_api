Application ASP.NET Api Rest

Loïc ROBIN B3 Dev groupe B

J'ai travaillé avec Quentin pour la base de donnée.
Et avec Lucas qui m'a conseillé SwaggerUI pour tester les routes de mon API.

Toutes les routes sont listées sur l'interface SwaggerUI au démarrage.
On peut tester les routes à partir de SwaggerUI.

SQL : 

Fichier de creation des tables : script.sql
Export de la base de donnée : loicrobin.sql

Tables : 
Conso : Table qui contient les consommations.
Commande : Table qui contient l'id de différentes commandes.
Contenir : Table qui contient les consommations pour les différentes commandes 
ainsi que l'état de chaque consommation dans les commandes.


Fonctionnalités : 

- 1 : Prendre les commandes des clients (entrée / plat, plat / dessert , entrée plat dessert, le tout avec ou sans boisson) 

Fait via l'insertion des consommations dans les commandes.
Utiliser la route /createCommande et insérer l'id commande, l'id de la conso voulu 
(table Conso) et son état (en préparation, livré)

- 2 : De connaître la situation de chaque plat( ou entrée, ou dessert ou boisson) préparé ( commande enregistré, en préparation )

Fait via la méthode get disponible à la route /getContenir qui donnes les informations
des commandes ou d'une commande

- 3 : modifier l'état de la commande en livré

Fait via la méthode put à la route /updateStateCommande qui permet de modifier la
consommation d'une commande en passant l'id de la commande, l'id de la conso et
l'état modifié.


Instructions : 

- Télécharger l'export de base de données
- Modifier la connexion à la base dans le code
- Lancer le projet
- Accès à toutes les routes via SwaggerUI