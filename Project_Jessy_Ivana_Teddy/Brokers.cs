using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Jessy_Ivana_Teddy
{
    public class Brokers
    {
        private string name;
        private int age;
        private string city;
        private List<Building> buildings;

        public Brokers(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
            buildings = new List<Building>();
            Bonus = 0;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Broker's name cannot be null ot empty!");
                }
                name = value;
            }
        }
        public string City
        {
            get { return city; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("City cannot be null ot empty!");
                }
                city = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 18 || value > 65)
                {
                    throw new ArgumentException("Broker's age must be between 18 and 65");
                }
                age = value;
            }
        }

        public double Bonus { get; set; }

        public double RecievePoints(Building building) 
        {
            if (building.Name.EndsWith("Hotel"))
            {
                Bonus += building.RentAmount * 3 * building.Stars / 100;
            }
            else if (building.Name.EndsWith("Residence")) 
            {
                Bonus = building.RentAmount * 2 * building.Stars / 100;
            }
            else if (building.Name.EndsWith("House"))
            {
                Bonus = building.RentAmount * building.Stars / 100;
            }
            buildings.Add(building);
            return Bonus;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"----Broker: {Name} - {Age}");
            sb.AppendLine($"----City: {City}");
            sb.AppendLine($"----BonusPoints: {Math.Round(Bonus,2)}");
            for (int i = 0; i < buildings.Count; i++)
            {
                sb.AppendLine($"---- {buildings[i].Name}");
            }
            return sb.ToString().Trim();
        }
    }

   
}
