using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UniSolutions.Teste.Api.Domain.Entities;

namespace UniSolutions.Teste.Data.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> MapAggregate<TSource, TDestination, TSourceMemberType, TDestinationMemberType>(
           this IMappingExpression<TSource, TDestination> map,
           Profile profile,
           Expression<Func<TSource, ICollection<TSourceMemberType>>> sourceMember,
           Expression<Func<TDestination, ICollection<TDestinationMemberType>>> destinationMember)
       where TSource : IEntity
       where TDestination : IEntity
       where TSourceMemberType : IEntity
       where TDestinationMemberType : IEntity
        {
            return map.MapAggregate<TSource, TDestination, TSourceMemberType, TDestinationMemberType, int>(profile, sourceMember, destinationMember);
        }

        public static IMappingExpression<TSource, TDestination> MapAggregate<TSource, TDestination, TSourceMemberType, TDestinationMemberType, TId>(
            this IMappingExpression<TSource, TDestination> map,
            Profile profile,
            Expression<Func<TSource, ICollection<TSourceMemberType>>> sourceMember,
            Expression<Func<TDestination, ICollection<TDestinationMemberType>>> destinationMember)
        where TSource : IEntity<TId>
        where TDestination : IEntity<TId>
        where TSourceMemberType : IEntity<TId>
        where TDestinationMemberType : IEntity<TId>
        {
            profile.CreateMap<TSourceMemberType, TDestinationMemberType>().ReverseMap();

            return map.ForMember(destinationMember, o => o.Ignore()).AfterMap((source, destination) =>
            {
                var destinationChilds = destinationMember.Compile().Invoke(destination) ?? new List<TDestinationMemberType>(); var sourceChilds = sourceMember.Compile().Invoke(source) ?? new List<TSourceMemberType>();

                if ((destination.Id == null || destination.Id.Equals(default(TId))) && sourceChilds.Count == destinationChilds.Count)
                    return;

                var childToRemove = destinationChilds.Where(e => !sourceChilds.Any(s => s.Id.Equals(e.Id))).ToArray();
                for (int i = 0; i < childToRemove.Count(); i++)
                {
                    destinationChilds.Remove(childToRemove[i]);
                }
            });
        }

    }
}
