using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Day5
{

    /// <summary>
    /// 
    ///  1) Predefinded Delegates - Action(void -return), Predicate(bool- return type), Func (any return type except void)
    ///  2) anonymus method and Lambda
    /// </summary>




    internal class Program
    {
        // *********************************** Predefined Delegates ******************************
        // action - > are function whose return type is void 
        //           Action o1 = Display;
        //           Action<String> o2 = Display;  // this action is delegate contating function having one single parameter of type String 

        // Func -> function those have return value 
        //          Func o1 = Sum;
        //          Func<int(IN),int(Out)> o2 = Sum;   // last one in <,,LastOne> -> lastOne is return type rest all are input parameter 

        // Predicate -> functions those have return type bool ( return type is fixed)
        // Predicate<int> predicate = IsEven;  <>-> only contain input parameter and return type is fixed as bool

        public static void Display(String s)
        {
            Console.WriteLine(s);
        }

        public static void Display(String s, int i)
        {
            Console.WriteLine(s, i);
        }

        public static int Add(int j, int i)
        {
            return j + i;
        }

        public static int Add()
        {
            return 0;
        }

        public static bool isEven(int j)
        {
            return (j % 2 == 0);
        }


        public static bool FilterEmplyee(Employee e)
        {



            return (e.basis > 10000);

        }

        public class Employee
        {
            public int basis;
            public Employee(int val)
            {
                basis = val;
            }

        }



        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Action<String> a1 = Display;
            a1("jatin");

            Action<String, int> a2 = Display;
            a2("Abhinav", 1);

            Func<int> f1 = Add;  // return type is int
            f1();

            Func<int, int, int> f2 = Add;  // takes two int as input and has return type int 
            Console.WriteLine(f2(10, 5));

            Employee e = new Employee(7000);
            Predicate<Employee> p1 = FilterEmplyee;
            Console.WriteLine(p1(e));



        }




        public static Action o1 = delegate ()
        {
            Console.WriteLine("Anonymus function got Called");
            //  allow one to use parent function's outer variable 
        };


        public static Func<int, int, int> add = delegate (int a, int b)
        {
            return a + b;
        };


        public static Func<int> addParentFunctionVar()
        {
            int a = 10;
            int b = 100;

            Func<int> add = delegate ()
            {

                Console.WriteLine(a + " " + b);
                a += 1;
                b += 1;
                return a + b;
            };


            return () =>
            {
                Console.WriteLine(a + " " + b);
                a += 1;
                b += 1;
                return a + b;
            };

            //return add;
        }


        public static Func<int> addGarandParaentVarFunction()
        {
            int a = 10;
            int b = 100;


            Func<int> parent()
            {
                int c = 1000;

                return () =>
                {
                    Console.WriteLine(a + " " + b + " " + c);
                    a += 1;
                    b += 1;
                    c += 1;
                    return a + b + c;
                };


            }

            /*Func<int> add = delegate ()
            {

                Console.WriteLine(a + " " + b);
                a += 1;
                b += 1;
                return a + b;
            };*/


            return parent();


            //return add;
        }









        public Func<int, int> lambdaExp = (a) => a * 2;

        static void Main2()
        {
            Func<int> temp = addGarandParaentVarFunction();
            for (int i = 0; i < 5; i++)
            {
                temp();
            }
        }


        public static void Main()
        {

        }
    }




}
