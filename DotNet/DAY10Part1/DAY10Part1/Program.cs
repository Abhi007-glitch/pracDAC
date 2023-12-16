namespace DAY10Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        public class Employee
        {

        }
        public class EmployeeClient
        {
            private Employee emp;


            // Constructor based injection 
            public EmployeeClient(Employee emp) {

            }


            // Propertry based injection 
            public Employee Emp { get { return emp; }
                set
                {
                    emp= value;
                }
            }

            // Method based injection


            
        }
    }
}
