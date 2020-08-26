using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UniSolutions.Teste.Data.EF.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }

        public static void SetDefaultColumnsPropertiesSqlServer(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var entityConfig = modelBuilder.Entity(entityType.ClrType);

                foreach (var property in entityType.GetProperties())
                {
                    entityConfig.Property(property.Name)
                        .IsRequired();

                    if (property.ClrType == typeof(String))
                    {
                        entityConfig.Property(property.Name)
                            .HasMaxLength(256);
                    }

                    if (property.ClrType == typeof(DateTime))
                    {
                        //Maior parte das vezes usamos apenas a data, e não a hora/minuto, então por default fica date, o que melhora consultas e outras coisas 
                        entityConfig.Property(property.Name)
                        .HasColumnType("date");
                    }
                }
            }
        }
    }
}
