using GestaoDeUsinas.Interfaces;
using GestaoDeUsinas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoDeUsinas.Controllers
{
    public class UsinasController : Controller
    {
        private readonly IUsinasRepository _usinasRepository;
        private readonly IFornecedoresRepository _fornecedoresRepository;

        private static IEnumerable<Fornecedor> _fornecedores;

        //utilizando injeção de dependências com os repositórios criados
        public UsinasController(IUsinasRepository usinasRepository, IFornecedoresRepository fornecedoresRepository)
        {
            this._usinasRepository = usinasRepository;
            this._fornecedoresRepository = fornecedoresRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var usinas = await _usinasRepository.GetUsinasAsync();

                if (_fornecedores == null)
                    _fornecedores = await _fornecedoresRepository.GetFornecedores();

                ViewBag.Fornecedores = _fornecedores;
                return View(usinas);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("Usinas/Pesquisa")]
        public async Task<IActionResult> Index(int? fornecedorId, bool ativo)
        {
            try
            {
                var usinas = await _usinasRepository.GetUsinasAsync();

                if (fornecedorId == null)
                    usinas = usinas.Where(x => x.Ativo == ativo);
                else
                    usinas = usinas.Where(x => x.FornecedorId == fornecedorId && x.Ativo == ativo);

                ViewBag.Fornecedores = _fornecedores;
                return View(usinas);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usina usina)
        {
            try
            {
                if ((await _usinasRepository.FindUsinaAsync(usina)) == null)
                {
                    if(usina.FornecedorId == 0)
                        return LoadCreateView("Dados inválidos!");

                    var add = await _usinasRepository.AddUsinaAsync(usina);

                    if (add)
                        return RedirectToAction("Index");

                    return StatusCode(500);
                }
                else
                {
                    return LoadCreateView("Usina já cadastrada!");
                }
            }
            catch(Exception ex)
            {
                return LoadCreateView("Erro ao adicionar usina: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var fornecedores = await _fornecedoresRepository.GetFornecedores();
            ViewBag.Fornecedores = fornecedores;

            return View();
        }

        private IActionResult LoadCreateView(string ErroCriacao = null)
        {
            if (ErroCriacao != null)
                ViewBag.CreateMessage = ErroCriacao;

            ViewBag.Fornecedores = _fornecedores;
            ModelState.Clear();
            return View("Create");
        }
    }
}
