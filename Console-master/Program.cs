/* 
    Employee Application
   Description : An Application to create an application where we can add the employee details,then we can read a specific employee details whose we want to see 
                 the allows user to update the partricular employee detail and if we wish,we the delete the particular record
   Date of Creation: 20.10.2021
   Author : Yoga
   Modified on : 18.11.2021 TIME : 3 pm
   Reviewed by : Jaya and Akshaya */

using System;                                                                      
using System.Collections.Generic;
using System.Data.SqlClient;                                                                                 //This namespace is used as a data provider for SQL server
using System.Linq;
using System.Text.RegularExpressions;                                                                        // this NAmespace is used for regular expression to define a default pattern
using System.Threading.Tasks;                                                                                 // This namespace is used for the App.Config

namespace EmployeeManagementSystem
{
    class EmployeeDetails                                                                                           // EmployeeManagement class is used to create employee Application 
    {
        public static string connectionString;
        public static void AddEmployeeDetails()                                                                         //AddEmployeeDetails() method to check and add the employee details as many as we want
        {

            try 
            {
                string connectionString = @"Data Source=.;Initial Catalog=EmployeeDetails;Integrated Security=True";      //Storing the Database in configuration file.
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string GetName="", GetID="", GetEmail="", GetMobileNumber="";                                          // declaring the variables to get name,id,emailid,mobileNumber as null
                DateTime? GetDateOfBirth = null;                                                                       // declare gateofbirth as null
                DateTime? GetDateOfJoin = null;                                                                       // declare dateofjoin as null
                DateTime CopyDate, CurrentDate = DateTime.Today;                                                      // declaring copydate and assigning current date as today's date
                int NumberOfEmployees, Return = 0, Age = 0;                                                           //Declaring NumberOfEmployee,age,return
                string NameDefaultPattern, IdDefaultPattern, EmailDefaultPattern, DateDefaultPattern, MobileNumberDefaultPattern;
                NameDefaultPattern = @"([A-Z]*[a-z])\1\1+";                                             
                IdDefaultPattern = @"^ACE[0-9]{4}$";
                EmailDefaultPattern = @"^[a-z0-9.&%#]{1,20}@[a-z]{1,10}.[a-z.]{1,8}$";
                DateDefaultPattern = @"3[01]|[12][0-9]|0?[1-9]/0[1-9]|1[0-2]/(\d){4}";
                MobileNumberDefaultPattern = @"^[6789][0-9]{9}$";
                                                                                                                     // Declaring and defining Default patterns for name,id,email,date,mobilenumber.
                Console.WriteLine("How many employee do you want to add"); 
                NumberOfEmployees = Convert.ToInt32(Console.ReadLine());                                           // user input to how many employee details do the user want to add
                while (NumberOfEmployees > 0)                                                                      // To the the employee details for all the employees we use while loop
                {
                    while (Return == 0)                                                                            // this while loop to used to continue the loop if the condition in the if condition fails
                    {
                        Console.WriteLine("Enter Employee Name Whose First letter should be Upper :");  
                        GetName = Console.ReadLine();                                                               // To get the Employee's name from user
                        if (Regex.IsMatch(GetName, NameDefaultPattern))                                            // Compares the user input of employee's name with the default name pattern and if it doesn't match,then enters the if block and continues the loop
                        {
                            Console.WriteLine("Please! Enter a Valid name where only the first letter should be in uppercase and should no have repeated words more than 2...");
                            continue;                                                                               // continue satement will takes the compiler to skip that current loop and continue the next loop
                        }
                        break;                                                                                      // this will get executed when the if condition fails ie user input and default pattern matches, then if we use break it will break the loop.
                    }

                    while (Return == 0)
                    {
                        Console.WriteLine("Enter Employee ID which should start with ACE followed by 4digits :");
                        GetID = Console.ReadLine();                                                                 // to get employee id from the user

                        if (!Regex.IsMatch(GetID, IdDefaultPattern))                                                // Compares theuser's input of Employee id and Id's default pattern and if doesnt match,it will go inside if block 
                        {
                            Console.WriteLine("Please! Enter a Valid Id like ACE followed by 4 digits eg:ACE1234...");
                            continue;                                                                              // continue to skip the current loop iteration and skip to next iteration
                        }
                        break;                                                                                     // Break the loop as  this statement will gets executed ehen the user input and default part is same

                    }
                    while (Return == 0)
                    {
                        Console.WriteLine("Enter your email id where all should be in lower case :");
                        GetEmail = Console.ReadLine();                                                              // to get the Email id from the user
                        if (!Regex.IsMatch(GetEmail, EmailDefaultPattern))                                          //checks whether the email id given by the user and the default pattern satisfy the condition 
                        {
                            Console.WriteLine("Please! Enter a Valid Email where all letters should be in lower and domain name should not contain any numerics...");
                            continue;                                                                               // To continue the next loop 
                        }
                        break;                                                                                      // to exit the loop
                    }

                    while (Return == 0)
                    {
                        Console.WriteLine("Enter your mobile number which should be of 10 digits :");
                        GetMobileNumber = Console.ReadLine();                                                       //  to get the mobile number from the user
                        if (!Regex.IsMatch(GetMobileNumber, MobileNumberDefaultPattern))                            //using if condition to check whether the user given mobile number and the default mobile number pattern matches or not
                        {
                            Console.WriteLine("Please! Enter a Valid MobileNumber which should start with 6 or 7 or 8 or 9 and should not contains the same digits all over...");
                            continue;
                        }
                        break;
                    }

                    while (Return == 0)
                    {
                        Console.WriteLine("Enter your Date of Birth in the format of dd/mm/yyyy :");
                        string dateofbirth = Console.ReadLine();                                                                                 //gets date of birth from the user in the string format
                        GetDateOfBirth = DateTime.Parse(dateofbirth, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);   // Converts the string date to Datetime type
                        CopyDate = Convert.ToDateTime(GetDateOfBirth);                                                                           // Copy's the user,s date into another variable
                        Age = CurrentDate.Year - CopyDate.Year;                                                                                  // Calculates the Age of the person using the CurrentDAte and date of birth
                        if ((Age < 18) || (Age > 60) || (!Regex.IsMatch(dateofbirth, DateDefaultPattern)))                                      // here giving the condition as the employee should be greater than 21 years and less than 65 years old
                        {
                            Console.WriteLine("Please! Enter a Valid DOB in the format of DD/MM/YYYY and age should be between 21 and 65...");
                            continue;
                        }
                        break;
                    }
                    while (Return == 0)
                    {
                        Console.WriteLine("Enter your Date of Join in the format of dd/mm/yyyy :");
                        string dateofjoin = Console.ReadLine();                                                              // Get the Date of join of the employee in string format
                        GetDateOfJoin = Convert.ToDateTime(dateofjoin, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                        if (Age < 18 && Age > 60 || Regex.IsMatch(dateofjoin, DateDefaultPattern) || GetDateOfJoin <= CurrentDate || GetDateOfJoin >= GetDateOfBirth)// Conditions for date of join
                        {
                            break;
                        }
                        Console.WriteLine("Please! Enter a Valid DOB in the format of DD/MM/YYYY " +
                            "and age should be between 21 and 65 and Date of join should not exceed current date...");
                        continue;
                    }
                    string insertQuery = "Insert into EmployeeofficialInformation(EmployeeName,EmployeeId," +
                        "EmailId,MobileNumber,Dateofbirth,Dateofjoin) values('" + GetName + "','" +GetID + "','" + GetEmail + "'," +
                        "'" +GetMobileNumber + "','" + GetDateOfBirth + "','" + GetDateOfJoin + "')";                // SQl Query to insert all the details in to the table named EmployeeOfficialInformation
                    SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);                           // SQL Command object to execute the Query
                    insertCommand.ExecuteNonQuery();                                                                 // Execute Non Query is used as it does not return any value to the user. 
                    Console.WriteLine("Data is successfully inserted");                                             // to identify the insertion has successfully done or not ..given an output statement
                    NumberOfEmployees--;                                                                            // decrements the employee count 
                }
                sqlConnection.Close();                                                                             //closes the sql connection
                FirstMessage();                                                                                     //Returns to firstoutput function.
                
            }
            catch(Exception exception)                                                                                   // Catch block will gets executed when the exception occurs
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);                                                          // Gives the exception message
            }
            
        }
        public static void ReadSpecificEmployee()                                                          // ReadspecificEmployee() method is used to display the particular persons details
        {
            
            try
            {
                string connectionString = @"Data Source=.;Initial Catalog=EmployeeDetails;Integrated Security=True"; 
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Enter the Employee id whose details need to be displayed");                                 //Establishes connection with the table

                string display_employeeid;                                                                                              //declared a variable to get the input employee id whose details need to be displayed
                display_employeeid = Console.ReadLine();                                                                                //gets the employee id from user
                string display_query = "Select * from EmployeeOfficialInformation where EmployeeId='" + display_employeeid + "'";       //Sql query to get information
                SqlCommand displayCommand = new SqlCommand(display_query, sqlConnection);                                      //SQL command to execute the query
                SqlDataReader dataReader = displayCommand.ExecuteReader();                                                   // DAtareader is used to read the data from the table and Execute reader is used as we need to read the data from the table and has to display it.
                while (dataReader.Read()) 
                {
                    Console.WriteLine("Name : " + dataReader.GetValue(0).ToString());                                          // to set the record 0 value as name
                    Console.WriteLine("Employee id : " + dataReader.GetValue(1).ToString());                                  // To set the record 1 of the particular emp as Employee id
                    Console.WriteLine("Email id : " + dataReader.GetValue(2).ToString());                                    //too set record 2 as Email id
                    Console.WriteLine("Mobile Number : " + dataReader.GetValue(3).ToString());                               // to set record 3 as Mobile number
                    Console.WriteLine("Date of birth : " + dataReader.GetValue(4).ToString());                               // to set record 4 dateof birth value
                    Console.WriteLine("Date of join : " + dataReader.GetValue(5).ToString());                               //to set the record 5 value as date of join
                    Console.WriteLine("\n\n");
                }
                dataReader.Close();                                                                                      // Close the datareader
                sqlConnection.Close();                                                                                   // Close the sql connection
                FirstMessage();

            }
            catch (Exception exception)                                                                                        // if the try block in ReadSpecificEmployeeDetail() returns exception catch block will get executed
            {
                Console.WriteLine(exception.Message);
            }
            
        }
        public static void UpdateEmployeeDetail()                                                                  // UpdateEmployeeDetail() method to make changes to the existing record
        {
            
            try
            {
                string connectionString = @"Data Source=.;Initial Catalog=EmployeeDetails;Integrated Security=True";    //here the data base is connected to our Console Application using ConnectionString
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection Established");                                                      // connection to database is established
                String update_employeeid, update_Mobilenumber;                                                                   //temporary variables are declared
                Console.WriteLine("Enter the Employee id whose mobile number need to be changed");
                update_employeeid = Console.ReadLine();                                                                     //gets the employee id whose mobile number needs to be changed
                Console.WriteLine("Enter the mobile number that need to be changed");
                update_Mobilenumber = Console.ReadLine();                                                              // the alternate mobile number to be reflected on the table
                string updateQuery = "Update EmployeeOfficialInformation Set MobileNumber='" + update_Mobilenumber + "' where EmployeeId='" + update_employeeid + "'"; // Sql query to do update
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();                                                                  // sql command to execturte the query
                Console.WriteLine("Data Updated successfully");
                sqlConnection.Close();                                                                            // closes sql connection
                FirstMessage();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public static void DisplayDetails()                                                                     // DisplayDetails(0 method to display all records which are in the table
        {
            

            try
            {
                string connectionString = @"Data Source=.;Initial Catalog=EmployeeDetails;Integrated Security=True";              //here the data base is connected to our Console Application using ConnectionString
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                                                                                                                   // Sql Connection for database is established
                string DisplayQuery = "Select * from EmployeeOfficialInformation";                                 // SQL query to dispaly all records
                SqlCommand displayCommand = new SqlCommand(DisplayQuery, sqlConnection);
                SqlDataReader dataReader = displayCommand.ExecuteReader();                                         //SqlDataReader is used as we are going to fetch data from the table and display it
                while (dataReader.Read())                                                                          // executes the loop untill the records all are displayed
                {
                    Console.WriteLine("Name : " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("Employee id : " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("Email id : " + dataReader.GetValue(2).ToString());
                    Console.WriteLine("Mobile Number : " + dataReader.GetValue(3).ToString());
                    Console.WriteLine("Date of birth : " + dataReader.GetValue(4).ToString());
                    Console.WriteLine("Date of join : " + dataReader.GetValue(5).ToString());
                    Console.WriteLine("\n\n");
                }
                dataReader.Close();                                                                              // closes data reader
                sqlConnection.Close();                                                                           //closes sql connection
                FirstMessage();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public static void DeleteEmployeeDetail()
        {
            
            try
            {
                string connectionString = @"Data Source=.;Initial Catalog=EmployeeDetails;Integrated Security=True";             //here the data base is connected to our Console Application using ConnectionString
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                                                                                                   // Connection with the table ina database has been established by the above code
                string delete_employeeid;                                                                     // Declaration of avariable which will get the user whose employeeid details need to be deleted
                Console.WriteLine("Enter the Employeeid whose data need to be removed");
                delete_employeeid = Console.ReadLine();
                string deletequery = "Delete from EmployeeOfficialInformation where EmployeeId='" + delete_employeeid + "'";      //query to delete the specific employee details
                SqlCommand deleteCommand = new SqlCommand(deletequery, sqlConnection);                // command to execute the query
                deleteCommand.ExecuteNonQuery();                                                    //ExecuteNonQuery is used as it will change the database table but not return any infirmation
                Console.WriteLine("Deletion is successfully done");
                sqlConnection.Close();                                                              // Clos ethe connnection with the table
                FirstMessage();                                                                      //Again calling the FirstOutput function
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public static void ExitAll()                                                                 // ExitAll() method which will terminates the program.
        {
            Console.WriteLine("End of the Application...\n press Any key to end the program");
        }

        public static void FirstMessage()                                                                // FirstOutput method is used to get the user's choice and to direct the compiler to specific method 
        {
            Console.WriteLine("\n\t Employee Management System \n\n");                                    //Title
            Console.WriteLine("1. Add Employee Details");                                                // if the user need to add an employee detail into the table then need to press 1
            Console.WriteLine("2.Read a specific employee");                                            //to read a specific employee detail then press 2
            Console.WriteLine("3.Update employee details");                                             // to update an employee information then press 3
            Console.WriteLine("4.Display employee details");                                            // to display all details press 4
            Console.WriteLine("5.Delete the employee detail");                                          // to delete a specific record press 5
            Console.WriteLine("6.Exit");                                                                 //to exit theprogramm press 6
            Console.WriteLine("Please Enter a valid choice between 1 and 6");
            SelectChoice();

        }
        public static void SelectChoice()
        {
            int index;
            
            
            index = Int32.Parse(Console.ReadLine());                                                      // to get the input from user as a int
            switch(index)                                                                             //switch case is used to  perform the specific function which is expected by the user
            {
                case 1:   
                    AddEmployeeDetails();                                                            // when the user gives 1 as input then it will call AddEmployeeDetails() fuction to execute
                    break;
                case 2:
                    ReadSpecificEmployee();                                                          // when the user gives 2 as input then it will call ReadSpecificEmployee() fuction to execute
                    break;
                case 3:
                    UpdateEmployeeDetail();                                                         // when the user gives 3 as input then it will call UpdateEmployeedetail() fuction to execute
                    break;
                case 4:
                    DisplayDetails();                                                              // when the user gives 4 as input then it will call DisplayDetails() fuction to execute
                    break;
                case 5:
                    DeleteEmployeeDetail();                                                       // when the user gives 5 as input then it will call DeleteEmployeeDetail() fuction to execute
                    break;
                case 6:
                    ExitAll();                                                                   // when the user gives 6 as input then it will call ExitAll() fuction to execute
                    break;
                default:
                    Console.WriteLine("Please Enter a valid Index which should be between 1 to 6");              // printd an error message when the user gives the input which is greater the 6
                    SelectChoice();
                    break;
            }
        }
        public static void Main(string[] args)                                                  // Main function where the program first starts its execution 
        {
            FirstMessage();                                                                     // calling a method named FirstOutput
            Console.ReadKey(); 
        }
    }
}
