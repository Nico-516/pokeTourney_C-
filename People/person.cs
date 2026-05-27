namespace pokeTourney.Model.People
{

//clase base abstracta para toda persona relacionada al torneo
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age  { get; set; }

        protected Person(string name, int age)
        {
            Name = name;
            Age  = age;
        }

        
        public abstract string GetDescription();

        public override string ToString() => $"{GetType().Name}: {Name} (edad: {Age})";
    }
}
