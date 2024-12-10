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
            var resultadoMapeado = _mapper.Map<IEnumerable<UsuarioDto>>(res);
            return resultadoMapeado;
        }
        public async Task<UsuarioDto> GetUsuarioById(Guid id)
        {
            var res = _context.Usuarios.Find(id);
            var resMapeado = _mapper.Map<UsuarioDto>(res);
            return resMapeado;
        }

        public async Task<bool> Create(UsuarioModel usuario)
        {
            usuario.DataInclusao = DateTime.Now;
            _context.Add(usuario);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> Update(UsuarioModel usuario)
        {
            _context.Usuarios.Update(usuario);
            var res = _context.SaveChanges();
            return res > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;
            _context.Usuarios.Remove(usuario);
            var res = _context.SaveChanges();
            return res > 0;

        }
    }
}
