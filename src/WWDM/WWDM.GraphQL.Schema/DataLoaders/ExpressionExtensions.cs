using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace WWDM.GraphQL.DataLoaders
{
    public static class ExpressionExtensions
    {
        private static MethodInfo _containsMethod = typeof(Enumerable).GetRuntimeMethods().Single(m => m.Name == nameof(Enumerable.Contains) && m.GetParameters().Length == 2).MakeGenericMethod(typeof(int));

        public static Expression<Func<TEntity, bool>> CreatePredicate<TEntity, TField>(this Expression<Func<TEntity, TField>> field, IReadOnlyList<TField> keys)
        {
            var parameter = field.Parameters.Single();
            var subject = field.Body;
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Call(_containsMethod, Expression.Constant(keys), subject), parameter);
        }

    }
}
