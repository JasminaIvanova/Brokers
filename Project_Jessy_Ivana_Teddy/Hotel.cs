using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Jessy_Ivana_Teddy
{
    public class Hotel : Building
    {
        private string name;
        public Hotel(string name, string city, int stars, double rentAmount) 
            : base(name, city, stars, rentAmount)
        {
        }

        public override string Name 
        {
            get { return base.Name; }
            protected set 
            {
                base.Name = value;
                if (!value.EndsWith("Hotel")) 
                {
                    throw new ArgumentException("Name of hotel should end with hotel");
                }
                name = value;
            }
        }
    }
}
