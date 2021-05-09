# ProjectCRUDApp

Brief
The brief provided to us for this project sets the following out as its overall objective: "To create a CRUD application with utilisation of supporting tools, methodologies and technologies that encapsulate all core modules covered during training."

This means that I must create a functional CRUD web application in ASP.Net using C# and test the code I produce. I must also produce a functional Azure DevOps pipeline that will deploy my code.

My web application

I have produced a CRUD web application to store information about my favourite foods. This means that I will be able to create, read, update and delete any entries of food. There is also a table for creating recipes relating to each foods as well as data about restaurants that sell that particular type of food. 
My food web application allows users to:

Create posts of foods that they enjoy that stores:
- the food name
- food cuisine
- description of the food
- a picture of the food
- date and time of when the post was made

Create posts of recipes for each food that has been produced.This stores data about:
- the recipe name
- the ingredients needed for the recipe
- the method of the recipe
- a picture of the food created as a result of following the recipe
- the number of servings
- the level of difficulty 
- date and time of when the post was made

Create posts of the restaurants that sell each of the food that the user has produced. This stores information about:
- the restaurant name
- the location of the restaurant
- the name of the specific dish related to the food post
- whether the restaurant offers a delivery option
- what you would potentially rate that restaurant
- date and time of when the post was made

Users are also able to read each post, update each post and delete the post if they wish.

Architecture

Database structure
I have created an Entity Relationship Diagram below that shows the relationship between my tables in the relational database:

![image](https://user-images.githubusercontent.com/70802911/117570224-27edba80-b0c1-11eb-8580-d6a56ce99550.png)

This shows that there is a one to many relationship between the Food table and the Recipe table as well as another one to mant relationship between the Food table and the Restaurant table. This means that the user is able to create many recipe posts and restaurant posts for every one food post.

CI Pipeline
To be able to deploy my web application on Azure App Service, I create a pipeline in Azure DevOps. This required me to create a virtual machine in Linux as well as a build agent to implement into the pipeline so that my pipeline was successfully built. 
I added three stages to my pipeline:
- Build - this will be the stage in which the application is compiled.
- Deploy - this will put application on web server so that it can be used on the internet (in this case, through Azure App Service)
- Test - this stage will run any Unit Testing which will validate that the code will perform as expected.
![image](https://user-images.githubusercontent.com/70802911/117572535-38a32e00-b0cb-11eb-9e42-bd3a76c3d3e8.png)
![image](https://user-images.githubusercontent.com/70802911/117574453-10203180-b0d5-11eb-91af-adf5bb030ed8.png)

Although all three of my stages were successfully implemented, I was unable to access my app through the Azure Web App and unable to deploy my app through the Pipeline completely. This meant that I had to deploy the app manually through Azure App Service in the Azure Portal.


Testing


