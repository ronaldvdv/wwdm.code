using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using WWDM.GraphQL.Schema;
using WWDM.Models;

namespace WWDM.GraphQL.Types
{
    public static class ResolverExtensions
    {
        private static MethodInfo _containsMethod = typeof(Enumerable).GetRuntimeMethods().Single(m => m.Name == nameof(Enumerable.Contains) && m.GetParameters().Length == 2).MakeGenericMethod(typeof(int));

        public static void ResolveOneToMany<TParent, TChild>(this IObjectFieldDescriptor parent, Expression<Func<TChild, int>> foreignKey, string keySuffix = "")
            where TParent : IEntity
            where TChild : class, IEntity
        {
            parent.Resolver((ctx, ct) =>
            {
                var set = ctx.Service<WWDMContext>().Set<TChild>();
                var parentId = ctx.Parent<TParent>().Id;
                var key = typeof(TParent).Name + "-to-" + typeof(TChild).Name + "-" + keySuffix;

                return ctx.GroupDataLoader<int, TChild>(key, async keys =>
                {
                    var parameter = foreignKey.Parameters.Single();
                    var subject = foreignKey.Body;
                    var predicate = Expression.Lambda<Func<TChild, bool>>(Expression.Call(_containsMethod, Expression.Constant(keys), subject), parameter);
                    var result = await set.Where(predicate).ToArrayAsync();
                    var lookup = result.ToLookup(foreignKey.Compile());
                    return lookup;
                }).LoadAsync(parentId, ct);
            });
        }

        public static void ResolveOneToOne<TParent, TChild>(this IObjectFieldDescriptor parent, Func<TParent, int> foreignKey, string keySuffix = "")
            where TParent : IEntity
            where TChild : class, IEntity
        {
            parent.Resolver((ctx, ct) =>
            {
                var set = ctx.Service<WWDMContext>().Set<TChild>();
                var parent = ctx.Parent<TParent>();
                var childId = foreignKey(parent);
                var key = typeof(TParent).Name + "-to-" + typeof(TChild).Name + "-" + keySuffix;

                return ctx.BatchDataLoader<int, TChild>(key, async keys =>
                {
                    var parameter = Expression.Parameter(typeof(TChild));
                    var idExpression = Expression.Property(parameter, nameof(IEntity.Id));
                    var predicate = Expression.Lambda<Func<TChild, bool>>(Expression.Call(_containsMethod, Expression.Constant(keys), idExpression), parameter);
                    var result = await set.Where(predicate).ToDictionaryAsync(c => c.Id);
                    return result;
                }).LoadAsync(childId, ct);
            });
        }
    }

    public class EpisodeType : ObjectType<Episode>
    {
        protected override void Configure(IObjectTypeDescriptor<Episode> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(e => e.Image).ResolveOneToOne<Episode, Image>(e => e.ImageId);
        }
    }

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(f => f.Hello()).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.GetSeasons(default));
        }
    }

    public class SeasonType : ObjectType<Season>
    {
        protected override void Configure(IObjectTypeDescriptor<Season> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(s => s.Episodes).ResolveOneToMany<Season, Episode>(e => e.SeasonId);
            descriptor.Field(s => s.Image).ResolveOneToOne<Season, Image>(s => s.ImageId);
        }
    }
}