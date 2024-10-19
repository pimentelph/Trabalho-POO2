using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UVV_Fintech_Project.Model;

namespace UVV_Fintech_Project.Persistencia
{
    internal class BD
    {
        // Persistência dos clientes <CPF, Nome
        Dictionary<string, string> persistenciaClientes = new();

        public void AdicionarCliente(string cpf, string nomeCompleto)
        {
            if (!persistenciaClientes.ContainsKey(cpf))
            {
                persistenciaClientes.Add(cpf, nomeCompleto);
                Console.WriteLine("Cliente adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("CPF já existe no sistema!");
            }
        }

        // Método para acessar um cliente
        public string ObterCliente(string cpf)
        {
            // Tenta buscar o cliente pelo CPF
            if (persistenciaClientes.TryGetValue(cpf, out string nomeCompleto))
            {
                return $"Cliente encontrado: {nomeCompleto}";
            }
            else
            {
                return "Cliente não encontrado!";
            }
        }







    }
}
