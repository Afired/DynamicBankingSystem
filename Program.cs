using System;
using System.Collections.Generic;

namespace Bank {
    class Program {

        static Dictionary<string, Bank> banks = new Dictionary<string, Bank>();

        static void Main() {
            CreateDefaults();

            while(true) {
                HandleInput();
            }
        }

        static void HandleInput() {
            string input = Console.ReadLine();

            CommandHandler.HandleCommand(input);
            Console.WriteLine();
        }

        static void CreateDefaults() {
            Console.WriteLine("-------|Defaults|-------");
            CreateBank("myBank", "myCompany");
            Console.WriteLine("------------------------");
            Console.WriteLine();
        }

        public static void CreateBank(string name, string company) {
            if(banks.ContainsKey(name)) {
                Console.WriteLine($"There is already a Bank with the name '{name}'!");
                return;
            }
            Bank bank = new Bank(name, company);
            banks.Add(name, bank);
        }

        public static Bank GetBank(string name) {
            banks.TryGetValue(name, out Bank bank);
            if(bank == null)
                Console.WriteLine("Unknown Bank!");
            return bank;
        }

        public static void DeleteBank(string name) {
            banks.TryGetValue(name, out Bank bank);
            if(bank == null) {
                Console.WriteLine("Unknown Bank!");
            } else {
                //only deletes reference
                Console.WriteLine($"Deleted Bank! [{bank.GetInfo()}]");
                banks.Remove(name);
            }
        }

        public static string GetBanks() {
            string allBanks = "All banks: ";
            foreach(string bankName in banks.Keys)
                allBanks += bankName + ", ";
            allBanks = allBanks.Substring(0, allBanks.Length - 2);
            return allBanks;
        }

    }
}
