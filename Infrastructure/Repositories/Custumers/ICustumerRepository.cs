using Domain;
namespace Infrastructure.Repositories.Custumers
{
    public interface ICustumerRepository
    {
        public Task Add(Custumer input);
        public Task<Custumer> GetById(int id);
        public Task<List<Custumer>> GetAll();
        public Task Update(Custumer custumer);
        public Task Delete(int id);
    }
}
