using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ProjetoEmpreendeMaster.DTO;
using ProjetoEmpreendeMaster.Interfaces;
using ProjetoEmpreendeMaster.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEmpreendeMaster.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            ICollection<Usuario> usuarios = _usuarioRepository.GetUsuarios();

            if(!usuarios.Any())
                return NotFound();

            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Usuario")]
        public IActionResult GetUsuario(int Id)
        {
            if (Id == 0)
                return BadRequest("Id precisa ser especificado e precisa ser maior que zero (0)");

            Usuario usuario = _usuarioRepository.GetUsuario(Id);

            if(usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            _usuarioRepository.PostUsuario(usuario);

            return Ok();
        }

        [HttpPost]
        [Route("AutenticacaoUsuario")]
        public IActionResult AutenticacaoUsuario(LoginFiltroDTO model)
        {
            bool autenticacao = false;
            Usuario usuario = _usuarioRepository.AutenticarUsuario(model.Email, model.Senha);

            if(usuario != null)
                autenticacao = true;

            return Ok(new { Usuario = usuario, Autenticacao = autenticacao });
        }

        [HttpGet]
        [Route("UsuariosEstudantes")]
        public IActionResult UsuariosEstudante()
        {
            List<Usuario> estudantes = _usuarioRepository.UsuariosEstudantes();

            return Ok(estudantes);
        }
    }
}
