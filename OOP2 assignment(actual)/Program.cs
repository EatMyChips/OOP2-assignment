using OOP2_Assignment_actual_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_assignment_actual_ {
  class Program {
    static void Main(string[] args) {
      SevensOut sevensOut = new SevensOut();
      ThreeOrMore threeOrMore = new ThreeOrMore();
      Statistics statistics = new Statistics();
      Testing testing = new Testing();
 
      int _intInput = 0;
      while (_intInput != 5) {
        string _input = " ";

        while (!int.TryParse(_input, out _intInput) || _intInput < 1 || _intInput > 5) {
          Console.WriteLine("What would you like to do?" +
                            "\n[1] Play SevensOut" +
                            "\n[2] Play ThreeOrMore" +
                            "\n[3] View Statistics" +
                            "\n[4] Test Games" +
                            "\n[5] Leave Game");
          _input = Console.ReadLine()!;
        }

        switch (_intInput) {
          case 1:
            sevensOut.Play(false);
            break;
          case 2:
            threeOrMore.Play(false);
            break;
          case 3:
            statistics.ViewStatistics();
            break;
          case 4:
            testing.TestGames();
            break;
        }
      }
    }
  }
}
