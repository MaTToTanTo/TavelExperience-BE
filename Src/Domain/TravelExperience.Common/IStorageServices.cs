using System.Linq.Expressions;
namespace TravelExperience.Common
{
    public interface IStorageServices<Entity>
    {
        public Task<Entity> ReadByIdAsync(Guid id);
        public Task<List<Entity>> ReadAllAsync();
        public Task<List<Entity>> ReadBySearchAsync(Expression<Func<Entity,bool>>filters);
        public Task<Entity> ReadWithInclude(Guid id);
        public Task CreateAsync(Entity entity);
        public Task UpdateAsync(Entity entity);
        public Task DeleteAsync(Guid id);


    }
}
