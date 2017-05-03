# Tinder
----
###

#### By Renee Mei

## Description

This website will match people

## Setup/Installation Requirements

##### Create Database and Tables
* In a command window:



```
* Requires DNU, DNX, MSSQL, and Mono
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

## Specifications

#### Cupcake Class
* The Equals method for the Band class will return true if the Band in local memory matches the Band pulled from the database.
  * Example Input:
> Local: "Green Day" , id is 1;
> Database: "Green Day" , id is 1;

  * Example Output: `true`

#### Cupcake Controller Class
* The Save method for the Band class will save new bands to the database.

* The Index method for the Band class will return all band entries in the database in the form of a list.

* The Edit method for the Band class will return the Band with the new band name and instructions.

* The Delete Confirmed method for the Band class will delete the band from the list of Band.

* The Search method for the Band class will return a list of Bands with matched name.



#### User Interface

### Sales Associate
* The user can sign in.

* The user can sell cupcakes using sale button which will increase their cupcake count and decrease cupcake inventory.

* The user can process a return which will decrease their cupcake count and increase the cupcake inventory

* The user can get all of their sales

* The user can add comments to their sales that only they can see

### Manager
* The user can sign in.

* The user can see all inventory and costs.

* The user can edit sales by sales associates

* The user can get all comments on sales

* The user can delete and edit sales associates

* The user can add new inventory

* The user can see balance sheet: revenue - costs = profit



## Support and contact details

Please contact Minh Phuong mphuong@kent.edu with any questions, concerns, or suggestions.


## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor
* MSSQL & SSMS

****

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 _**Minh Phuong, Nicholas Mead, Jiwon Kang**_
