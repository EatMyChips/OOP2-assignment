using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_actual_ {
  class Statistics {

    public static Dictionary<string, int> statsSevens = new Dictionary<string, int>();
    public static Dictionary<string, int> statsThree = new Dictionary<string, int>();
    public void ViewStatistics () {
      int _intInput = 0;

      while (_intInput != 3) {
        string _input = "0";

        while (!int.TryParse(_input, out _intInput) || _intInput < 1 || _intInput > 3) {

          Console.WriteLine("Which game do you want to view statistics for?" +
                             "\n[1]Sevens Out" +
                             "\n[2]Three or more" +
                             "\n[3]Leave");
          Console.WriteLine(_intInput);
          _input = Console.ReadLine()!;

          
        }

        switch (_intInput) {
          case 1:
            Console.WriteLine("sevens out stats");
            break;
          case 2:
            Console.WriteLine("three or more stats");
            break;
        }
      }
      Console.WriteLine("Leaving");
    }
  }
}
