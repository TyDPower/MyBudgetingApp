using MyBudgetingApp.Shared.Dtos.WalletDtos;
using MyBudgetingApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetingApp.Shared.Dtos
{
    public class DtoMapper<TSource, TDestination>
    {
        public TDestination Map(TSource source)
        {
            // Create an instance of the destination type
            var destination = Activator.CreateInstance<TDestination>();

            // Get the properties of the source and destination types
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            // Map the properties of the source to the destination
            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);
                if (destinationProperty != null)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }

            return destination;
        }
    }


}
