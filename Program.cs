using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordExample
{
    class Program
    {
        public static readonly string ErrorMessage = "You got an error";
        public const string better_error_message = "you have an error";//cannot make const static
        static void Main(string[] args)
        {
            int a = 10;
            for(int i=0;i<10;i++)
            {
                a = MethodDemonstratingFinally(a);
                Console.WriteLine("variable a is currently {0}", a);
            }

            //InternalExample.class2.CallClass1();//I can call class 2 because it is public
            // InternalExample.class1 //can't create an internal class from another assembly
            //ErrorMessage = "you have an error";//unchangeable once readonly

            //better_error_message = "Sir you have an error";//doenst work too, constants are locked

            object u = new UninheritablaClass();

            Type t = u.GetType();
            if(typeof(UninheritablaClass)==t)
            {
                Console.WriteLine("u is an uninheritable calss");
            }

            //byte b = 1;
            //byte[] fileBytes = System.IO.File.ReadAllBytes();

            if(u is UninheritablaClass)//i'm using "is to examine type information and test that "
            {
                ((UninheritablaClass)u).SayHello();
            }
            /*
            u = "hello";
            if(u is UninheritablaClass)
            {
                ((UninheritablaClass)u).SayHello();
            }
            */
            UninheritablaClass uc = u as UninheritablaClass;
            if(uc!=null)
            {
                uc.SayHello();
            }

            ClassWithProtectedBase cwpb = new ClassWithProtectedBase();
            cwpb.SaySalary();

            int number = 100;
            MultiplyBy10(number);
            Console.WriteLine(number);

            Console.ReadLine();

        }
        private static void MultiplyBy10(int number)
        {
            number = number * 10;
        }
        public static int MethodDemonstratingFinally(int a)
        {
            Random r = new Random();
            int randomNumber = r.Next(0, 1);
            try
            {
                if (randomNumber == 1)
                    throw new Exception("I'm forcing an exception to be thrown");
                a++;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                //a++; moved this to the finally block
            }
            finally
            {
                a++;
            }
            return a;

        }
    }

    //public class MyNewclass:UninheritablaClass//doesn't work
    //{

    //}

    public sealed class UninheritablaClass
    {
        public UninheritablaClass()
        {

        }
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
    public class ClassWithProtectedBase:ProtectedBaseClass
    {
        public void SaySalary()
        {
            Console.WriteLine(SalaryInformation);
        }
    }

    public class ProtectedBaseClass
    {
        protected decimal SalaryInformation=100;//protected means things are only visible for inherited class
    }


}
