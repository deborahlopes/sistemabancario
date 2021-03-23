using SistemaBancario.Classes;
using SistemaBancario.Enums;
using System;
using System.Collections.Generic;

namespace SistemaBancario
{
    class Program
    {
        static List<conta> listContas = new List<conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        TransferirConta();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utlizar nossos serviços");
            Console.ReadLine();
        }

        private static void TransferirConta()
        {
            Console.WriteLine("Digite o numero da Conta de origem:");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino:");
            int indiceDestino = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser transferido:");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceOrigem].Transferir(valorTransferencia, listContas[indiceDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da Conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {

            Console.WriteLine("Digite o numero da Conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            conta novaConta = new conta(Tipoconta: (tipoconta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhum conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }    
    }
}
