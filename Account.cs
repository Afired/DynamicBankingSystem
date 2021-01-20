using System;

namespace Bank {
    class Account {

        string password;
        public ushort ID { get; }
        public string Owner { get; }
        public double Balance { get; private set; } = 0;
        Bank bank;

        //  constructor
        public Account(string owner, string password, double startBalance, Bank sender, ushort id) {
            bank = sender;
            ID = id;
            this.password = password;
            Owner = owner;
            Balance = startBalance;

            Console.WriteLine($"Created account at the bank '{bank.Name}'! [{GetInfo()}]");
        }

        //  info
        public string GetInfo() => $"id:'{ID}', owner:'{Owner}', balance:'{Balance}'";
        //  actions
        public void AddBalance(double amount) {
            Balance += amount;
            Console.WriteLine($"Added {amount} to the account! New balance: '{Balance}'");
        }

        public void RemoveBalance(double amount) {
            Balance -= amount;
            Console.WriteLine($"Removed {amount} from the account! New balance: '{Balance}'");
        }

        public void ClearBalance() {
            Console.WriteLine($"Cleared balance from the account! Removed: '{Balance}'");
            Balance = 0;
        }

        public double PayInterest(double factor) {
            double addBalance = Balance * (factor - 1);
            Balance += addBalance;
            return addBalance;
        }

        public bool CheckPassword(string password) => password == this.password;
    }
}
