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
I have created an Entity Relationship Diagram below that showsthe relationship between my tables in the relational database:
![image](https://user-images.githubusercontent.com/70802911/117570224-27edba80-b0c1-11eb-8580-d6a56ce99550.png)

