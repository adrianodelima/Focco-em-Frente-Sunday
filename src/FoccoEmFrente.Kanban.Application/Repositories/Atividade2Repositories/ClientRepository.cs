using FoccoEmFrente.Kanban.Application.Context;
using FoccoEmFrente.Kanban.Application.Entities.Atividade2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Repositories.Atividade2Repositories
{
    public class ClientRepository : IClientRepository
    {
        protected readonly KanbanContext DbContext;
        protected readonly DbSet<Client> DbSet;

        public ClientRepository(KanbanContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<Client>();
        }

        public IUnitOfWork UnitOfWork => DbContext;

        public Client Add(Client client)
        {
            var entry = DbSet.Add(client);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public Client Remove(Client client)
        {
            var entry = DbSet.Remove(client);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public Client Update(Client client)
        {
            var entry = DbSet.Update(client);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

    }
}
