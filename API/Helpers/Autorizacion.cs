namespace API.Helpers;

public class Autorizacion
{
    public enum Roles
    {
        Administrador,
        Gerente,
        Empleado
    }

    public const Roles rol_predeterminado = Roles.Empleado;
}
