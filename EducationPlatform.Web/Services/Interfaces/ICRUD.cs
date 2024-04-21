namespace EducationPlatform.Web.Services.Interfaces
{
    public interface ICRUD<O, I> where O : class where I : class
    {
        Task<O> BuscarPorId(int id);
        Task<IEnumerable<O>> BuscarPorTexto(string termoPesquisa);
        Task<IEnumerable<O>> BuscarTodos();
        Task<O> Cadastrar(I cadastrar);
        Task<bool> Delete(int id);
        Task<object> Editar(int id, I editar);
    }
}
