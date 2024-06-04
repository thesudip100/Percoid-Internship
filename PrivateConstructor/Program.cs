//Private constructor doesnt allow external class instantiation but allows to create the instance in nested class. Lets see an example.
/*Before there was no concept of static class so private constructors were used but today we have static classes
 
 Static class--> only 1 instance
A class can have multiple private and public constructors*/

using System;
using System.Diagnostics.Metrics;
public class Example
{
    private static int counter;
    private Example()    //private constructor
    {
        counter = 2;
    }
    static Example()
    {
        counter = 30;
    }

    public Example(int Counter)    //public constructor
    {
        counter += Counter;
    }

    public static int  getCount()
    {
        return ++counter;
    }

    public class NestedExample
    {
        public void Test()
        {
            //internal instance
            Example ex1=new Example();
            Example.getCount();
            Console.WriteLine(counter);
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        //Example ex= new Example(); //not possible to do external instatiation due to private constructor

        //this is how you access private constructor through nested class
        /*Example ex = new Example(10);
        Console.WriteLine("Counter:{0}", Example.getCount());
        Example.NestedExample obj1=new Example.NestedExample();
        obj1.Test();*/

        Example ex = new Example(10);
        Console.WriteLine(Example.getCount());




    }
}
