namespace Core.Interfaces;
public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<Usuario> GetByUsernameAsync(string username);
}