using ArtesMarciais.Core.Helpers.Attributes;
using System.Reflection;

namespace ArtesMarciais.Core.Helpers
{
    public static class Mapper
    {
        public static void MapProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            var destinationProperties = typeof(TDestination).GetProperties();
            var sourceProperties = typeof(TSource).GetProperties();

            foreach (var destProp in destinationProperties)
            {
                var sourceProp = sourceProperties.FirstOrDefault(p => p.Name == destProp.Name);

                if (sourceProp != null && sourceProp.CanRead && destProp.CanWrite)
                {
                    // Verifica se a propriedade do destino tem o atributo NeverReplaced
                    if (destProp.GetCustomAttribute<NeverReplacedAttribute>() == null)
                    {
                        var newValue = sourceProp.GetValue(source);

                        // Garante que valores válidos sejam atribuídos
                        if (newValue != null && !newValue.Equals(GetDefaultValue(sourceProp.PropertyType)))
                        {
                            destProp.SetValue(destination, newValue);
                        }
                    }
                }
            }
        }

        // Método para obter valores padrão de tipos primitivos
        private static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
