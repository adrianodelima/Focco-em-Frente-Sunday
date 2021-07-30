using FoccoEmFrente.Kanban.Application.Entities.Atividade2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Repositories.Atividade2Repositories
{
    public interface IFunctionaryRepository : IRepository<Client>
    {
        Task<IEnumerable<Functionary>> GetAllAsync();
        Task<Functionary> GetByIdAsync(Guid id);
        Functionary Add(Functionary functionary);
        Functionary Update(Functionary functionary);
        Functionary Remove(Functionary functionary);
    }
}
