namespace HelloWorld;
using NUnit.Framework;

public class Test
{
    [Test]
    public void testHelloWorld()
    {
        MainClass TestClass = new MainClass();
        Assert.True(TestClass.HelloWorld()=="Hello World!");
    }
} 