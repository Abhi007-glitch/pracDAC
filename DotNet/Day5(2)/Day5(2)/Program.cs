namespace Day5_2_
{


    /// <summary>
    /// 
    /// A)Exceptuonal Handing with it's hierachy
    /// B)Event -> with clear seppration between developer and tester work!!
    /// 
    /// C) Language Features:
    ///    1) Anonymus class 
    ///    2) Partial class
    ///    3) Partial Method ( a placeholder which may or may not satisf- always return inside a partial classs )
    ///    4) Extension Method ( read the implementation --> NEW CONCEPT MUST READ )
    ///      
    /// 
    /// </summary>

    internal class Program
    {
        // excepional Handling
        static void Main1(string[] args)
        {

            try
            {
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine(100 / x);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured : " + e.Message);
            }

        }

        // **************************** Event -> a delegate whose only reference is defined inside the class and it's value(function->what to do if some condtion satisfy) is defined by the object creator of that class ****************
        // step 1; Create a delegate class having a same signature as the event
        // NOte : All events have return type of void
        //step 2 : Delcare a event of the delegate type 



       // step 1; Create a delegate class having a same signature as the event
        public delegate void Del1(int inValidVal);



        public class Class1    // develper logic
        {
            private int p1;

            //step 2)  Delcare a event of the delegate type 
            public event Del1? InvalidP1;
            public int P1
            {
                get
                {
                    return p1;
                }
                set
                {
                    if (value < 100)
                    {
                        // step 3 : raise the event whenever you want to 
                        if (InvalidP1 != null)
                        { InvalidP1(value); }
                    }


                }
            }
        }

        /*
                public static void handleInvalidInput()
                {
                    Console.WriteLine("Invalid input passed to p1");
                }
                public static void Main5()   /// tester/ user logic
                {
                    Class1 obj = new Class1();
                    obj.InvalidP1 += handleInvalidInput;

                    Console.WriteLine("Enter value for p :");
                    obj.P1 = int.Parse(Console.ReadLine());


                }*/

        public static void Main2()
        {
            Class1 obj = new Class1();
            obj.InvalidP1 += (int inValidVal) => { Console.WriteLine($"value {inValidVal} is not valid for p"); }; // passing delegatge in form of lambda exp

            Console.WriteLine("Enter value for p :");
            obj.P1 = int.Parse(Console.ReadLine());


        }

        //*************************** Anonymus class ******************
        public static void Main3()
        {
            var o = new { a = 1, b = "abc" };  // 
            var o1 = new { a = 2, b = "abcdsd" };
            var o3 = new { a = 1, b = 4 };

            Console.WriteLine(o.GetType());
            Console.WriteLine(o1.GetType());
            Console.WriteLine(o3.GetType());
            // if signature of two classes are same then they both are too same for Anonymus class
        }

        //**************** Prtial classs *********************************
        // Partial classes must be present in the same assembly(project), same namspace , MUST HAVE SAME NAME 
        // can be in different files satisfying the conditions



        public partial class Class2 { public int a; }
        public partial class Class2 {  public int b; }

        public static void Main4()
        {
            Class2 obj = new Class2();
            obj.a = 1;
            obj.b = 2;
        }



        /// <summary>
        ///  *********************************** Partial Method   ************************************************
        ///  Partial methods can only be defined within a partial class.
        ///  Partial Method ( a placeholder which may or may not satisfy- always return inside a partial class) 
        ///  If they are not defined or satisfied then all of their traces are removed by complier before running the program
        /// they are implicitly private 
        ///  
        // always return void -- as if had returned type then other function or value would be dependent upon the partial function (which may or may not be defined)
        // can be static or non static 
        // can not have out parameter ( as we will have to intialize the value)
        /// </summary>


        //  partial method code !!

        public static void Main()
        {

            Class1 o = new Class1();
            Console.WriteLine(o.Check());
            Console.ReadLine();
        }

        public partial class Class1
        {
            private bool isValid = true;
            partial void Validate();
            public bool Check()
            {
                //.....
                Validate();
                return isValid;
            }
        }
        public partial class Class1
        {
            partial void Validate()
            {
                //perform some validation code here
                isValid = false;
            }
        }





        /// Extension Method code !!! 
        public static void Main6()
        {
            int i = 100;

            // ****************** ACTUALLY WHAT IS HAPPNING --> NEW CONCEPT MUST REVISE  ********************************************
            i.Display();  // compiler ( i.Display()->MyExteClass.Display( int i))
            Console.WriteLine(i.Add(2)); // compiler ( i.Add(2)->MyExteClass.Add( int i, 2))
            // it's seems that we are adding a method to already existing class (SCARY) -> but it's not actually
            String s = "abhinav";
            s.Display();




        }


    }


    /// <summary>
    /// ******************************* EXTENSION METHOD  ********************************
    ///  step1 : create a static method in a static class
    ///  step 2: first paramenter of rhe ext method must be the type for which you are writing the ext method ,
    ///         preceded by this KEYWORD
    ///         
    /// 
    /// NOTE :  // if we add an extension to a class then it will be available to all the derived class
               // similarly if we add an extension method for a interface then it will be available to all implementation class 
    /// </summary>
    public static class MyExtClass
    {
        // stwp 2: first paramenter of rhe ext method must be the type for which you are writing the ext method , preceded by this KEYWORD
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }

        public static void Display(this String s)
        {
            Console.WriteLine(s);
        }

        public static int Add(this int i, int j )
        {
            return j+i ;
        }
    }
   
}
