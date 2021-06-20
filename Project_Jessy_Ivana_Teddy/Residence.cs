using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Jessy_Ivana_Teddy
{
    public class Residence : Building
    {
        private string name;
        public Residence(string name, string city, int stars, double rentAmount)
            : base(name, city, stars, rentAmount)
        {
        }

        public override string Name
        {
            get { return base.Name; }
            protected set
            {
                base.Name = value;
                if (!value.EndsWith("Residence"))
                {
                    throw new ArgumentException("Name of residence should end with Residence");
                }
                name = value;
            }
        }
    }
}
