namespace day7Part1
{

    /// <summary>
    ///  1) ThreadPool - all are background threads
    ///  2)  thread synchronization for using common shared resource - using lock and InterLock specially for mathematical statement(more developer friendly);
    /// </summary>
    /// 
    /// <summary>   TASK - COMPLETE summary
    /// // ******************task are by deafult background thread ***************
    /// *********Can accept a action(zero input) Func(with 1 input Param of Objcet) type  
    /// *********** Task t1 = new Task(Func1, "aaa"); accepts input param in intialization of Task 
    ///                                              (unlike thread where pass input param while calling start())
    /// 
    ///  t1.start() // to start thread
    ///  
    /// **** MOST IMP : input delegate can have return value ( Task<int> t2 = new Task<int>(Func2, "bbb"));
    /// ****            still can accept only Object type input in delegate
    /// </summary>
    internal class Program
    {


        /*  static void func1(Object x)
          {   // the callback or method passed to run in thread must accept single input paramenter and that too be of Objcet type 

              for (int i = 0; i < 100; i++)
              {
                  Console.WriteLine(" in func1 : " + x.ToString() + i);
              }
          }

          static void func2(Object o)  // if no args passed the 0==null;
          {
              for (int i = 0; i < 100; i++)
              {
                  Console.WriteLine(" in func2 :  " + +i);
              }
          }
          static void Main2(string[] args)
          {
              Console.WriteLine("Hello, World!");

              ThreadPool.QueueUserWorkItem(new WaitCallback(func1), "aaa");// waitCallback is just a delegate
              // don't need to call thread.start() as soon as thread is assigned a waitCallback it start() get called automatically 
              ThreadPool.QueueUserWorkItem(func1, 99);  // adding delegatge to eventQueue 
              ThreadPool.QueueUserWorkItem(func2);


              for (int i = 1; i < 10; i++)
              {
                  Console.WriteLine("IN main : " + i);
              }

              Console.ReadLine(); 
              // just to make main to wait for thread pool thread to get compelete (as they are background thread they will get as soon as main overs)
          }
  */

        //********************************************************************************************************************


        /*
                public static void Main2()
                {
                    Console.WriteLine("Before");

                    //*******************************************
                    Task t1 = new Task(Display); // new Task(new Action(Display)
                    t1.Start();

                    // OR

                    Task t2 = Task.Run(Func1); // new Task+start()

                    // OR

                    Task t3 = Task.Factory.StartNew(Func2); // 

                    //Task.Factory.StartNew() and Task.Run have one major difference (run method does not suppot any function having any input parameter directly, while startNew does supports it)


                    Task t4 = new Task(func1, "aaa"); // in threads we use to pass the input paraneter to func1 at the time of calling Start()
                    t4.Start();


                    Task t5 = Task.Factory.StartNew(func2, "bbb");

                    // Task t6 = Task.Run(fun2, "ccc");//  --> Error  ( Run method does not support any function having any input parameter directly - 
                    // trunaround way exists via anonymus mehtod )->  use anonymous methods instead to access variables declared in calling code


                    //*************************************************


                    Console.WriteLine("After");

                    Console.ReadLine(); // to stop the end of exection of main 
                }



                static void Display()
                {
                    Thread.Sleep(5000);
                    Console.WriteLine("Display");
                }

                static void Func1()
                {

                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("First " + Thread.CurrentThread);
                    }
                }


                static void func1(Object o)
                {

                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("First " + Thread.CurrentThread);
                    }
                }

                static void func2(Object o)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("First " + Thread.CurrentThread);
                    }
                }

                static void Func2()
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("First " + Thread.CurrentThread);
                    }
                }

        */



        static int Func1()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First " + Thread.CurrentThread);
            }
            return 100;
        }


        static int func1(Object o)  // one paremeter must be a object 
        {
            Console.WriteLine(o.ToString());
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First " + Thread.CurrentThread);
            }

            return -100;
        }

        static int func2()  
        {
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First " + Thread.CurrentThread);
            }

            return -100;
        }


        public static void Main4()
        {
            Task<int> t1 = new Task<int>(Func1);
            Task<int> t2 = new Task<int>(func1, -10);
            Task<int> t3 = new Task<int>(func1, -20);
            t1.Start();
            t2.Start();
            t3.Start();



            Console.WriteLine(t3.Result);  // this too work as t3.Result also perform wait()



            if (!t1.IsCompleted)
            {
                t1.Wait();  // like join()
                Console.WriteLine(t1.Result); // return value of t1

            }
            // t2 will end after t1 irrespective of the order in which they where called!!
            if (!t2.IsCompleted)
            {
                t2.Wait();
                Console.WriteLine(t2.Result);
            }



        }

        public static void Main()
        {
            Task<int> t1 = Task.Factory.StartNew<int>(func1);
        }
    }
}
