using FoccoEmFrente.Kanban.Application.Context;
using FoccoEmFrente.Kanban.Application.Entities.Atividade2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Repositories.Atividade2Repositories
{
    public class FunctionaryRepository : IFunctionaryRepository
    {
        protected readonly KanbanContext DbContext;
        protected readonly DbSet<Functionary> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;
        public FunctionaryRepository(KanbanContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<Functionary>();
        }

        public Functionary Add(Functionary functionary)
        {
            var entry = DbSet.Add(functionary);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public async Task<IEnumerable<Functionary>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Functionary> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public Functionary Remove(Functionary functionary)
        {
            var entry = DbSet.Remove(functionary);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public Functionary Update(Functionary functionary)
        {
            var entry = DbSet.Update(functionary);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

    }
}
