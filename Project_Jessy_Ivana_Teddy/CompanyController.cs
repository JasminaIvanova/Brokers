using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Jessy_Ivana_Teddy
{
    public class CompanyController
    {
        private List<Company> companies;

        public CompanyController()
        {
            companies = new List<Company>();
        }

        public string CreateCompany(List<string> args) 
        {
            string name = args[0];
            if (companies.Any(x => x.Name == name)) 
            {
                return $"Company {name} is already registered!";
            }
            Company company = new Company(name);
            companies.Add(company);
            return $"Company {name} is successfully registered!";
        }

        public string RegisterBuilding(List<string> args) 
        {
            string type = args[0];
            string name = args[1];
            string city = args[2];
            int stars = int.Parse(args[3]);
            double rentAmount = double.Parse(args[4]);
            string companyName = args[5];
            Company company = companies.FirstOrDefault(x => x.Name == companyName);
            if (!companies.Any(x => x.Name == companyName)) 
            {
                return $"Inalid Company name {companyName}";
            }
            if (company.GetBuildingByName(name) != null) 
            {
                return $"Building {name} is already registered in {companyName}";
            }
            Building building = null;
            switch (type) 
            {
                case "Hotel":
                    building = new Hotel(name, city, stars, rentAmount);
                    break;
                case "House":
                    building = new House(name, city, stars, rentAmount);
                    break;
                case "Residence":
                    building = new Residence(name, city, stars, rentAmount);
                    break;
            }
            company.AddBuilding(building);
            return $"Building {name} was successfully registered in {companyName}!";
        }

        public string RegisterBroker(List<string> args) 
        {
            string name = args[0];
            int age = int.Parse(args[1]);
            string city = args[2];
            string companyName = args[3];
            Company company = companies.FirstOrDefault(x => x.Name == companyName);
            if (!companies.Any(x => x.Name == companyName))
            {
                return $"Inalid Company name {companyName}";
            }
            if (company.GetBrokerByName(name) != null)
            {
                return $"Broker's name {name} is already registered in {companyName}";
            }
            Brokers broker = new Brokers(name, age, city);
            company.AddBroker(broker);
            return $"Broker {name} was sucessfully hired in company {companyName}";
        }

        public string RentBuilding(List<string> args) 
        {
            string companyName = args[0];
            string brokerName = args[1];
            string buildingName = args[2];
            Company company = companies.FirstOrDefault(x => x.Name == companyName);
            if (!companies.Any(x => x.Name == companyName))
            {
                return $"Inalid Company name {companyName}";
            }
            Building building = company.GetBuildingByName(buildingName);
            if (building == null) 
            {
                return $"Invalid building {buildingName} in company {companyName}";
            }
            if (building.IsAvailable == false) 
            {
                return $"Building {buildingName} is not available";
            }
            Brokers broker = company.GetBrokerByName(brokerName);
            if (broker == null)
            {
                return $"Invalid broker {brokerName}";
            }
            building.IsAvailable = false;
            double bonus = broker.RecievePoints(building);
            return $"Successfully rented {buildingName}!" + Environment.NewLine +
                $"Broker {brokerName} has earned {Math.Round(bonus, 2)} bonus points!";
        }

        public string CompanyInfo(List<string> argss) 
        {
            string companyName = argss[0];
            Company company = companies.FirstOrDefault(x => x.Name == companyName);
            if (company != null) 
            {
                return company.ToString();
            }
            return $"Invalid company {companyName}";
        }

        public string End() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Companies: ");
            companies.ForEach(x => sb.AppendLine(x.ToString()));
            return sb.ToString().Trim();
        }
    }
}
