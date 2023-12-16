namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MyClass myObj = new MyClass();
            Console.WriteLine(myObj.sayHello());
            myObj.printHello();
            myObj.printHello("abhinav");
        }
    }


    class MyClass
    {
        public String sayHello()
        {
            return " Hello World!!";
        }

        public void printHello()
        {
            System.Console.WriteLine("Hello from .net");
        }

        public void printHello(String  s)
        {
            System.Console.WriteLine("Hello ," + s + " !!");
        }
    }
}
