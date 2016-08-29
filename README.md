# WebAPI_PersonsApp

This is a MVC application where the API functionality has only been used so far. 
This is the application that the XamarinForms_Persons_App_Demo uses for its webservice. 

Intresting points:
  1. WebApiConfig is configured to return json, see comment in said file.
  2. PersonController is the controller responsible for the API
  3. Data folder holds all the code that communicates with the database.
  4. In MySql folder you will also find a sql file to set up the database, you can import this file to your mysql database and get up and running quickly.
  5. You will have to add your own database connection in: WebAPI_XamarinDemo/Data/PersonData.cs
