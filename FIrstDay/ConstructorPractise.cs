using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIrstDay
{
     class ConstructorPractise
    {
        public int num1,num2;


        //default constructor
        public ConstructorPractise()
        {
            this.num1 = 5;
            this.num2 = 8;
        }

        //parameterized constructor

        public ConstructorPractise(int a, int b)
        {
            this.num1 = a;
            this.num2 = b;
        }

        public int add()
        {
            return num1 + num2;
        }

    }

}
