using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Jessy_Ivana_Teddy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            StringBuilder sb = new StringBuilder();
            CompanyController controller = new CompanyController();

            while (isRunning == true) 
            {
                List<string> argss = Console.ReadLine().Split(" ").ToList();
                string command = argss[0];
                argss = argss.Skip(1).ToList();
                try
                {
                    switch (command)
                    {
                        case "CreateCompany":
                            sb.AppendLine(controller.CreateCompany(argss)); 
                            break;
                        case "RegisterBuilding":
                            sb.AppendLine(controller.RegisterBuilding(argss));
                            break;
                        case "RegisterBroker":
                            sb.AppendLine(controller.RegisterBroker(argss));
                            break;
                        case "RentBuilding":
                            sb.AppendLine(controller.RentBuilding(argss));
                            break;
                        case "CompanyInfo":
                            sb.AppendLine(controller.CompanyInfo(argss));
                            break;
                        case "End":
                            sb.AppendLine(controller.End());
                            isRunning = false;
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    sb.AppendLine(ex.Message);
                }
            }
            Console.WriteLine(sb.ToString().Trim());

        }
    }
}
