using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complete.Models
{
    public class User
    {
        public User(int id, String name, int age, int score)
        {
            Id = id;
            Name = name;
            Age = age;
            Score = score;
        }

        public int Id { get; }
        public String Name { get; }
        public int Age { get; }
        public int Score { get; }

        public String NameAndId
        {
            get
            {
                return $" Name: {Name} \n ID: {Id}";
            }
        }

        public override string ToString()
        {
            return $" Name: {Name}, ID: {Id}, Age {Age}, Score {Score}";
        }
    }
}
