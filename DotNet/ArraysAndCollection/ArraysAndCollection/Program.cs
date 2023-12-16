using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace ArraysAndCollection
{
    internal class Program
    {
        static void Main1()
        {
            int[] arr = new int[5];
            int[] arr1 = new int[5] { 10, 20, 30, 40, 50 };
            int[] arr2 = { 10, 1, 2, 3, 44, 5 };


           /* int pos = Array.IndexOf(arr2, 2);
            pos = Array.BinarySearch(arr2, 4);  // if not found then return any -ve value 


            Array.Clear(arr2, 0, pos); // erase the value set to the default value of the data type

            Array.Copy(arr, arr2, 3);   // if any error occure then would set rest value as default and return

            Array.ConstrainedCopy(arr, 0, arr2, 0, arr.Length);  // if any error occure then Copy fails and nothing is returned


            if (pos == -1)
            {
                Console.WriteLine(pos);
            }*/


            for (int i = 0; i < arr.Length; i++)
            {
                // arr[i] = int.Parse(Console.ReadLine());  compiler gives warning but works without any issue
                //

                Console.Write("Enter the value for arr[{0}] ", i);  // placeHolder
                Console.Write($"Enter the value for arr[{i}] ");  // string interpolation
                //Method :1 - faster 
                arr[i] = int.Parse(Console.ReadLine()!);  // dealing with null error via !(bang) or ? 

                // method :2
                // arr[i] = Convert.ToInt32(Console.ReadLine());
            }


            foreach (int i in arr)
            {
                Console.Write(i + " , ");
            }
        }

        // multi dimernsonal array 
        static void Main2()
        {

            int[,,] arr3d;  // 3 dimensional array 

            int[,] arr2d = new int[3, 5];  // 2d arrays




            Console.WriteLine(arr2d.Length);  //total number of items in array 
            Console.WriteLine(arr2d.Rank); // returns no of dimension

            arr2d.GetLength(0);  // length of first dimenion
            arr2d.GetLength(1);  // length of second dimension
            arr2d.GetUpperBound(0); // upper bound of first dimension (can be used for iteration just like getLength)
            arr2d.GetUpperBound(1);



            for (int i = 0; i <= arr2d.GetUpperBound(0); i++)   // less than equal to (as GetUpperBound
            {
                for (int j = 0; j < arr2d.GetLength(1); j++)   // less than as (GetLength)
                {
                    arr2d[i, j] = int.Parse(Console.ReadLine());
                }
            }


            for ( int i=0;i<arr2d.GetLength(0);i++)
            {
                for (int j = 0; j < arr2d.GetLength(1);j++)
                {
                    Console.Write($"arr2d[{i},{j}] = {arr2d[i,j]}    ");
                }
                Console.WriteLine();
            }
        }


        static void Main3()
        {
            // jagged Array
            int[][] arr = new int[4][];   // 1d Array having individual values as array of variable size 


            arr[0] = new int[4];   // indivudal arrays element can be of any size 
            arr[1] = new int[2];
            for (int i = 0; i < arr[0].Length;i++)
            {
                arr[0][i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0;i < arr[1].Length;i++)
            {
                arr[1][i]= int.Parse(Console.ReadLine());
            }
         
            arr[2] = new int[3] {1,2,3};
            arr[3] = new int[5] {1,2,3,4,5};




            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)   // not getLength or getUpperBond as individual values are 1d array 
                {
                    Console.Write(arr[i][j]+ "   ");
                }
                Console.WriteLine();
            }


        }


        static void Main5()
        {
            Employee[] arr = new Employee[5];

            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Employee();
                arr[i].EmpNo = i;

            }


            foreach (Employee e in arr)   // for each are read only at superficial level  but if make changes no superficial level then throws error
            {
                //  e = new Employee();  // does not work as it is structurally modifing or it's is chaning one value completely
                e.EmpNo = 10; // allowed

            }
        }


        



        // day 4 **********************************************************************************************
        // 1) var Args 
        // 2) Genrics - generic contraints
        // 3) Custom Sorting  - IComparable, IComparer(comapare(T o1,T o2) ->(1,-1,0) - method name ) interface
        // 4) var - implicit type
        // 5) indices and ranges
        // 6) Tuple and valueTuple 
        // 7) Collection - non generic(older) and generic (modern) one 
        // 8) NonGeneric Collection --  isssue -> 
        //    namespace


        public static void Main6()
        {

            // passsing variable number of args 

            int Add(params int[] arrr)
            {
                int sum = 0;
                foreach (int i in arrr)
                {
                    sum += i;
                }
                return sum;
            }

            Add(1,2,3);
            Add(1,2,3,4);
        }

        class MyStack<T> where T : class // T must be a refernce tyoe 
        {
            // where T : Struct  // T must be a value type
            // where T : ClassName   //  T must be a class that inmplements derived class
            /// where T : InterfaceName   //  T must be a class that inmplements Inteface 
           //where T : new ()   //  T must have a no parmeter constructor -( used when we have used unparameterised contructor)
           //

            // combined constraints
            // where T : ClassName, InterfaceName
            // where T : ClassName, InterfaceName,new()

            T[] arr;
            int pos = -1;
                public MyStack(int size)
            {
                arr=new T[size];
            }

            public void push(T item)
            {
               // 
                arr[pos++] = item;
            }
        }

        public static void Main7()
        {
            MyStack<String> stringStack = new MyStack<String>(5);
           // MyStack<int>intStack = new MyStack<int>(6);  // as we have made T as refernce tyoe
        }



        // Genric IComparer<>
        /*      public class Employee : IComparer<Employee>
              {


                  public int EmpNo { get; set; }
                  public Employee()   // need to explicitily declare Constructor public else marked to be as private(default)
                  {

                  }

                  public int Compare(Employee? x, Employee? y)
                  {
                      return 0;
                  }


              }*/

        // IComparer - non genric
        /* public class Employee : IComparer
         {


             public int EmpNo { get; set; }
             public Employee()   // need to explicitily declare Constructor public else marked to be as private(default)
             {

             }


             public int Compare(object? x, object? y)
             { 

                 Employee e1 = (Employee)x;  // need to type cast
                 Employee e2 = (Employee)y;

                 return 0;
             }
         }
 */

        // 2) IComparable<>

        public class Employee : IComparable<Employee>
        {


            public int EmpNo { get; set; }
            public Employee()   // need to explicitily declare Constructor public else marked to be as private(default)
            {

            }


            int IComparable<Employee>.CompareTo(Employee? other)
            {
                // using this and other 
                throw new NotImplementedException();
            }


        }


        /// calling Sort Array.sort<Employee>(arr); // no need to pass 2nd argument


        public static void printtingVar(String t)
        {
            Console.WriteLine(t);
        }
        public static void Main8()
        {
            int i = 100;

            var j = 10;
            // j = "aa";  error

       

            var ii = "aabbcc";
            ii = "mm";

            printtingVar(ii);




        }



        // Index - ****************** NEW CONCEPT ***********************************************
        public static String [] printtt(String[] arg )
        {

            Index index = new Index(0);

            Index indexx = new Index(1, true); // last index from end
            Index indexxx = new Index(2, true);

            Index indexx1 = ^1;  // last index from end 
            Console.WriteLine(index.ToString());

            var range = new Range(indexx, indexx1); // excluding indexx1

            String [] a1 = arg[..3]; // first 3 elements 

            String [] a2=  arg[^3..]; // last 3 elements

            return arg[..]; 


            
        }
     
        
        
        public static void Main9(String[] args)
        {

            ArrayList objArrayList = new ArrayList();
            objArrayList.Add(1);
            objArrayList.Add("jatin");
            objArrayList.Add(true);
            objArrayList.Add("yatin");


            foreach (Object i in objArrayList)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            objArrayList.Remove("yatin");
            objArrayList.RemoveAt(0);
            objArrayList.Insert(0, "Abhi");

            foreach (var i in objArrayList)
            {
                Console.Write(i + " ");
            }

            ArrayList o1 = new ArrayList();
            o1.Add(1);
            o1.Add("temo");
            objArrayList.AddRange(o1);

            foreach (var i in objArrayList)
            {
                Console.Write(i + " ");
            }

            objArrayList.RemoveRange(0, 2);


            foreach (var i in objArrayList)
            {
                Console.Write(i + " ");
            }

            objArrayList.IndexOf("abhi");
            objArrayList.LastIndexOf("1");

            objArrayList.Clear(); // removeALL

            bool booleResult = objArrayList.Contains("abhi");

            object[] arr = new object[objArrayList.Count];
            objArrayList.CopyTo(arr);

            Object[] arr0 = objArrayList.ToArray();


            // objArrayList.this[0] => objArrayList[0] // this is a indexed( a concept yet to be covered !!

            //***************** Syntatical Sugar !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            objArrayList[0] = 11;



            // ArrayList arr1 = objArrayList.GetRange(0, 3);


            // Capacity --- very *********

            ArrayList arrList = new ArrayList();

            Console.WriteLine($"Count : {arrList.Count} , Capacity : {arrList.Capacity}");
            arrList.Add(1);

            Console.WriteLine($"Count : {arrList.Count} , Capacity : {arrList.Capacity}");
            arrList.Add(2);

            Console.WriteLine($"Count : {arrList.Count} , Capacity : {arrList.Capacity}");
            arrList.Add(3);

            Console.WriteLine($"Count : {arrList.Count} , Capacity : {arrList.Capacity}");
            arrList.Add(4);

            Console.WriteLine($"Count : {arrList.Count} , Capacity : {arrList.Capacity}");
            arrList.Add(5);

            Console.WriteLine($"Count : {arrList.Count} , Capacity : {arrList.Capacity}");
            arrList.Add(6);

            // after adding all element free Extra capacity

            arrList.TrimToSize();  // memory Optimization
            Console.WriteLine($"Count : {arrList.Count} , Capacity : {arrList.Capacity}"); 



        }

   /// <summary>
   ///   
   ///  Non Generic Collection 
   /// </summary>
        public static void Main10()
        {

            // ALl these methods are taking input as object and then Boxing them to input type which is high cost task --> These are Not generic

            Hashtable dic = new Hashtable();  // any type of key any type of value 
            dic.Add(1, "Aditya");
            dic.Add(2, true);
            dic.Add(3, "abhishek");
            dic.Add(4, 0.1);
            dic.Add(5, 5);


            SortedList sortedDic = new SortedList();

            sortedDic.Add(1, "Aditya");
            sortedDic.Add(2, true);
            sortedDic.Add(3, "abhishek");
            sortedDic.Add(4, 0.1);
            sortedDic.Add(5, 5);

            sortedDic["abhinav"] = "sharma ";
            sortedDic[33] = "j3";


            sortedDic.Remove(1);   // remove a emtryset having key 1
            sortedDic.RemoveAt(1); // remove a entrySet at index1 

            sortedDic.Contains(1); // 1 is key 
            sortedDic.ContainsKey(1);
            sortedDic.ContainsValue("abhinav");

            sortedDic.GetByIndex(0);  // return  vlaue of key at index 0


            // sortedDic.CopyTo() 
            IList keys = sortedDic.GetKeyList();   // I List returned Here 
            IList Values = sortedDic.GetValueList();


            int idex = sortedDic.IndexOfKey(1);
            int idex2 = sortedDic.IndexOfValue("abhianv");


            ICollection keyss = sortedDic.Keys;
            ICollection valuess = sortedDic.Values;
            sortedDic.SetByIndex(0, "Yatin");

            foreach (DictionaryEntry i in sortedDic) {
                Console.WriteLine(i);
            }

        }


       
        public static void Main11()
        {
            Stack s = new Stack();
            s.Push(1);
            s.Pop();

            s.Push(2);

            s.Peek();


            Queue q = new Queue();
            q.Enqueue(1);
            q.Peek();
            q.Dequeue();

        }


        public static void Main12()
        {
            List<int> list = new List<int>();   // will store only int

            list.Add(1);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            List<String> list2 = new List<String>();


        }

        public static void Main13()
        {
            SortedList<int, String> sortedList = new SortedList<int, string>();

            sortedList.Add(1, "abhay");
            sortedList.Add(2, "abhinav");
            sortedList.Add(3,"abhishek");

            sortedList[4] = "jatin";


            foreach (KeyValuePair<int, String> kvp in sortedList)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value);
            }


        }


        // ********************************************************* DElegates *********************************************************
        /// <summary>
        /// used when - we can't a function directly  
        /// 
        /// Why - Used to call a function indireclty 
        /// 
        /// //A) creating a deligate
        ///     step1: Create a delegate class that matches the function signature
        ///     Step2 : Create a delegate refernce and point it to object of delegate classs.
        ///              The Delegate object will take function name as parameter
        ///     step 3: cal the function voia the delegate reference
        ///     step 3: cal the function voia the delegate reference
        /// 
        /// 
        /// /// Hierarchy of Delegates
        /// //1)Object
        /// //2)Delegate
        /// //2)MultiCastDelegate
        /// //3)Del1
        /// 
        /// 
        /// 
        /// 
        /// </summary>



        public static void Display()
        {
            Console.WriteLine("Display");
        }

        public static void show()
        {
            Console.WriteLine("Show");
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public delegate void Del1();  // void Del1() matches the function signature of diplay- void Display  //
             /// ********************************    THE ONLY ISSUE with DELEGATES *******************************************
        // if number of parameter changes or even type of parameter then we need to create a new Delegate

        public delegate int Del2(int a, int b);
         public static void Main14()
        {

            //  Step2: Create a delegate refernce and point it to object of delegate classs.
            ///              The Delegate object will take function name as parameter

            Del1 objDel = new Del1(Display);
            // step 3: cal the function voia the delegate reference
            objDel();

            Console.WriteLine();

            Del1 objDel1 = Display;  // a simpler way 

            objDel1();
            Console.WriteLine();
            Console.WriteLine();
            objDel1 = show;

            objDel1();
            Console.WriteLine();
            Console.WriteLine();
            objDel1 += Display; // a delegate object can point to more than 1 function at a time ( it contain them as list 

            objDel1();  // both Disply and 
            Console.WriteLine();
            Console.WriteLine();

            objDel1 -= show;
            objDel1();

            Console.WriteLine();
            Console.WriteLine();

            Del2 obj11 = Add;
            Console.WriteLine(obj11(10, 5));

            obj11 += Subtract;

            obj11(10,5); // Observe only the last function called value is retured rest all returned value from other function are overwritten

            // if objDel1 is empty (null) and we call it, throws nullreference exception


            Del1 objjj = (Del1) Delegate.Combine(new Del1(Display), new Del1(show));   // same as objj +=show ; objj+=display
            objjj = (Del1)Delegate.Remove(obj11, new Del1(show));   // objjj -= show

        }





        public delegate int DelAdd(int a, int b);
        static int ADD(int a, int b)
        {
            return a + b;
        }

        static int SUBTRACT(int a, int b)
        {
            return a - b;
        }

        static int CallMathOperation(DelAdd objAdd, int a, int b) // passsing a function as parameters
        {
            return objAdd(a,b);
        }
        public static void Main()
        {
            Console.WriteLine(CallMathOperation(ADD, 10, 5));

            Console.WriteLine(CallMathOperation(SUBTRACT, 10, 5));
        }
    }

}
