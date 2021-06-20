using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Jessy_Ivana_Teddy
{
    public class House : Building
    {
        private string name;
        public House(string name, string city, int stars, double rentAmount) : base(name, city, stars, rentAmount)
        {
        }
        
        public override string Name
        {
            get { return base.Name; }
            protected set
            {
                base.Name = value;
                if (!value.EndsWith("House"))
                {
                    throw new ArgumentException("Name of house should end with house");
                }
                name = value;
            }
        }
    }
}
