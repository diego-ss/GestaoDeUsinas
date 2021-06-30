using GestaoDeUsinas.Interfaces;
using GestaoDeUsinas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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

        public async Task<IActionResult> Index(int? fornecedorId, string ucusina, bool? ativo, int? pagina)
        {
            //parâmetros de paginação
            int qtdPorPagina = 4; // qtd máxima de itens por página
            int numeroPagina = (pagina ?? 1); // página atual

            try
            {
                if (_fornecedores == null)
                    _fornecedores = await _fornecedoresRepository.GetFornecedores();

                var usinas = await _usinasRepository.GetUsinasAsync();

                if (fornecedorId != null)
                    usinas = usinas.Where(x => x.FornecedorId == fornecedorId);

                if (ativo != null)
                    usinas = usinas.Where(x => x.Ativo == ativo);

                //passando a lista de fornecedores para a view
                ViewBag.Fornecedores = _fornecedores;
                return View(await usinas.ToPagedListAsync(numeroPagina, qtdPorPagina));
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
        
        public async Task<IActionResult> Edit(int id)
        {
            var usina = await _usinasRepository.GetUsinaByIdAsync(id);

            var fornecedores = await _fornecedoresRepository.GetFornecedores();
            ViewBag.Fornecedores = fornecedores;

            return View(usina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usina usina)
        {
            try
            {
                if (usina == null || usina.Id == 0)
                    return BadRequest("Parâmetros inválidos!");

                var findUsina = await _usinasRepository.GetUsinaByIdAsync(usina.Id);

                if(findUsina == null)
                {
                    ViewBag.EditMessage = "Usina não localizada.";
                    return BadRequest();
                }

                bool updated = await _usinasRepository.UpdateUsina(usina);

                if(updated)
                    return RedirectToAction("Index");

                ViewBag.EditMessage = "Falha ao atualizar usina";
                return View();
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro: " + ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var usina = await _usinasRepository.GetUsinaByIdAsync(Id);

                var fornecedores = await _fornecedoresRepository.GetFornecedores();
                ViewBag.Fornecedores = fornecedores;

                return View(usina);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUsina(int Id)
        {
            try
            {
                if (Id == 0)
                    return BadRequest("Parâmetros inválidos!");

                var deleted = await _usinasRepository.DeleteUsina(Id);

                if(deleted)
                    return RedirectToAction("Index");

                return StatusCode(500, "Falha ao deletar");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro: " + ex.Message);
            }
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
