using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static Task<TEntity> Get<TEntity>(this IQueryable<TEntity> set, int? id) where TEntity : class, IEntity
        {
            if (id == null || id <= 0)
            {
                return null;
            }
            return set.FirstOrDefaultAsync(e => e.Id == id);
        }

        public static TEntity Get<TEntity>(this IEnumerable<TEntity> set, int? id) where TEntity : class, IEntity
        {
            if (id == null || id <= 0)
            {
                return null;
            }
            return set.FirstOrDefault(e => e.Id == id);
        }
    }
}