namespace Core.Interfaces;
public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUsuarioRepository Usuarios { get; }    
    Task<int> SaveAsync();
}