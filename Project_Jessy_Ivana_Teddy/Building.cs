using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Jessy_Ivana_Teddy
{
    public abstract class Building
    {
        private string name;
        private string city;
        private int stars;
        private double rentAmount;
        public bool IsAvailable { get; set; }

        public Building(string name, string city, int stars, double rentAmount)
        {
            Name = name;
            City = city;
            Stars = stars;
            RentAmount = rentAmount;
            IsAvailable = true;
        }
        public virtual string Name 
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new ArgumentNullException("Building name cannot be null ot empty!");
                }
                name = value;
            }
        }

        public string City 
        {
            get { return city; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("City cannot be null ot empty!");
                }
                city = value;
            }
        }

        public int Stars 
        {
            get { return stars; }
            protected set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException("Stars must be between 0 and 5!");
                }
                stars = value;
            }
        }

        public double RentAmount 
        {
            get { return rentAmount; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("RentAmount must be greater than 0!");
                }
                rentAmount = value;
            }
        }

        public override string ToString()
        {
            return $"-----Building : {Name} with {Stars} stars" + Environment.NewLine +
                   $"-----City : {City}" + Environment.NewLine +
                   $"-----RentAmount : {RentAmount}" + Environment.NewLine +
                   $"-----Is Available: {IsAvailable}";
        }

    }
}
