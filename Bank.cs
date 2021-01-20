﻿using System;
using System.Collections.Generic;

namespace Bank {
    class Bank {

        string name;
        string company;
        public Dictionary<ushort, Account> accounts = new Dictionary<ushort, Account>();     //<-can be public because i will introduce passwords


        //  constructor
        public Bank(string name, string company) {
            this.name = name;
            this.company = company;
            Console.WriteLine($"Created a bank! [{GetInfo()}]");
        }
        // info
        public string GetInfo() => $"name:'{name}', company:'{company}'";

        public string GetName() => name;

        public string GetCompany() => company;

        public string GetAccounts() {
            string allAccounts = "All registered accounts: ";
            foreach(ushort accountID in accounts.Keys)
                allAccounts += accountID.ToString() + ", ";
            allAccounts = allAccounts.Substring(0, allAccounts.Length - 2);
            return allAccounts;
        }
        //  actions
        public void CreateAccount(string owner, string password, double startBalance) {
            
            Account account = new Account(owner, password, startBalance, this);
        }

        public Account GetAccount(ushort id, string password) {
            accounts.TryGetValue(id, out Account account);
            if(account == null)
                Console.WriteLine("Unknown ID!");
            if(!account.CheckPassword(password)) {
                Console.WriteLine("Wrong password!");
                return null;
            }
            return account;
        }

        public void DeleteAccount(ushort id, string password) {
            accounts.TryGetValue(id, out Account account);
            if(account == null) {
                Console.WriteLine("Unknown ID!");
            } else if(!account.CheckPassword(password)) {
                Console.WriteLine("Wrong password!");
                return;
            } else {
                //only deletes reference
                Console.WriteLine($"Deleted Account! [{account.GetInfo()}]");
                accounts.Remove(id);
            }
        }

        public void PayInterests(double factor) {
            ++factor;
            double paidInterest = 0;
            foreach(Account account in accounts.Values) {
                paidInterest += account.PayInterest(factor);
            }
            Console.WriteLine($"Successfully paid interest! [accounts:'{accounts.Count}', total paid interest:'{paidInterest}']");
        }
    }
}