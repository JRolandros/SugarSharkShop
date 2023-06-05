# SugarSharkShop
For Maplr recrutment test - Backend for the Maplr suger shark brand

# Getting started

## Prerequis

Pour lancer ce projet vous devez avoir 
* .Net core SDK installé sur votre ordinateur (pour ceux qui utilisent le CLI) ou visual 2022 à jour avec la version .net 7.
* dotnet ef installé globalement sur le poste développeur via cette commande : dotnet tool install --global dotnet-ef lire plus à ce sujet https://learn.microsoft.com/en-us/ef/core/get-started/overview/install

## Base de données et données initiales

commandes pour initialiser la base de données.

* Appliquer le script de migration : ___dotnet ef database update --project SugarShark.Infrastructure --startup-project SugarShark.Api___
* La Base de donnée est créée automatiquement. Nom BD =SugarSharkStore

#### Ceci n'est pas nécessaire pour le lancement de l'application.

Au besoin si le modèle change, il faut recréer une migration : ___dotnet ef migrations add migrationName --project SugarShark.Infrastructure --startup-project SugarShark.Api___

# Documents d'analyse et de conception
J'ai résumé l'analyse du besoin de ce projet sous forme de 3 documents schema disponible dans ce projet git sous ___Solution Items>docs___ vous verrez donc :
* Diagramme simplifié du Use case qui met en lumière les différentes services (ou actions) implémenté(e)s dans cette solution. Le use regroupe les services en trois grands modules
* Diagramme d'architecture applicative, qui met en évidence les différent grand blocks ou découpage de la solution technique.
* Diagramme de base de données pour mettre en évidence les interactions entre les différents types de données manipulées.

Dans la conception, j'ai légèrement modifié la demande pour le service ___Place Order___ Car j'ai trouvé que gérer les commandes à travers un panier était plus soft et plus pertinent. Ainsi pour passer une commande
il faut juste fournir l'Id du user ensuite, la solution ira chercher son panier (sachant qu'on ne peut avoir qu'un panier à la fois). Avec le panier on est à mesure de connaitre tous les produits de la commande avec leur quantités.

__Nota__ Ici la solution est conçue à sa version 1 la plus simpliste. Une amélioration très souhaitable serait de séparer chaque module sous forme de microservice totalement indépendants chacun avec sa base de données. On pourrait aller plus loin en orchestrant le tout dans docker.

# Authentification
Le mécanisme d'authentification utilisé dans ce projet est l'OpenId Connect de Identity server. Je me suis servi du template très connu de Duende (payant pour la production)
Tous les endpoints sont maintenant sécurisés. Pour les accéder, il faut :

* Configurer visual studio pour démarrer en mode "Projets multiples" ceci permet de lancer à la fois l'api et l'IdP (Identity Provider).
* En utilisation la collection postman fournie (voir comment importer la collection postman), il faudra cliquer sur successivement sur IdP>GetToken>Authorization>Get New Access Token (bouton situé tout en bas de la page). 
Si vous avez un échec énonçant un problème de certificat, aller dans Settings de la request et désactiver la propriété ___Enable SSL certificate verification___ et réessayer. 
Après succes, cliquer sur le bouton ___Proceed___ qui s'affiche à l'écran puis sur le prochain bouton ___Use Token___. Apres cela, toujours sur la même requête (GetToken) cliquer sur le bouton bleu ___Send___ vous n'aurait aucun résultat interessant
mais Ceci permettra de set le nouveau token obtenu dans une variable globale ainsi le token pourra être utilisés ailleur dans postman. Refaites ces actions à chaque fois que le token va expirer.
* Maintenant vous pouvez tester l'api à votre guise.
* Il faut noter que toutes les informations du provider IdP sont stockées en mémoire.


__NB__ Pour le moment je fixe l'utilisateur avec userId=1. L'idée est d'ajouter une gestion des utilisateurs dans l'IdP. et extraire à partir de la le userId. Prochaine étape.

#### Nota

Avec la pression dans mon travail je n'ai pas pu avancer comme je le souhaitais. Je continuerai à faire des petits commit ce weekend et après si possible.

Merci.
