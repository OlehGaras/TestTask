using System;
using System.Globalization;
using NServiceBus;

namespace Message
{
    [Serializable]
    public class Student:IMessage
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student()
        {
            var random = new Random();
            var names = Enum.GetValues(typeof(Names));
            var surnames = Enum.GetValues(typeof(Surnames));
            Name = names.GetValue(random.Next(names.Length)).ToString();
            SurName = surnames.GetValue(random.Next(surnames.Length)).ToString();
            DateOfBirth = DateTime.Now;
        }

        public Student(string name, string surname)
            : this(name, surname, DateTime.Now)
        {
        }

        public Student(string name, string surname, DateTime dateOfBirth)
        {
            Name = name;
            SurName = surname;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return "Name: " + Name + " Surname: " + SurName + "Date of birth: " + DateOfBirth.ToString(CultureInfo.InvariantCulture);
        }
    }
}
