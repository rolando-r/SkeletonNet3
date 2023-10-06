using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace Infrastructure.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    private readonly BaseContext _context;

    public UsuarioRepository(BaseContext context) : base(context)
    {
        _context = context;
    }
        public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
                            .Include(u=>u.Roles)
                            .FirstOrDefaultAsync(u=>u.Username.ToLower()==username.ToLower());
    }
}
