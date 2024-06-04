// Testing the accessibility of various access specifiers within the same assembly

using FIrstDay;
using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
namespace FirstDay
{
    public class baseClass
    {
        public string name = "public name";
        private string address = "private address";
        protected string street = "protected street";
        internal string job = "internal job";
        protected internal string description = "protected internal description";


        public void TestAccess()
        {
            Console.WriteLine(name);
            Console.WriteLine(address);
            Console.WriteLine(street);
            Console.WriteLine(job);
            Console.WriteLine(description);
        }

         }

    public class derivedClass:baseClass
    {
        public void TestAccessInDerivedClass()
        {

            //not accessible
            /*Console.WriteLine(address);*/

            //accessible
            Console.WriteLine(name);
            Console.WriteLine(street);
            Console.WriteLine(job);
            Console.WriteLine(description);
        }        
     }

    public class otherClass
    {
        public void TestAccess1()
        {
            baseClass objBase= new baseClass();
            Console.WriteLine(objBase.name);
            Console.WriteLine(objBase.job);
            Console.WriteLine(objBase.description);

             //not accessible
            /* Console.WriteLine(objBase.address);
               Console.WriteLine(objBase.street);*/

        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            /*  baseClass baseobj = new baseClass();    
              baseobj.TestAccess();   */

            /*derivedClass derobj = new derivedClass();
            derobj.TestAccessInDerivedClass();*/

            /* otherClass otherObj= new otherClass();
             otherObj.TestAccess1();*/

            //constructor creation
            //ConstructorPractise conObj = new ConstructorPractise();

            //constructor overloading
            ConstructorPractise conObj = new ConstructorPractise(10,20);
            int result = conObj.add();
            Console.WriteLine(result);
        }
    }
}
