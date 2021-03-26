using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Silva",
                Telefone = "1351896"
            },
            new Aluno(){
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "6841684"
            },
            new Aluno(){
                Id = 1,
                Nome = "João",
                Sobrenome = "Ferreira",
                Telefone = "8416544"
            }
        };
        public AlunoController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromQuery]int id){
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null) return BadRequest($"O Aluno de Id: {id} não foi encontrado");

            return Ok(aluno);
        }
        
        
        [HttpGet("ByName")]
        /*se eu não defini os parametros na rota, logo será definido que eles serão passado via query string
        */
        public IActionResult GetByName(string nome, string sobrenome){
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if(aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno){
            return Ok(aluno);
        }  
    }
}