﻿using CadastroUsuario.Core.Base.Controller;
using CadastroUsuario.Service;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _usuarioService.Get();
            return Ok(res);
        }
    }
}