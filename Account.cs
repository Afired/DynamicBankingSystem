using System;

namespace Bank {
    class Account {

        string password;
        ushort id;
        string owner;
        double balance = 0;
        Bank bank;

        //  constructor
        public Account(string owner, string password, double startBalance, Bank sender) {
            bank = sender;
            AsignRandomID();
            this.password = password;
            this.owner = owner;
            balance = startBalance;

            bank.accounts.Add(id, this);
            Console.WriteLine($"Created account at the bank '{bank.GetName()}'! [{GetInfo()}]");
        }

        void AsignRandomID() {
            Random random = new Random();

            ushort randomID;
            do {
                randomID = (ushort) random.Next(ushort.MinValue, ushort.MaxValue);
            } while (bank.accounts.ContainsKey(randomID) ? true : false);                                                  //<- produces infinit loop when all ushorts are asigned and the entire program will crash (this program will probably fail at another point before this happens, so idc)
            id = randomID;
        }
        //  info
        public string GetInfo() => $"id:'{id}', owner:'{owner}', balance:'{balance}'";

        public ushort GetID() => id;

        public double GetBalance() => balance;

        public string GetOwner() => owner;
        //  actions
        public void AddBalance(double amount) {
            balance += amount;
            Console.WriteLine($"Added {amount} to the account! New balance: '{GetBalance()}'");
        }

        public void RemoveBalance(double amount) {
            balance -= amount;
            Console.WriteLine($"Removed {amount} from the account! New balance: '{GetBalance()}'");
        }

        public void ClearBalance() {
            Console.WriteLine($"Cleared balance from the account! Removed: '{GetBalance()}'");
            balance = 0;
        }

        public double PayInterest(double factor) {
            double addBalance = balance * (factor - 1);
            balance += addBalance;
            return addBalance;
        }

        public bool CheckPassword(string password) => password == this.password;
    }
}
