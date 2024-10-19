using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UVV_Fintech_Project.Model
{
    internal class Cliente
    {
        private readonly int id;
        public readonly string nome;
        public readonly string sobrenome;
        public readonly string cpf;
        int anoNascimento;
        int diaNascimento;
        int mesNascimento;

        private string nomeCompleto;

        DateTime nascimento;

        public Cliente(string nome, string sobrenome, string cpf, int anoNascimento, int mesNascimento, int diaNascimento)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.cpf = cpf;

            nomeCompleto = nome + sobrenome;

            this.anoNascimento = anoNascimento;
            this.mesNascimento = mesNascimento;
            this.diaNascimento = diaNascimento;

            nascimento = new DateTime(anoNascimento, mesNascimento, diaNascimento);
        }

        public int CalcularIdade(DateTime dataNacimento)
        {
            DateTime dataDeHoje = DateTime.Today;
            int idade = dataDeHoje.Year - dataNacimento.Year;

            if (dataNacimento.Date > dataDeHoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }



        
    }
}
