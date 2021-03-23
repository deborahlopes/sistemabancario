using SistemaBancario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Classes
{
    public class conta
    {
        private tipoconta tipoconta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public conta(tipoconta Tipoconta, double saldo, double credito, string nome)
        {
            this.tipoconta = Tipoconta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            // validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        { 
            string retorno = " ";
            retorno += "TipoConta " + this.tipoconta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }
}