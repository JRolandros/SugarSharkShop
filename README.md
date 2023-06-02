# SugarSharkShop
For Maplr recrutment test - Backend for the Maplr suger shark brand

# Getting started

## Prerequis

Pour lancer ce projet vous devez avoir 
* .Net core SDK installé sur votre ordinateur (pour ceux qui utilisent le CLI) ou visual 2022 à jour avec la version .net 7.
* dotnet ef installé globalement sur le poste développeur via cette commande : dotnet tool install --global dotnet-ef lire plus à ce sujet https://learn.microsoft.com/en-us/ef/core/get-started/overview/install

## Base de données et données initiales

commandes pour initialiser la base de données.

* Pour le moment il faut créer la base de données manuellement. Nom =SugarSharkStore
* Appliquer le script de migration : ___dotnet ef database update --project SugarShark.Infrastructure --startup-project SugarShark.Api___

#### Ceci n'est pas nécessaire pour le lancement de l'application.

Au besoin si le modèle change, il faut recréer une migration : ___dotnet ef migrations add migrationName --project SugarShark.Infrastructure --startup-project SugarShark.Api___

#### Nota

Avec la pression dans mon travail je n'ai pas pu avancer comme je le souhaitais. Je continuerai à faire des petits commit ce weekend et après si possible.

Merci.
