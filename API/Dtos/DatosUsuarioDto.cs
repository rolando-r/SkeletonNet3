namespace API.Dtos;
public class DatosUsuarioDto
{
    public string Mensaje { get; set; }
    public bool EstaAutenticado { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiry { get; set; }
}