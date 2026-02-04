using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.Common
{
    public interface IMapperServices<Entity, DTO>
    {
        public DTO ToDTO(Entity entity);
        public Entity ToEntity(DTO dto);
    }
}
