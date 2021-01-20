using System;
using System.Text.RegularExpressions;

namespace Bank {
    class CommandHandler {

        static readonly string namePattern = @"^[a-zA-Z]*$";
        static readonly string passwordPattern = @"^[a-zA-Z0-9\w]*";
        static readonly string idPattern = @"^[0-9]+$";
        static readonly string doublePattern = @"^[+-]?[0-9]+(,[0-9]+)?$";
        static readonly string uDoublePattern = @"^[0-9]+(,[0-9]+)?$";
        static string[] parameters;

        static readonly string[] help = {
            "",
            "-------|Help|-------",
            "help",
            "createBank {name} {company}",
            "deleteBank {name}",
            "getBanks",
            "{bank} getInfo",
            "{bank} getName",
            "{bank} getCompany",
            "{bank} getAccounts",
            "{bank} createAccount {name} {password}",
            "{bank} createAccount {name} {password} {startBalance}",
            "{bank} payInterests {rate}",
            "{bank} {id} {password} getInfo",
            "{bank} {id} {password} getID",
            "{bank} {id} {password} getOwner",
            "{bank} {id} {password} getBalance",
            "{bank} {id} {password} addBalance {amount}",
            "{bank} {id} {password} removeBalance {amount}",
            "{bank} {id} {password} clearBalance {amount}",
            "{bank} {id} {password} deleteAccount",
            "--------------------",
            ""
        };

        static Tuple<string[], Action>[] commandIdetifiers = new Tuple<string[], Action>[] {

            new Tuple<string[], Action>(new string[] { "^help$"}, () => {
                foreach(string line in help)
                    Console.WriteLine(line);
            }),

            new Tuple<string[], Action>(new string[] { "^createBank$", namePattern, namePattern}, () => {
                Program.CreateBank(parameters[1], parameters[2]);
            }),

            new Tuple<string[], Action>(new string[] { "^deleteBank$", namePattern}, () => {
                Program.DeleteBank(parameters[1]);
            }),

            new Tuple<string[], Action>(new string[] { "^getBanks$"}, () => {
                Console.WriteLine(Program.GetBanks());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, "^getInfo$"}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    Console.WriteLine(Program.GetBank(parameters[0]).GetInfo());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, "^getName$"}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    Console.WriteLine(Program.GetBank(parameters[0]).GetName());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, "^getCompany$"}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    Console.WriteLine(Program.GetBank(parameters[0]).GetCompany());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, "^getAccounts$"}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    Console.WriteLine(Program.GetBank(parameters[0]).GetAccounts());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, "^createAccount$", namePattern, passwordPattern}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    Program.GetBank(parameters[0]).CreateAccount(parameters[2], parameters[3], 0);
            }),

            new Tuple<string[], Action>(new string[] { namePattern, "^createAccount$", namePattern, passwordPattern, doublePattern}, () => {
                if(Program.GetBank(parameters[0]) != null) 
                    Program.GetBank(parameters[0]).CreateAccount(parameters[2], parameters[3], double.Parse(parameters[4]));
            }),

            new Tuple<string[], Action>(new string[] { namePattern, "^payInterests$", uDoublePattern}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    Program.GetBank(parameters[0]).PayInterests(double.Parse(parameters[2]));
            }),

            new Tuple<string[], Action>(new string[] { namePattern, idPattern, passwordPattern, "^getInfo$"}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    if(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]) != null)
                        Console.WriteLine(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]).GetInfo());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, idPattern, passwordPattern, "^getID$" }, () => {
                if(Program.GetBank(parameters[0]) != null)
                    if(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]) != null)
                        Console.WriteLine(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]).GetID());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, idPattern, passwordPattern, "^getOwner$" }, () => {
                if(Program.GetBank(parameters[0]) != null)
                    if(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]) != null)
                        Console.WriteLine(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]).GetOwner());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, idPattern, passwordPattern, "^getBalance$" }, () => {
                if(Program.GetBank(parameters[0]) != null)
                    if(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]) != null)
                        Console.WriteLine(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]).GetBalance());
            }),

            new Tuple<string[], Action>(new string[] { namePattern, idPattern, passwordPattern, "^addBalance$", uDoublePattern}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    if(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]) != null)
                        Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]).AddBalance(double.Parse(parameters[4]));
            }),

            new Tuple<string[], Action>(new string[] { namePattern, idPattern, passwordPattern, "^removeBalance$", uDoublePattern}, () => {
                if(Program.GetBank(parameters[0]) != null)
                    if(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]) != null)
                        Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]).RemoveBalance(double.Parse(parameters[4]));
            }),

            new Tuple<string[], Action>(new string[] { namePattern, idPattern, passwordPattern, "^clearBalance$" }, () => {
                if(Program.GetBank(parameters[0]) != null)
                    if(Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]) != null)
                        Program.GetBank(parameters[0]).GetAccount(ushort.Parse(parameters[1]), parameters[2]).ClearBalance();
            }),

            new Tuple<string[], Action>(new string[] { namePattern, idPattern, passwordPattern, "^deleteAccount$" }, () => {
                if(Program.GetBank(parameters[0]) != null)
                    Program.GetBank(parameters[0]).DeleteAccount(ushort.Parse(parameters[1]), parameters[2]);
            }),

        };

        public static void HandleCommand(string command) {
            parameters = NormalizeCommand(command).Split(' ');


            foreach(Tuple<string[], Action> commandIdetifier in commandIdetifiers) {
                //check commands with same parameter length for right regex of parameters
                if(commandIdetifier.Item1.Length == parameters.Length && CheckParametersForRegex(commandIdetifier.Item1)) {
                    //pass parameters to Action
                    commandIdetifier.Item2();
                    //break
                    return;
                }

            }
            Console.WriteLine("Invalid command or parameter! Type 'help' for all commands.");
        }

        static string NormalizeCommand(string command) {
            //  allow . to be ,
            command = command.Replace(".", ",");
            //  remove unnessecary spaces at beginning
            while(command.StartsWith(" "))
                command = command.Substring(1, command.Length - 1);
            //remove unnessecary spaces at end
            while(command.EndsWith(" "))
                command = command.Substring(0, command.Length - 1);
            //remove multiple spaces
            while(command.Contains("  "))
                command = command.Replace("  ", " ");

            return command;
        }

        static bool CheckParametersForRegex(string[] regexs) {
            for(int i = 0; i < parameters.Length; i++) {
                if(!Regex.IsMatch(parameters[i], regexs[i]))
                    return false;
            }
            return true;
        }

    }
}
