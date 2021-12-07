# Guestbook
A guestbook system that logs users' messages and the ability to replies to it.

## How to run the project
* Check if .NET Core sdk version 3.1 installed on your system, you can download it from [Here](https://dotnet.microsoft.com/download/dotnet/3.1) then check if the instalation has gone correctly by typing
      
      $ dotnet --version
      $ 3.1.21
* Restore the dependencies by typing the commande
  
      $ dotnet restore
      
You should be able to publish the Guestbook.DB project using Visual Studio
you will then be prompt by window that you can select your `Target Database Connection` field then type your DB name and publish.
You should also grab your database connection string and add it to the appsettings.json file.
* Finally go and run the app by typing

      $ dotnet run --project Guestbook.Web

### Done
* Authentification
* Authorization
* Registration
* Writing Messages
* Deleting Messages
* Editing Messages
* Writing Replies to Messages
* Deleting Replies
### Todo
* Ability to change own avatar and cover
* Select picture from local files
* Add two factor authentification
* Password recovery
