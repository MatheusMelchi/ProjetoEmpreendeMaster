using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreendeMaster.Interfaces;
using ProjetoEmpreendeMaster.Models;

namespace ProjetoEmpreendeMaster.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }


        [HttpGet]
        [Route("TipoUsuario")]
        public IActionResult TipoUsuarios()
        {
            List<TipoUsuario> tipoUsuarios = _tipoUsuarioRepository.GetTipoUsuarios();

            if(tipoUsuarios.Count == 0)
                return NotFound();

            return Ok(tipoUsuarios);
        }
    }
}
