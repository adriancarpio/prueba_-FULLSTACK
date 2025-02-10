using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MS_EF.Infrastructure.Utilidades
{
    public static class Mapeador
    {
        public static T Mapear<T>(this object objeto)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 64,
            };

            var serializar = JsonSerializer.Serialize(objeto, options);
            return JsonSerializer.Deserialize<T>(serializar, options)!;
        }
    }
}
