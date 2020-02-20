using System;

namespace ValidatorTesting.Data.DomainModels
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person() : this(string.Empty, 0)
        {
        }


        public string Name { get; set; }
        public int Age { get; set; }
    }
}