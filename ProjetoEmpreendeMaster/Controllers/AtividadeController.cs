using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreendeMaster.DTO;
using ProjetoEmpreendeMaster.Interfaces;
using ProjetoEmpreendeMaster.Models;
using System.Buffers.Text;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;

namespace ProjetoEmpreendeMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeRepository _atividadeRepository;

        public AtividadeController(IAtividadeRepository atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Atividade> atividades = _atividadeRepository.getAtividades();

            if(atividades.Count == 0)
                return NotFound();

            return Ok(atividades);
        }

        [HttpGet("{id}")]
        public IActionResult GetAtividade(int id)
        {
            Atividade atividade = _atividadeRepository.GetAtividade(id);

            if(atividade == null) 
                return NotFound();

            return Ok(atividade);
        }

        [HttpGet("{estudante_id}")]
        public IActionResult GetAtividadeByEstudante(int estudante_id)
        {
            List<Atividade> atividades = _atividadeRepository.GetAtividadeByEstudante(estudante_id);

            if(atividades.Count == 0)
                return NotFound();

            return Ok(atividades);
        }

        [HttpGet("{educador_id}")]
        public IActionResult GetAtividadeByEducador(int educador_id)
        {
            List<Atividade> atividades = _atividadeRepository.GetAtividadeByEducador(educador_id);

            if (atividades.Count == 0)
                return NotFound();

            return Ok(atividades);
        }

        [HttpGet]
        [Route("AtividadesUsuario")]
        public IActionResult GetAtividadesEstudante(int estudante_id)
        {
            AtividadesUsuarioDTO atividades = _atividadeRepository.GetAtividadesEstudante(estudante_id);

            return Ok(atividades);
        }

        [HttpGet]
        [Route("AtividadesUsuarioEducador")]
        public IActionResult GetAtividadesEducador(int educador_id)
        {
            AtividadesUsuarioDTO atividades = _atividadeRepository.GetAtividadesEducador(educador_id);

            return Ok(atividades);
        }

        [HttpPost]
        [Route("AdicionarAtividade")]
        public IActionResult AdicionarAtividade(AdicionarAtividadeDTO adicionarAtividade)
        {
            var arquivoAt = Encoding.UTF8.GetBytes(adicionarAtividade.Arquivo);

            Atividade atividade = new Atividade
            {
                EstudanteId = adicionarAtividade.EstudanteId,
                EducadorId = adicionarAtividade.EducadorId,
                Nome = adicionarAtividade.Nome,
                ArquivoAtividade = arquivoAt
            };

            _atividadeRepository.AdicionarAtividade(atividade);

            return Ok();
        }

        [HttpPost]
        [Route("ConcluirAtividade")]
        public IActionResult ConcluirAtividade(Atividade atividade)
        {
            _atividadeRepository.UpdateAtividade(atividade);

            return Ok("Atividade Concluída!");
        }

        [HttpPut]
        [Route("AtualizarAtividade")]
        public IActionResult AtualizarAtividade(Atividade atividade)
        {
            _atividadeRepository.UpdateAtividade(atividade);

            return Ok("Correção Enviada!");
        }        
        
        [HttpPut]
        [Route("AtualizarAtividadeCorrecao")]
        public IActionResult AtualizarAtividade(AtualizarAtividadeDTO atividadeAtualizacao)
        {
            var arquivoAt = Encoding.UTF8.GetBytes(atividadeAtualizacao.ArquivoAtualizacao);

            Atividade atividade = atividadeAtualizacao.Atividade;
            atividade.ArquivoAtividadeCorrecao = arquivoAt;

            _atividadeRepository.UpdateAtividade(atividade);

            return Ok("Correção Enviada!");
        }

        [HttpGet]
        [Route("GetArquivoCorrecao")]
        public IActionResult GetArquivoCorrecao(int atividadeId)
        {
            ArquivoDTO arquivoCorrecao = _atividadeRepository.GetArquivoAtividadeCorrecao(atividadeId);

            return Ok(arquivoCorrecao.Arquivo);
        }

        [HttpGet]
        [Route("GetArquivoAtividade")]
        public IActionResult GetArquivoAtividade(int atividadeId)
        {
            byte[] arquivoCorrecao = _atividadeRepository.GetArquivoAtividade(atividadeId);

            return Ok(arquivoCorrecao);
        }
    }
}
