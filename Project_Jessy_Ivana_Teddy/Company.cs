using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Jessy_Ivana_Teddy
{
    public class Company
    {
        private string name;
        private List<Building> buildings;
        private List<Brokers> brokerss;

        public Company(string name)
        {
            Name = name;
            buildings = new List<Building>();
            brokerss = new List<Brokers>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company's name cannot be null ot empty!");
                }
                name = value;
            }
        }

        public void AddBroker(Brokers broker) 
        {
            if (!brokerss.Any(x => x.Name == broker.Name)) 
            {
                brokerss.Add(broker);
            }
        }

        public void AddBuilding(Building building) 
        {
            if (!buildings.Any(x => x.Name == building.Name)) 
            {
                buildings.Add(building);
            }
        }

        public Brokers GetBrokerByName(string name) 
        {
            return brokerss.FirstOrDefault(x => x.Name == name);
        }

        public Building GetBuildingByName(string name)
        {
            return buildings.FirstOrDefault(x => x.Name == name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"----Company: {Name}");
            sb.AppendLine($"*****Brokers: ");
            for (int i = 0; i < brokerss.Count; i++)
            {
                sb.AppendLine(brokerss[i].ToString());
            }
            sb.AppendLine($"****Buildings: ");
            for (int i = 0; i < buildings.Count; i++)
            {
                sb.AppendLine(buildings[i].ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
