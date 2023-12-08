The Code-crusader bank is a group project for school. The program is coded in C# in .NET. It's a program that resembles a simple bank system.
There are seventeen different classes in our program.

These are all of our classes:
Our program has seventeen different classes;

Accounts:
This is a base/parent class where the users can create new bank accounts.

Checking accounts:
This is a subclass from 'Accounts'. It contains a method that create new accounts.

Create user:
A class where the admin can create new users for the program.

ExchangeRate:
A class where the admin can change the ExchangeRate

Loan:
A class for creating new loans.

Logo:
Shows the bank-logo.

Menu:
A class that writes out the menues. There's one seperate menu for the user and one for the admin.

PrintAccounts:
This class print the bank-accounts for the users.

Program:
Just calls the method StartBank()

RequestLoan:
In this class you request and execute bank-loans.

SavingAccounts:
This is also a subclass based on 'Accounts'. Here the user can open new Saving accounts.

Start:
This is a class that contains the already existing users and their bank-accounts.

Transfer:
In this class you manage the transfers between different accounts.

TransferLog:
A class for creating TransferLogs to save the transferhistory.

TransferUser:
Here you can transfer money to different users.

Users:
A class for creating new users.

UserContext:
This is a class that contains two static Users, one CurrentUsers and one TargetUser.


Starting the application: 

The first step when you start the program is the loginscreen: 
Here the user can choose wether to log in as an admin or a user! 
The user has 3 chances to log in to the application if its wrong the third time the application will close. 

If you log in as a user you get transported to the usermenu wich has the following choices: 

1. View Accounts
  Prints out all the current accounts for the logged in user
2. Transfer
   Lets the user transfer money between its own accounts
3. Transfer to another user
   Lets the user transfer money to another user that has accounts in the bank
4. Open a savingsaccount
   Lets the user open up a savings account, and gets the opportunity to choose the currency,
   And gets interestrate on the money they put in.
5. Open a checking account
    Lets the user open up a checking account, and gets the opportunity to choose the currency
6. Transfer history
    Shows all the logged transfers the user has made.
7. Loan request
    Lets the user request a loan thats not exceeds the amount of the users balance * five. 
8. Log out
    Logs out, and returns to the start page.
9. Exit the program
    Shuts down the program.

If you log in as an Admin you get transported to the AdminMenu wich has the following choices: 

1. Create new user
   Lets the Admin create a new user with unique username and password
2. Set exchangerates
   Lets the admin set the exchangerates for the current currencies
3. Log out
   Logs out, and returns to the start page.
4. Exit the program
   Shuts down the program.
