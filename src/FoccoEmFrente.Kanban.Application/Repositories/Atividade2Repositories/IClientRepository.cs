using FoccoEmFrente.Kanban.Application.Entities.Atividade2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Repositories.Atividade2Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(Guid id);
        Client Add(Client client);
        Client Update(Client client);
        Client Remove(Client client);
    }
}
