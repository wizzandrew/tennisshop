# Tennis-shop  Web App

![image](https://github.com/wizzandrew/tennisshop/assets/43003757/6ca2b300-29e7-4c21-ba8f-e4662d468b47)

## Under development still 🙃💪🚀...

The scope of this project is to build a ligtweight e-commerce web app. 

It consumes internal .NET web service via ``` fetch ``` and provides shop items.

The frontend stack consists of ```HTML5```, ```SCSS```, ```Bootstrap 5```, ```Vue.js``` technologies and backend is built with ```C# ```.

## Features

* Provides tennis items such as Rackets, Clothing, Shoes, Accessories(bags, strings, balls).

* Sort tennis items, for example "Most popular", "Low-to-high price".

* Filter tennis items, for example by Brand, Price Range.

* Fill up shopping cart and proceed to place an order.

* User account with order history.

## Installation

1. Make sure you have Node.js, .NET installed and VS Code IDE preferably

2. Clone this repository ``` https://github.com/wizzandrew/tennisshop.git ```

3. Navigate to folder ```tennisshop-main/tennisshopapi ```  

4. Open terminal and make sure it is opened in the folder ```tennisshop-main/tennisshopapi ```

5. Restore .NET dependencies with  ``` dotnet restore ```

6. Build migration with ```dotnet ef migrations add InitialCreate```

7. Save changes to database ```dotnet ef database update```

8. Seed data and run .NET ```dotnet run seeddata``` NB: Later run .NET with ```dotnet run```

9. Navigate to folder ```tennisshop-main/vueclient ``` 

10. Open terminal and make sure it is opened in the folder ```tennisshop-main/vueclient ```

11. Install npm modules with ```npm i```

12. Run app with ``` npm run dev ```

13. The app is running at ``` http://127.0.0.1:5173/ ```

## Credits

App's layout and design heavily influenced by Tennis-point. A lot of images belong there ``` https://global.tennis-point.com/ ```
