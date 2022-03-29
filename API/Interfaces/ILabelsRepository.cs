using API.DTOs;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
   public interface ILabelsRepository
    {
        void Update(Label label);

        void Add(Label label);

        void Delete(Label label);

        Task<IEnumerable<LabelDto>> GetLabelByUserProjectId(int userProjectId);

      
    }
}
