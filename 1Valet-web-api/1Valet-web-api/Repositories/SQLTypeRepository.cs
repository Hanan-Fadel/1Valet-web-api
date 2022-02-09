using _1Valet_web_api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _1Valet_web_api.Repositories
{
    public class SQLTypeRepository : ITypeRepository
    {
        private readonly DbContextClass context;
        public SQLTypeRepository(DbContextClass context)
        {
            this.context = context;

        }
        public List<Type> GetTypes()
        {
            return context.Type.ToList();
        }
    }
}
