﻿using JobBoardApp.Models;
using Microsoft.EntityFrameworkCore;
using JobBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobBoardApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(DatabaseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.Add(entity);
            context.SaveChanges();
           // context.Database.CommitTransaction();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            try
            {
                //entities.Update(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
            
           
        }
        public void Delete(Guid id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
