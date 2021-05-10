Farzana's Food CRUD App

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

I was able to test three of my controllers using XUnit Testing, each of which had a testing coverage of over 65%, as shown in the picture below.
![image](https://user-images.githubusercontent.com/70802911/117575158-7fe3eb80-b0d8-11eb-9d53-15a2ac5a5aea.png)
To be able to do the testing, I had to use repository patterning and mocking. I was able to complete 15 tests, which can also be seen in my pipeline:
![image](https://user-images.githubusercontent.com/70802911/117575362-56778f80-b0d9-11eb-944b-24ad5782f2db.png)


Project Tracking

Jira was used to track the progress of my project and allowed me to look at the different parts of the project so I knew what was needed to be done.

https://farzanaakter1.atlassian.net/secure/RapidBoard.jspa?rapidView=3&projectKey=RCA&selectedIssue=RCA-14&atlOrigin=eyJpIjoiZDMxMjYzMjlmMmIyNDg1ZmFlY2FhMjE3NjFlYzVhZDciLCJwIjoiaiJ9
![image](https://user-images.githubusercontent.com/70802911/117580000-9cd6e980-b0ed-11eb-97db-2a46fe9af953.png)
I added columns in my Jira board so that there was a column for each of the elements: project planning, coding, testing and deployment. Once I completed my tasks, I would move the tasks to the completed column. I also included a column with all the user stories.

Front End Design
I used ASP.Net and C# to create the front end designs. The user is able to open the app to the Home page which has links to the relevant tables. I used HTML to be able to do this in ASP.NET.

Risk Assessment
Screenshot of the risk assessment matrix is pictured below.
![image](https://user-images.githubusercontent.com/70802911/117617321-49ec4900-b164-11eb-9354-71c1a41cfc1a.png)


Improvements

- make the app more aesthetically pleasing by using Bootstrap in CSS
- ensure that the update and delete functions in my restaurant and recipe controllers functioned.
- do more tests so that all three of my controllers reached 100% coverage and test the Home controller.
- 
