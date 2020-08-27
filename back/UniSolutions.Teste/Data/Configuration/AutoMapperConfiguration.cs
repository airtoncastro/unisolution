using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UniSolutions.Teste.Data.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static Action<IMapperConfigurationExpression> GetMapperConfiguration()
        {
            return (config) => config.ForAllMaps((type, map) =>
            {
                IgnoreAllPropertiesWithAnInaccessibleSetter(map, type);
            });
        }

        private static bool HasAnInaccessibleSetter(PropertyInfo property)
        {
            var setMethod = property.GetSetMethod(true);
            return setMethod == null || setMethod.IsPrivate || setMethod.IsFamily;
        }

        private static void IgnoreAllPropertiesWithAnInaccessibleSetter(IMappingExpression map, TypeMap type)
        {
            var properties = type.DestinationType.GetProperties().Where(HasAnInaccessibleSetter);
            foreach (var property in properties)
                map.ForMember(property.Name, opt => opt.Ignore());
        }
    }
}
