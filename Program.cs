using System;
using System.Collections.Generic;

namespace dioBank
{
    class Program
    {
        static List<Account> accountList = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch(userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        WireTransfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "L":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentException("Essa não é uma opção válida!");
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Legal, obrigado por utilizar nossos serviços! ;)");
            Console.WriteLine();            
        }

        private static void Deposit()
        {
            Console.Write("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double depositValue = double.Parse(Console.ReadLine());

            accountList[accountIndex].Deposit(depositValue);
        }

        private static void Withdraw()
        {
            Console.Write("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            accountList[accountIndex].Withdraw(withdrawValue);
        }

        private static void WireTransfer()
        {
            Console.Write("Digite o número da conta de origem: ");
            int originAccountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int  destinyAccountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double transferValue = double.Parse(Console.ReadLine());

            accountList[originAccountIndex].WireTransfer(transferValue, accountList[destinyAccountIndex]);
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int accountTypeIndex = int.Parse(Console.ReadLine());
            AccountType enumIndex = (AccountType)Enum.ToObject(typeof(AccountType), accountTypeIndex);

            Console.Write("Digite o Nome do Cliente: ");
            string insertName = Console.ReadLine();

            Console.Write("Digite o saldo inical: ");
            double initialBalance = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito: ");
            double initialCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(
                                            type: (AccountType)accountTypeIndex,
                                            balance: initialBalance,
                                            credit: initialCredit,
                                            name: insertName);

            accountList.Add(newAccount);
        }

        private static void ListAccounts()
        {
            Console.WriteLine("Listar contas");

            if(accountList.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada! Cadastre uma nova conta.");
                return;
            }

            for (int i = 0; i < accountList.Count; i++)
            {
                Account account = accountList[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static string GetUserOption()
            {
                Console.WriteLine();
                Console.WriteLine("Bem vindo ao DIO Bank! Estamos felizes por ter você! =D");
                Console.WriteLine();

                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("1- Listar contas");
                Console.WriteLine("2- Inserir nova conta");
                Console.WriteLine("3- Tranferir");
                Console.WriteLine("4- Sacar");
                Console.WriteLine("5- Depositar");
                Console.WriteLine("L- Limpar Tela");
                Console.WriteLine("X- Sair");

                string userOption = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return userOption;
            }
    }
}
