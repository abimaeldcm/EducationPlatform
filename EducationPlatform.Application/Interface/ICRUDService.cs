namespace EducationPlatform.Application.Interface
{
    public interface ICRUDService<T, U> where T : class where U : class
    {
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task<T> Create(U create);
        Task<T> Update(int id,U update);
        Task<bool> Delete(int id);
    }
}
