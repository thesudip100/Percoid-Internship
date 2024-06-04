using System;
using System.Runtime.InteropServices;
class Counter
{
    public static int count;   //static variable

    public static void getCount()  //static method
    {
        ++count;
        Console.WriteLine("Counting:{0}",count);
    }

}

class Program
{
    public static void Main(string[] args)
    {
        //Counter c1 = new Counter();      //Since it is static we dont need to do c1.getCount()
        Counter.getCount();
        Counter.getCount();
        Counter.getCount();
        Counter.getCount();
        Counter.getCount();
    }
}