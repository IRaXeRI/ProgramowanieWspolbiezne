namespace HelloWorld
{
    class MainClass {         
        static void Main(string[] args)
        {
            MainClass cla = new MainClass();
            Console.WriteLine(cla.HelloWorld());
        }

        public string HelloWorld()
        {
            return "Hello World!";
        }
    }
}