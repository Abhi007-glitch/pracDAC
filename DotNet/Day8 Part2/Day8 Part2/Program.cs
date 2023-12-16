namespace Day8_Part2
{
    internal class Program
    {


        public class Class1
        {
            public int i;

            public Class1(int i)
            {
                this.i = i;
            }
            public Class1()
            {
                i = -1;
            }


            public static Class1 operator+(Class1 o1, Class1 o2)
                {
                   return new Class1(o1.i+o2.i);
                }
            public static Class1 operator+(Class1 o1, int i)
            {
                o1.i = o1.i - i;
                return o1;
            }
        }
        static void Main(string[] args)
        {
            Class1 o1 = new Class1(10);
            Class1 o2 = new Class1(-10);

            o2 = o2 + o1;
            Console.WriteLine(o2.i);

            o2 = o2+ 5;
            Console.WriteLine(o2.i);
        }
    }
}
