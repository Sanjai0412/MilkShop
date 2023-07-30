# MilkShop
## PROJECT OVERVIEW:
The Milk Price Calculator aims to buy milk and calculate total amount and store the user's detail and their bill.

## SCOPE:
The Milk Price Calculator will focus on the following key features:
- User registration - If User wants to login ,they must have an existing account.Otherwise they should sign in first.
- Milk catalog with details and Time span - Each Milk type and Brand have individual price. 
- Provide Extra Milk and Skip that day option - The user logged in before the ending date, they can able to skip or buy extra milk for that day. If the user logged in after the ending date, this options does'nt show.
- Generate Bill to Every User - Generating bill from starting date to ending date. If user logged in before the ending date, the date which was logged in is considered as ending date (or) logged in after the ending date, bill will generate till ending date only. 

## CLASSES USED :
There are Five classes used in this project,they are:
- UserDetail (Parent class) -This class is a parent class , It contains all the data from child classes.
- UserData (child class) -It contains User name, User Id, Email, Address from user.
- MilkPreference (child class) -It contains Time Period, Starting Date, Pack Type, Brand Name, Milk Type, Quantity from user.
- BillStructure (child class) -It contains list<BillStructure> to store the bill.
- Total (child class) -It contains total amount for an User bill.

## FUNCTIONS USED :
There are seven functions used in this project,they are:

- QuanPrice - To calculate Price for milk quantity.
- "MilkTypePrice" - To set price for different type of milk.
- "BrandPrice" - To set milk price for various brands.
- "CreateDirectory" - To create folder by an given path(C:\\MilkPrice).
- "checkUserId" - To check the user id if already exists or Not.
- "CreateTextFile" - To create text file using user id.
- "UpdateTextFile" - To Update Bill to an existing file.

Milk Shopping Application using WinForms
