# SugarSharkShop
For Maplr recrutment test - Backend for the Maplr suger shark brand

# Getting started

## Prerequis

Pour lancer ce projet vous devez avoir 
* .Net core SDK install� sur votre ordinateur (pour ceux qui utilisent le CLI) ou visual 2022 � jour avec la version .net 7.
* dotnet ef install� globalement sur le poste d�veloppeur via cette commande : dotnet tool install --global dotnet-ef lire plus � ce sujet https://learn.microsoft.com/en-us/ef/core/get-started/overview/install

## Base de donn�es et donn�es initiales

commandes pour initialiser la base de donn�es.

* Pour le moment il faut cr�er la base de donn�es manuellement. Nom =SugarSharkStore
* Appliquer le script de migration : ___dotnet ef database update --project SugarShark.Infrastructure --startup-project SugarShark.Api___

#### Ceci n'est pas n�cessaire pour le lancement de l'application.

Au besoin si le mod�le change, il faut recr�er une migration : ___dotnet ef migrations add migrationName --project SugarShark.Infrastructure --startup-project SugarShark.Api___

#### Nota

Avec la pression dans mon travail je n'ai pas pu avancer comme je le souhaitais. Je continuerai � faire des petits commit ce weekend et apr�s si possible.

Merci.
