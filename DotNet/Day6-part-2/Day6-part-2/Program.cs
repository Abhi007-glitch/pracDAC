namespace Day6_part_2
{
    internal class Program
    {
        /*   static  void Main(string[] args)
           {
           }*/
        // WHY we use Async await -> these calls are non blocking ( main will wait(won't execute further code in calling function) but not blocked (can perform any other UI or other task )
        // async without await -> call is blocking ( main will wait won't execute further code in calling function) but alos won't be able to do any other task(like UI will be freezed)


        static async Task Main()  // main method is marked as aync it must return a Task;
        {

            Console.WriteLine("Before");

            String ans = await DoWorkAsync();


          //
          //Task<String> t = new Task<String>(DoWorkAsync);

          //  Console.WriteLine(t.Result.Result);
            // 
            Console.WriteLine(ans);

            Console.WriteLine("after");
        }
        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>  // === create task + start() + task.getResult();
            {
                Thread.Sleep(1000);
                return "work Done";
            });
        }
    }
}
