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
    /*
     Por ser um projeto Razor os pageModel funcionam  dentro da hieraquia,
     Esse controle e para fazer a rota dos menus superios em qualquer nível das paginas 
     razor
    */
    
    [Route("router")]
    public class RoterController:Controller
    {
        
        [HttpGet]
        [Route("getemprestimo")]
        public IActionResult GetEmprestimosIndex()
        {
            return Redirect("../Emprestimos");
        }
        [HttpGet]
        [Route("getbeneficiarios")]
        public IActionResult GetBeneficiariosIndex()
        {
            return Redirect("../Beneficiarios");
        }
        [HttpGet]
        [Route("getpagamentos")]
        public  IActionResult GetPagamentosIndex()
        {
            return Redirect("../Pagamentos");
        }
        [HttpGet]
        [Route("getsituacoes")]
        public IActionResult GetSituacoesIndex()
        {
            return Redirect("../Situacoes");
        }
    }
}
