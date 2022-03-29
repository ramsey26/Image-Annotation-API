using API.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public UnitOfWork(DataContext dataContext,IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public IBoundingBoxRepository BoundingBoxRepository => new BoundingBoxRepository(this.dataContext,this.mapper);

        public ILabelsRepository LabelsRepository => new LabelsRepository(this.dataContext, this.mapper);

        public IPhotoRepository PhotoRepository => new PhotoRepository(this.dataContext);

        public IPolygonRepository PolygonRepository => new PolygonRepository(this.dataContext, this.mapper);

        public IUserProjectRepository UserProjectRepository => new UserProjectRepository(this.dataContext, this.mapper);

        public IUserRepository UserRepository => new UserRepository(this.dataContext, this.mapper);

        public async Task<bool> Complete()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return dataContext.ChangeTracker.HasChanges();
        }
    }
}
