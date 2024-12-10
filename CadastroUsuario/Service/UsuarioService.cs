using AutoMapper;
using CadastroUsuario.Core.Data;
using CadastroUsuario.Model;
using CadastroUsuario.Model.dto;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Service
{
    public class UsuarioService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UsuarioDto>> Get()
        {
            var res = await _context.Usuarios.ToListAsync();
            var resultadoMapeado = _mapper.Map< IEnumerable<UsuarioModel>, IEnumerable<UsuarioDto>>(res);
            return resultadoMapeado;
        }

        public async Task<bool> Create(UsuarioModel usuario)
        {
            usuario.DataInclusao = DateTime.Now;
            _context.Add(usuario);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
