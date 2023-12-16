
using System.Security;
using System.Security.Cryptography.X509Certificates;
namespace Day6_part1
{


  

        internal class Program
        {
            static void Main1(string[] args)
            {

                Thread t1 = new Thread(new ThreadStart(Func1));  // ThreadStart just delegate with zero input param and void return type 
                    // We have ParameterizedThreadStart another delegate accepted by Thread() which takes Func delegate which takes only parameter of type Object 

                Thread t2 = new Thread(Func2);

            // t2.IsBackground= true;  // deafult set as false (default threads are foreground) ;  // will end as soon as main ends

            // even after execution of main thread it wait for the t1 thread to completion exection, thread like t1 are known as forground thread ( main thread wait for the t1) - these are used for critial process(work) 
            t1.Start();
                t2.Start();
               // these threads a running concurrently - but are their order of execution is not under our controll

            






            // Thread states
            // ThreadState. -> gives Enum of different state possible in a thread life cycle 
            if (t1.ThreadState == ThreadState.Running) // checking state of the thread before calling thread.start()
                {
                    Console.WriteLine("Thread is already started and running can't re start a already started thread!!");
                }


                // setting priority when there more no. of thread then no. of processor ( then we have competition between threads for getting processor time)
                t1.Priority = ThreadPriority.Highest;   //  setting priority of thread ( this is not absolute -> it's like request instead of Command to CLR)
                                                        // t1 will get more CPU time 

            //  Console.WriteLine(Thread.CurrentThread.ManagedThreadId); --> return by CLR (AS Thread management done by clr)
            for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Main : " + i);

                }

                // order of execution is undefined and managed by CLR 
                t1.Join(); // main will wait for t1 to execute before processing further code!!
                Console.WriteLine("Hello, World!");


            }


            static void Func1()
            {

                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("First : " + i);
                    Thread.Sleep(1000); // t1 thread go to sleep for 1 sec 
                }

            }


            static void Func2()
            {

                //  t1.Abort(); -> Depricated  // request to end the thread (ABortRequest-> ABort-> StopRequest-> stop)
                // t1.Suspend(); -> Depricated  (suspendRequested -> suspend)
                // t1.Resume();  -> Depricated 

                //  EXecutiing these in modern way




                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Second : " + i);
                }

            }


            public static void Main2()
            {
            //  t1.Abort(); -> Depricated  // request to end the thread (ABortRequest-> ABort-> StopRequest-> stop)
            // t1.Suspend(); -> Depricated  (suspendRequested -> suspend)
            // t1.Resume();  -> Depricated 

            // REPLACEMENT of above features

            AutoResetEvent wh = new AutoResetEvent(false); // Signaling -> AS a replacment for Depricated Abort() Suspend() Resume()

            Thread t1 = new Thread(delegate ()
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine(i);
                        if (i % 50 == 0)
                        {
                            //instead of Suspend, use this
                            Console.WriteLine("waiting");
                            wh.WaitOne(); // siganl to Suspend()
                        }
                    }
                });

                t1.Start();

            //Thread.Sleep(2000);
            Console.ReadLine();
            Console.WriteLine("resuming 1....");
            wh.Set();  // signanling to resume

            //Thread.Sleep(2000);
            Console.ReadLine();
            Console.WriteLine("resuming 2....");
            wh.Set();

            //Thread.Sleep(2000);
            Console.ReadLine();
            Console.WriteLine("resuming 3....");
            wh.Set();

            //Thread.Sleep(2000);
            Console.ReadLine();
            Console.WriteLine("resuming 4....");
            wh.Set();



        }

            static void Fun1(Object obj)
            {
                int[] arr = (int[])obj; // type casting as per value passed !!
                Console.WriteLine("  In First statit " + obj);
            }

            static void Fun2(Object obj)
            {
                Console.WriteLine("IN Second : " + obj);
            }

        static void Fun3(Object obj)
        {
            if (obj is (int item1, int item2))
            {
              Console.WriteLine("From func3 : " +item2 + " " + item1);   
            }
            Console.WriteLine("Fun 3 ends");
           
        }
            public static void Main()
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(Fun1)); // Fun1 can only take one Parameter that too of type Object
                Thread t2 = new Thread(Fun2);
                Thread t3 = new Thread(Fun3);

            // some ways to pass multiple value to a function when function accepts only one singel parameter
            /// 1) valueTuple 
            /// 2) Array 
            /// 3) ArrayList
            /// 4) struct
            /// 5) class if we wanted to use inhereitance 
            ///6) pass it as delegate/ lambda  returned from a outer function having mutiple variables ( in outer function we will be decleare value that we want to pass as param )


            (int, int) tuple = (1, 2);
            t3.Start(tuple);


            int[] arr = new int[2] { 10, 20 };
                
                t1.Start(arr);

                //t1.Start("aaa");
                t2.Start("bbb");

           


            }



        }




    

}
