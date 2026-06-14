using ECE.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECE.Cliente.API.Models
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);

        Task<Endereco> ObterEnderecoPorId(Guid id);
        void AdicionarEndereco(Endereco endereco);
    }
}
