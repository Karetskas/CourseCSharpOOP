namespace Academits.Karetskas.LambdasTask
{
    internal sealed class Person
    {
        private int _age;

        public string Name { get; private set; }

        public int Age
        {
            get => _age;

            private set => _age = value < 0 ? 0 : value;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"[Name: {Name}; Age: {_age}]";
        }
    }
}
