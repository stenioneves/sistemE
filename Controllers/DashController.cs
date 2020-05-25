using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using sistemE.Models;
using sistemE.Data;

namespace sistemE.Controllers
{   
    [ApiController]
    [Route("api/dash")]
     public class DashController: ControllerBase
    {

       
       [HttpGet]
       [Route("emprestimo")]
       public async Task <ActionResult<IEnumerable<Object>> > GetEmprestimos([FromServices]ApplicationDbContext context, string nome) 
       {   var  query = from e in context.Emprestimos
       join  b in context.Beneficiarios on e.Solicitante equals b.Id
       join s in context.Situacaos on e.status equals s.Id
        select new {e.Id,e.ValorSolicitado,e.qtd,e.Observacao,b.Nome,s.Descricao,e.Autorizado};
          if(nome != null) //pesquisa por nome
          {
            query = from e in context.Emprestimos
       join  b in context.Beneficiarios on e.Solicitante equals b.Id
       join s in context.Situacaos on e.status equals s.Id where b.Nome.StartsWith(nome)
        select new {e.Id,e.ValorSolicitado,e.qtd,e.Observacao,b.Nome,s.Descricao,e.Autorizado};
        
          }
          
           return await query.ToListAsync();
          
       }
       [HttpGet]
       [Route("parcelas")]
       public async Task<ActionResult<IEnumerable<Pagamento>>>GetPagamentosEmprestimo([FromServices]ApplicationDbContext context,int id)
       {
           var query =from p in context.Pagamentos
           where p.Idemprestimo == id
          
           select p;
           return await  query.ToListAsync();
       }
       
        
    }
}
