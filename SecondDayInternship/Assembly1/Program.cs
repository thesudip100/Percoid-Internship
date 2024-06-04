using System;
using System.Net;
using FirstDay;

public class Assembly1DerivedClass:baseClass
    {
           public void TestAcesssinDerivedClass()
            {
                /* Console.WriteLine(address);
                 Console.WriteLine(job);*/
                   Console.WriteLine(name);
                   Console.WriteLine(street);
                   Console.WriteLine(description);
                }
}

public class Assembly1OtherClass
    {
        public void TestAccessinOtherClass()
        {
           baseClass baseObj = new baseClass();
        //not accesible
                /*Console.WriteLine(baseObj.address);
                Console.WriteLine(baseObj.job); 
                Console.WriteLine(baseObj.street);
                Console.WriteLine(baseObj.description);*/

            //accesible
            Console.WriteLine(baseObj.name);
    }
    }

class Program
{
    public static void Main(string[] args)
    {
        /*Assembly1DerivedClass ass1deriveDoBJ= new Assembly1DerivedClass();
        ass1deriveDoBJ.TestAcesssinDerivedClass();*/

        Assembly1OtherClass objOther = new Assembly1OtherClass();
        objOther.TestAccessinOtherClass();


    }
}