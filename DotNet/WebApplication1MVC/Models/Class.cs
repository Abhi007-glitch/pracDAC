using Microsoft.Data.SqlClient;

namespace WebApplication1MVC.Models
{
    public class Employees
    {
        public int EmpNo { get; set; }
        public String Name { get; set; }

        public decimal Base { get; set; }
        public int DeptNo { get; set; }

        public static void AddEmployee(Employees e)
        {
            SqlConnection cn = new SqlConnection();
            //  Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Employees values (@EmpNo,@Name,@Base,@DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo", e.EmpNo);
                cmd.Parameters.AddWithValue("@Name", e.Name);
                cmd.Parameters.AddWithValue("@Base", e.Base);
                cmd.Parameters.AddWithValue("@DeptNo", e.DeptNo);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateEmployee(Employees e)
        {
            SqlConnection cn = new SqlConnection();
            //  Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                //   cmd.CommandText = "Insert into Employees values (@EmpNo,@Name,@Base,@DeptNo)";
                cmd.CommandText = "Update Employees Set  Name=@Name, Base=@Base, DeptNo=@DeptNo where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", e.EmpNo);
                cmd.Parameters.AddWithValue("@Name", e.Name);
                cmd.Parameters.AddWithValue("@Base", e.Base);
                cmd.Parameters.AddWithValue("@DeptNo", e.DeptNo);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


        public static void DeleteEmployee(int id)
        {
            SqlConnection cn = new SqlConnection();
            //  Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                //   cmd.CommandText = "Insert into Employees values (@EmpNo,@Name,@Base,@DeptNo)";
                cmd.CommandText = "Delete Employees where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", id);
               
                cmd.ExecuteNonQuery();

                Console.WriteLine("Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


        public static Employees GetEmployee(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";
            Employees empl=new Employees();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    empl.Name =(String) reader["Name"];
                    empl.DeptNo = (int)reader["DeptNo"];
                    empl.EmpNo = (int)reader["EmpNo"];
                    empl.Base = (decimal)reader["Base"];

                }
                return empl;
            }
            catch (Exception )
            {
                throw;
            }

        }


        public static List<Employees> GetALLEmployees() { 
        List<Employees> empList = new List<Employees>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsBatch23; Integrated Security = True;";
            
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees ";
                cmd.Parameters.AddWithValue("@EmpNo", 1);
                SqlDataReader reader = cmd.ExecuteReader();
                Employees empl;
                while (reader.Read())
                {    empl = new Employees();
                    empl.Name = (String)reader["Name"];
                    empl.DeptNo = (int)reader["DeptNo"];
                    empl.EmpNo = (int)reader["EmpNo"];
                    empl.Base = (decimal)reader["Base"];
                    empList.Add(empl);
                }
                return empList;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

   







}
