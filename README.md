The Code-crusader bank is a group project for school. The program is coded in C# in .NET. It's a program that resembles a simple bank system.
There are seventeen different classes in our program.

Classes:
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


