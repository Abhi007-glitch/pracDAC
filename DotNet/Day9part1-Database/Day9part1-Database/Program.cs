using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;

namespace Day9part1_Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Transactions();

        }


        static void Transactions()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;";
            cn.Open();
            SqlTransaction t = cn.BeginTransaction(); // after now all the query by this connection cn will be required to run as a transaction


            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text; 
            cmdInsert.Transaction = t;  // linking SqlCommand to the Transaction (If not linked and tried running throws error

            cmdInsert.CommandText = "Insert into Employees values(@EmpNo,@Name,@DeptNo,@Basic)";
            cmdInsert.Parameters.AddWithValue("@EmpNo", 9);
            cmdInsert.Parameters.AddWithValue("@Name", "J3");
            cmdInsert.Parameters.AddWithValue("@DeptNo",10 );
            cmdInsert.Parameters.AddWithValue("@Basic", 6334540);

           /* SqlCommand cmdInsert2 = new SqlCommand();
            cmdInsert2.Connection = cn;
            cmdInsert2.CommandType = System.Data.CommandType.Text;
            cmdInsert2.Transaction = t;
            cmdInsert2.CommandText = "Insert into Departments values (@DeptNo,@Name)";
            cmdInsert2.Parameters.AddWithValue("DeptNo",90);
            cmdInsert2.Parameters.AddWithValue("Name", "Finance");*/



            try
            {
               /* cmdInsert2.ExecuteNonQuery();*/
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("succesfull");
            }
            catch (Exception ex)
            {
                   Console.WriteLine(ex.ToString());    
            }
            


        }





        static void DataReader() // fetching multiple values 
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;";
            //(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;

            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text; // CommandType - text (For running SQL query)
                // cmdInsert.CommandText = "Insert into Employees values(3,'abhinav',12345,30)";
                // Update Table Employees Set Employees.EmpNo=10, Employees.name='yatin',Employees.Basic=24445,Employees.DeptNo=30 where Employee.EmpNo=3"
                // instead of string concatination (prone to SQL injection) we use this syntax using parameter
                
                cmdInsert.CommandText = "Select * from Employees; Select * from Departments";   //***********RUNNING Multiple Query ***********

                /// "select * from Employees" return a sinlge value (1st row, 1st col) as we are executing using ExecuteSclar()
              
                


                SqlDataReader dr = cmdInsert.ExecuteReader(); // opens datareader (readonly ,unidirectional)

              //  dr.Read(); // read the first record (return boolean true- if read successfully )
               // dr[0];// read the first col of the record -> as Object type
                //dr["Name"];  // read the value by matching column name


                while(dr.Read())
                {
                    Console.Write(dr[1]+" ");  // dr[1]  -> return a object (need to type cast when want to store in variable
                    Console.Write(dr["Name"]+ " ");
                    Console.WriteLine(dr.GetString(1));// dr.GetString(1) returns a String value no need to type cast seprately 
                }

             if ( dr.NextResult())    // runNext Command if present
                {
                    while (dr.Read())
                    {
                        Console.Write(dr[0] + " ");
                        Console.WriteLine(dr[1]);
                    }
                }
                
                dr.Close();


                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }


        static SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;";

                cn.Open();
                SqlCommand cmdGet = new SqlCommand();
                cmdGet.Connection = cn;
                cmdGet.CommandType = System.Data.CommandType.Text;
                cmdGet.CommandText = "Select * from Employees";
                SqlDataReader dr = cmdGet.ExecuteReader(CommandBehavior.CloseConnection); // ********* will get close conncetion as soon as the reader closes
            return dr;
                
          
        }
        static void SelectSingleValue()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;";
            //(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;

            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                // cmdInsert.CommandText = "Insert into Employees values(3,'abhinav',12345,30)";
                // Update Table Employees Set Employees.EmpNo=10, Employees.name='yatin',Employees.Basic=24445,Employees.DeptNo=30 where Employee.EmpNo=3"
                // instead of string concatination (prone to SQL injection) we use this syntax using parameter
                cmdInsert.CommandText = "Select Name from Employees where EMpNo=3";
                  /// "select * from Employees" return a sinlge value (1st row, 1st col) as we are executing using ExecuteSclar()
                Object retval = cmdInsert.ExecuteScalar(); // return a single value (specfic records secific column value)
                Console.WriteLine(retval.ToString());  
      
                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }

        static void Connect1DML()
        {
            //(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;";
            //(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;

           try
            {
                cn.Open();
                
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                // cmdInsert.CommandText = "Insert into Employees values(3,'abhinav',12345,30)";
                                        // Update Table Employees Set Employees.EmpNo=10, Employees.name='yatin',Employees.Basic=24445,Employees.DeptNo=30 where Employee.EmpNo=3"
                // instead of string concatination (prone to SQL injection) we use this syntax using parameter
                cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", 11);
                cmdInsert.Parameters.AddWithValue("@Name", "jatin");
                cmdInsert.Parameters.AddWithValue("@Basic", 45651);
                cmdInsert.Parameters.AddWithValue("@DeptNo", 30);


                cmdInsert.ExecuteNonQuery(); // returns no of records affected
                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }

        // *************** PRACTICALLY VERY USEFUll for running Complex query in simplify manner************
        // FOR running mutiple nested Query using multiple dataReader for multiple Query
        // Add  multipleActiveResultSet  to  _>@"Data Source=(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;";


        static void Connect2DML()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;";
            //(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;

            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertEmployee";
                // cmdInsert.CommandText = "Insert into Employees values(3,'abhinav',12345,30)";

                // instead of string concatination (prone to SQL injection) we use this syntax using parameter(also take care of adding special chara)
                //cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
                                          
                cmdInsert.Parameters.AddWithValue("@EmpNo", 11);
                cmdInsert.Parameters.AddWithValue("@Name", "jatin");
                cmdInsert.Parameters.AddWithValue("@Basic", 45651);
                cmdInsert.Parameters.AddWithValue("@DeptNo", 30);


                cmdInsert.ExecuteNonQuery(); // returns no of records affected
                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }


        }
        static void Connection()
        {

            using(SqlConnection cn = new SqlConnection(@"(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;"))
            {
                cn.Open();
                Console.WriteLine("Success");
            }


        }


        static void AsyncConnCode()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = " ";
            Task t = cn.OpenAsync();
            // do some other tasks;


            if(!t.IsCompleted)
            {
           
                t.Wait();
            }

            cn.Close();
        }

        static async void AsyncConnCode2()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = " ";
            await cn.OpenAsync();

            await cn.CloseAsync();


        }


        static async void AsyncDML()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = " ";
            await cn.OpenAsync();

            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                // cmdInsert.CommandText = "Insert into Employees values(3,'abhinav',12345,30)";
                // Update Table Employees Set Employees.EmpNo=10, Employees.name='yatin',Employees.Basic=24445,Employees.DeptNo=30 where Employee.EmpNo=3"
                // instead of string concatination (prone to SQL injection) we use this syntax using parameter
                cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", 13);
                cmdInsert.Parameters.AddWithValue("@Name", "j3");
                cmdInsert.Parameters.AddWithValue("@Basic", 45651);
                cmdInsert.Parameters.AddWithValue("@DeptNo", 30);
                

                await cmdInsert.ExecuteNonQueryAsync(); // returns no of records affected
                Console.WriteLine("Success");
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.Message);
            }

            await cn.CloseAsync();
        }


        static async void ASyncSElect()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;";
            //(localdb)\ProjectModels; Initial Catalog = ActsDec2023; Integrated Security = True;

            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "Select * from Employees ";

                //  cmdInsert.BeginExecuteReader(callbackFunc, stateObject);
                // reading data in callback as it's a async read call
                cmdInsert.BeginExecuteReader((IAsyncResult ar) =>
                {
                    SqlDataReader dr = cmdInsert.EndExecuteReader(ar); // accessing cmdInset inside this delegate function we defined this function as anonymus function
                    while(dr.Read())
                    {
                        Console.WriteLine(dr["Name"]);
                    }
                    dr.Close();
                    
                },null);

                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }
    }
}
