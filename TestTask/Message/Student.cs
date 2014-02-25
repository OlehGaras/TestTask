using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using NServiceBus;

namespace Message
{
    [Serializable]
    public class Student : IMessage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        private readonly Random mRandom = new Random();

        public Student()
        {
            var names = Enum.GetValues(typeof(Names));
            var surnames = Enum.GetValues(typeof(Surnames));
            
            Name = names.GetValue(mRandom.Next(names.Length)).ToString();
            SurName = surnames.GetValue(mRandom.Next(surnames.Length)).ToString();
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
            return "Name: " + Name + "\nSurname: " + SurName + "\nDate of birth: " + DateOfBirth.ToString(CultureInfo.InvariantCulture);
        }
    }
}