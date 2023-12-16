using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Data;
using System.Transactions;
namespace DataBasePrac
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
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";
            cn.Open();
            SqlTransaction t = cn.BeginTransaction(); // after now all the query by this connection cn will be required to run as a transaction


            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.Transaction = t;  // linking SqlCommand to the Transaction (If not linked and tried running throws error

            //cmdInsert.CommandText = "Insert into Employees values(@EmpNo,@Name,@Base,@DeptNo)";
            /// cmdInsert.CommandText = "Delete from Employees where EmpNo=@EmpNO";
            cmdInsert.CommandText = "Update Employees set Name=@Name where EmpNo=@EmpNo ";
            cmdInsert.Parameters.AddWithValue("@EmpNo", 2);
            cmdInsert.Parameters.AddWithValue("@Name", "J3");
 /*           cmdInsert.Parameters.AddWithValue("@DeptNo", 10);
            cmdInsert.Parameters.AddWithValue("@Base", 63340);*/

            /* SqlCommand cmdInsert2 = new SqlCommand();
             cmdInsert2.Connection = cn;
             cmdInsert2.CommandType = System.Data.CommandType.Text;
             cmdInsert2.Transaction = t;
             cmdInsert2.CommandText = "Insert into Departments values (@DeptNo,@Name)";
             cmdInsert2.Parameters.AddWithValue("DeptNo", 50);
             cmdInsert2.Parameters.AddWithValue("Name", "Finance");*/



            try
            {    
                /*cmdInsert2.ExecuteNonQuery();*/
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("succesfull");
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine(ex.ToString());
            }



        }

        public static void  Mars()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString= @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";
            cn.Open();
          //  SqlTransaction t = cn.BeginTransaction();  // ************ SqlTransaction 
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection= cn;
                //cmd.Transaction = t;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Departments";
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine(reader.GetString("Name"));
                    int deptNo = reader.GetInt32("DeptNo");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection= cn;
                  //  sqlCommand.Transaction = t;
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = "select * from Employees where DeptNo=@DeptNo";
                    sqlCommand.Parameters.AddWithValue("@DeptNo", deptNo);

                    SqlDataReader reader2 = cmd.ExecuteReader();
                    while(reader2.Read())
                    {
                        Console.WriteLine(reader2.GetString("Name"));
                    }
                    reader2.Close();
                }
                reader.Close();
                cn.Close();

               // t.Commit();
                Console.WriteLine("SuccessFull!!");
            }catch(Exception ex)
            {
               // t.Rollback();
                Console.WriteLine(ex.ToString());

            }
        }


        public static void DMLConnection()
        {
            SqlConnection cn = new SqlConnection();
            //  Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";
            try                   
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType=System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Employees values (@EmpNo,@Name,@Base,@DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo",1);
                cmd.Parameters.AddWithValue("@Name", "abhinav");
                cmd.Parameters.AddWithValue("@Base", 10000);
                cmd.Parameters.AddWithValue("@DeptNo", 10);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Successful");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static void SelectConnction()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";

            try
            {
                cn.Open ();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select Name,EmpNo,DeptNo from Employees where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", 1);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine(reader[0]);
                    Console.WriteLine(reader[1]);
                    Console.WriteLine(reader["Name"]);
                    Console.WriteLine(reader["DeptNo"]);
                }
            }catch(Exception ex)
            {
                  Console.WriteLine(ex.Message);
            }

        }



        public static SqlDataReader GetConnection()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";

          
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType= System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees";
                
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
          
        }


    }
}
