using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    async static Task Main(string[] args)
    {
      Console.WriteLine("Do you want to make your own badges or generate random ones? (Choose 1 or 2)");
      string chosenMethod = Console.ReadLine() ?? "";
      if (chosenMethod == "1") {
        List<Employee> employees = PeopleFetcher.GetEmployees();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);
      } else if (chosenMethod == "2") {
        List<Employee> employees = await PeopleFetcher.GetFromApi();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);
      } else {
        Console.WriteLine("Invalid choice. Please choose 1 or 2 next time.");
      }
    }
  }

  
}