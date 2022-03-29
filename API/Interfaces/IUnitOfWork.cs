using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
   public interface IUnitOfWork
    {
        IBoundingBoxRepository BoundingBoxRepository { get; }
        ILabelsRepository LabelsRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        IPolygonRepository PolygonRepository { get; }
        IUserProjectRepository UserProjectRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
