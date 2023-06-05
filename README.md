# SugarSharkShop
For Maplr recrutment test - Backend for the Maplr suger shark brand

# Getting started

## Prerequis

Pour lancer ce projet vous devez avoir 
* .Net core SDK install� sur votre ordinateur (pour ceux qui utilisent le CLI) ou visual 2022 � jour avec la version .net 7.
* dotnet ef install� globalement sur le poste d�veloppeur via cette commande : dotnet tool install --global dotnet-ef lire plus � ce sujet https://learn.microsoft.com/en-us/ef/core/get-started/overview/install

## Base de donn�es et donn�es initiales

commandes pour initialiser la base de donn�es.

* Appliquer le script de migration : ___dotnet ef database update --project SugarShark.Infrastructure --startup-project SugarShark.Api___
* La Base de donn�e est cr��e automatiquement. Nom BD =SugarSharkStore

#### Ceci n'est pas n�cessaire pour le lancement de l'application.

Au besoin si le mod�le change, il faut recr�er une migration : ___dotnet ef migrations add migrationName --project SugarShark.Infrastructure --startup-project SugarShark.Api___

# Documents d'analyse et de conception
J'ai r�sum� l'analyse du besoin de ce projet sous forme de 3 documents schema disponible dans ce projet git sous ___Solution Items>docs___ vous verrez donc :
* Diagramme simplifi� du Use case qui met en lumi�re les diff�rentes services (ou actions) impl�ment�(e)s dans cette solution. Le use regroupe les services en trois grands modules
* Diagramme d'architecture applicative, qui met en �vidence les diff�rent grand blocks ou d�coupage de la solution technique.
* Diagramme de base de donn�es pour mettre en �vidence les interactions entre les diff�rents types de donn�es manipul�es.

Dans la conception, j'ai l�g�rement modifi� la demande pour le service ___Place Order___ Car j'ai trouv� que g�rer les commandes � travers un panier �tait plus soft et plus pertinent. Ainsi pour passer une commande
il faut juste fournir l'Id du user ensuite, la solution ira chercher son panier (sachant qu'on ne peut avoir qu'un panier � la fois). Avec le panier on est � mesure de connaitre tous les produits de la commande avec leur quantit�s.

__Nota__ Ici la solution est con�ue � sa version 1 la plus simpliste. Une am�lioration tr�s souhaitable serait de s�parer chaque module sous forme de microservice totalement ind�pendants chacun avec sa base de donn�es. On pourrait aller plus loin en orchestrant le tout dans docker.

# Authentification
Le m�canisme d'authentification utilis� dans ce projet est l'OpenId Connect de Identity server. Je me suis servi du template tr�s connu de Duende (payant pour la production)
Tous les endpoints sont maintenant s�curis�s. Pour les acc�der, il faut :

* Configurer visual studio pour d�marrer en mode "Projets multiples" ceci permet de lancer � la fois l'api et l'IdP (Identity Provider).
* En utilisation la collection postman fournie (voir comment importer la collection postman), il faudra cliquer sur successivement sur IdP>GetToken>Authorization>Get New Access Token (bouton situ� tout en bas de la page). 
Si vous avez un �chec �non�ant un probl�me de certificat, aller dans Settings de la request et d�sactiver la propri�t� ___Enable SSL certificate verification___ et r�essayer. 
Apr�s succes, cliquer sur le bouton ___Proceed___ qui s'affiche � l'�cran puis sur le prochain bouton ___Use Token___. Apres cela, toujours sur la m�me requ�te (GetToken) cliquer sur le bouton bleu ___Send___ vous n'aurait aucun r�sultat interessant
mais Ceci permettra de set le nouveau token obtenu dans une variable globale ainsi le token pourra �tre utilis�s ailleur dans postman. Refaites ces actions � chaque fois que le token va expirer.
* Maintenant vous pouvez tester l'api � votre guise.
* Il faut noter que toutes les informations du provider IdP sont stock�es en m�moire.


__NB__ Pour le moment je fixe l'utilisateur avec userId=1. L'id�e est d'ajouter une gestion des utilisateurs dans l'IdP. et extraire � partir de la le userId. Prochaine �tape.

#### Nota

Avec la pression dans mon travail je n'ai pas pu avancer comme je le souhaitais. Je continuerai � faire des petits commit ce weekend et apr�s si possible.

Merci.
