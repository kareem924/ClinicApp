using System;
using System.Linq.Expressions;
using Framework.Models.Result;
using Framework.Models.Entity;
using Framework.UnitOfWork;
namespace Framework.CrudService
{
    public abstract class CrudService<TDto, TEntity, TPrimaryKey>
            where TDto : IDto<TPrimaryKey>
            where TEntity : class, IPoco<TPrimaryKey>
            where TPrimaryKey : struct
    {
        internal IRepository<TEntity> Repository;
        internal IUnitOfWork Ouw;
        public TDto CurrentModel { get; set; }
        public ValidationResult Result { get; set; }

        protected CrudService(IRepository<TEntity> repository, IUnitOfWork ouw)
        {
            Repository = repository;
            Ouw = ouw;
            Result = new ValidationResult();
        }
        public abstract TEntity MapModelToEntity(TDto model);
        public abstract TDto MapEntityToModel(TEntity entity);

        public virtual ValidationResult Add(TDto model)
        {
            try
            {
                CurrentModel = model;
                ValidateInsert();
                if (!Result.IsValid) return Result;
                var enitiy = MapModelToEntity(model);
                Repository.Add(enitiy);
                Result.ObjectModel = MapEntityToModel(enitiy);
                Ouw.Commit();
                Result.EntityId = MapEntityToModel(enitiy).Id;
                return Result;
            }
            catch (Exception e)
            {

                Result.Add(e);
                return Result;
            }
        }
        public virtual ValidationResult Update(TDto model)
        {
            try
            {
                CurrentModel = model;
                ValidateUpdate();
                if (!Result.IsValid) return Result;

                Repository.Update(MapModelToEntity(model), model.Id);
                Ouw.Commit();
                Result.EntityId = model.Id;
                return Result;
            }
            catch (Exception e)
            {

                Result.Add(e);
                return Result;
            }
        }
        public virtual ValidationResult Delete(TPrimaryKey id)
        {
            try
            {
                ValidateDelete();
                if (!Result.IsValid) return Result;
                var entityToUpdate =  Repository.Get(id);
                entityToUpdate.IsDeleted = true;
                Ouw.Commit();
                return Result;
            }
            catch (Exception e)
            {

                Result.Add(e);
                return Result;
            }
        }
        public  TDto GetById(object id)
        {

            TEntity query = Repository.Get(id);
            if (query != null)
            {
                return MapEntityToModel(query);

            }
            return CurrentModel;
        }
        protected abstract void ValidateDelete();
        protected abstract void ValidateInsert();
        protected abstract void ValidateUpdate();
    }
}
