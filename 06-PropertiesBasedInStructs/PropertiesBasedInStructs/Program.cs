using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesBasedInStructs
{
    public struct PersonStruct
    {
        public string Name;
        public string Surname;
    }

    public class PersonClass
    {
        public string Name;
        public string Surname;

        public PersonClass(string n, string s)
        {
            Name = n;
            Surname = s;
        }
    }

    public class PersonWrapper
    {
        public PersonStruct PersonStruct { get; set; }
        public PersonClass PersonClass { get; set; }

        public PersonWrapper()
        {
            PersonStruct = new PersonStruct() { Name = "original", Surname = "original" };
            PersonClass = new PersonClass("original", "original");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new PersonWrapper();
            var personClass = obj.PersonClass;
            personClass.Name = "modified";
            var personStruct = obj.PersonStruct;
            personStruct.Name = "modified";
            
            //obj.PersonStruct.Name = "modified"; // compiler error

            Console.WriteLine("Person class is: " + obj.PersonClass.Name);
            Console.WriteLine("Person class is: " + obj.PersonStruct.Name);
        }
    }
}
