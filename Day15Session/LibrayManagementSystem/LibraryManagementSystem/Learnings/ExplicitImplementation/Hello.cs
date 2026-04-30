using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Learnings.ExplicitImplementation;

public class Hello : IHello
{
    string IHello.HelloWorldString()
    {
        return "Hello";
    }
}

public class HelloWorld : IHello, IHelloWorld
{
    public string AnotherHello()
    {
        return "Another Hello";
    }
    string IHello.HelloWorldString()
    {
        return "Hello";
    }

    string IHelloWorld.HelloWorldString()
    {
        return "Hello World";
    }
}

// When the interface has same method name
// It does not have any access modifier, when interface its public when class its private 
// to solve the problem called Interface Pollution
// Interface Pollution : when there are 10 interfaces with 5 methods each which results to 50 methods invocation inherited on a single class we might just want to show
// required method on auto complete not whole list of 50 methods thus those who are Explicit Implemented are hidden
/*
    #region Explicit Implementation
       services.AddSingleton<IHello, Hello>();
       services.AddSingleton<IHelloWorld, HelloWorld>();
    #endregion
 
   var helloStringFromIHello = _hello.HelloWorldString();
   var helloWorldStringFromIHelloWorld = _helloWorld.HelloWorldString();

   HelloWorld helloWorld = new HelloWorld();
   //Interface pollution when we type helloWorld. -> then only AnotherHello() will be displayed, encapsulation maintained
   helloWorld.AnotherHello();
*/