using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using PP1.CONTRATO.BLL;
using PP1.CONTRATO.WEB.Models;
using PP1.CONTRATO.WEB.Util.DataTables;
using PP1.CONTRATO.WEB.Models.Fornecedor;
using PP1.CONTRATO.WEB.Util;

namespace PP1.CONTRATO.WEB.Controllers
{

    public class FornecedorController : Controller
    {


        FornecedorBLL objFornecedorBLL;
        public FornecedorController()
        {
            objFornecedorBLL = new FornecedorBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: Fornecedor/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(FornecedorVM model)
        {
            if (model.flTipo == Cliente.TIPO_JURIDICA)
            {
                if (Utils.ValidaCnpj(model.Juridica.nrCNPJ) == false)
                {
                    ModelState.AddModelError("Juridica.nrCNPJ", "O CNPJ informado é inválido. Por favor informe novamente o CNPJ!");
                    return View(model);
                }
            }
            else
            {
                if (Utils.ValidaCPF(model.Fisica.nrCPF) == false)
                {
                    ModelState.AddModelError("Fisica.nrCPF", "O CPF informado é inválido. Por favor informe novamente o CPF!");
                    return View(model);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new Fornecedor());
                    var bll = new FornecedorBLL();
                    bean.dtCadastro = DateTime.Now;
                    bean.dtAtualizacao = DateTime.Now;
                    bean.flSituacao = "A";
                    bll.create(bean);

                    this.AddFlashMessage("Registro salvo com sucesso!");
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    this.AddFlashMessage(ex.Message, FlashMessage.ERROR);
                    return View(model);
                }
            }
            return View(model);
        }
        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FornecedorVM model)
        {
            if (model.flTipo == Cliente.TIPO_JURIDICA)
            {
                if (Utils.ValidaCnpj(model.Juridica.nrCNPJ) == false)
                {
                    ModelState.AddModelError("Juridica.nrCNPJ", "O CNPJ informado é inválido. Por favor informe novamente o CNPJ!");
                    return View(model);
                }
            }
            else
            {
                if (Utils.ValidaCPF(model.Fisica.nrCPF) == false)
                {
                    ModelState.AddModelError("Fisica.nrCPF", "O CPF informado é inválido. Por favor informe novamente o CPF!");
                    return View(model);
                }
            }
            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add update logic here
                    FornecedorDAO objFornecedor = new FornecedorDAO();
                    var obj = objFornecedor.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new FornecedorBLL();
                    bean.dtAtualizacao = DateTime.Now;
                    bll.update(bean);

                    this.AddFlashMessage("Registro alterado com sucesso!");
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    this.AddFlashMessage(ex.Message, FlashMessage.ERROR);
                    return View(model);
                }
            }
            return View(model);


        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }

        // POST: Fornecedor/Delete/5

        [HttpPost]
        public ActionResult Delete(FornecedorVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var bean = model.VM2E(new Fornecedor());
                    var daoFornecedor = new FornecedorDAO();
                    daoFornecedor.Delete(model.idPai);

                    this.AddFlashMessage("Registro excluído com sucesso!");
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    this.AddFlashMessage(ex.Message, FlashMessage.ERROR);
                    return View(model);
                }
            }
            return View(model);

        }

        #region MethodPrivate
        private ActionResult GetView(int id)
        {
            FornecedorDAO objFornecedor = new FornecedorDAO();
            CidadeDAO DAOCidade = new CidadeDAO();
            var obj = objFornecedor.FindID(id);
            var result = new FornecedorVM
            {
                idPai = obj.idFornecedor,
                nmPessoa = obj.nmFornecedor,


                nrTelefone = obj.nrTelefone,
                nrCelular = obj.nrCelular,
                dsEmail = obj.dsEmail,

                dsObservacao = obj.dsObservacao,
                flTipo = obj.flTipo,
                dsTipo = (obj.flTipo == Fornecedor.TIPO_FISICA ? "FÍSICA" : "JURÍDICA"),
                flSituacao = obj.flSituacao,
                nrCEP = obj.nrCEP,
                nmLogradouro = obj.nmLogradouro,
                nrNumero = obj.nrNumero,
                nmBairro = obj.nmBairro,
                dsComplemento = obj.dsComplemento,
                vlLimite = obj.vlLimite,
                dtCadastro = obj.dtCadastro,
                dtAtualizacao = obj.dtAtualizacao,
                idCidade = obj.idCidade,
                Fisica = new FornecedorVM.PessoaFisicaVM
                {
                    nmApelido = obj.nmApelido,
                    nrCPF = obj.nrDocumento,
                    nrRG = obj.nrRegistro,
                    dtNascimento = obj.dtNascimento,
                    flSexo = obj.flSexo
                },
                Juridica = new FornecedorVM.PessoaJuridicaVM
                {
                    dsSite = obj.dsSite,
                    nmContato = obj.nmContato,
                    flContato = obj.flContato,
                    nrCNPJ = obj.nrDocumento,
                    nrIE = obj.nrRegistro,
                    nmFantasia = obj.nmApelido,

                }
            };
            var objCidade = DAOCidade.FindID(result.idCidade);
            result.Cidade = new Models.Cidade.ConsultaVM { id = objCidade.idCidade, text = objCidade.nmCidade };
            return View(result);
        }
        #endregion


        #region JsonResult

        public JsonResult JsCreate(FornecedorVM model)
        {

            try
            {
                var bean = model.VM2E(new Fornecedor());
                var bll = new FornecedorBLL();
                bean.dtCadastro = DateTime.Now;
                bean.dtAtualizacao = DateTime.Now;
                bll.create(bean);

                var result = new
                {
                    type = "success",
                    message = "Registro salvo com sucesso"
                };

                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                this.AddFlashMessage(ex.Message, FlashMessage.ERROR);

                var result = new
                {
                    type = "error",
                    message = ex.Message
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsSelect(string q, int? page, int? pageSize)
        {
            try
            {
                var select = this.Find();
                return Json(new JsonSelect<object>(select, page, pageSize), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult JsQuery([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {

                var select = this.Find();
                return Json(new DataTablesResponse(requestModel, select), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult jsDetails(int id)
        {
            try
            {
                var daoFornecedor = new CidadeBLL();
                var select = daoFornecedor.find(id);
                return Json(select, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult JsEdit(FornecedorVM model)
        {
            try
            {
                var bll = new FornecedorBLL();
                var bean = bll.find(model.idPai);
                bean = model.VM2E(bean);
                bean.dtAtualizacao = DateTime.Now;
                bll.update(bean);

                var result = new
                {
                    type = "success",
                    message = "Registro editado com sucesso"
                };

                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                this.AddFlashMessage(ex.Message, FlashMessage.ERROR);

                var result = new
                {
                    type = "error",
                    message = ex.Message
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsSearch([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                string filter = requestModel.Search.Value;
                if (!string.IsNullOrEmpty(filter))
                {
                    var select1 = this.Filter(filter);
                    var totalResult1 = select1.Count();

                    var result1 = select1.OrderBy(requestModel.Columns, requestModel.Start, requestModel.Length).ToList();

                    return Json(new DataTablesResponse(requestModel.Draw, result1, totalResult1, result1.Count), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var select = this.Find();

                    var totalResult = select.Count();

                    var result = select.OrderBy(requestModel.Columns, requestModel.Start, requestModel.Length).ToList();

                    return Json(new DataTablesResponse(requestModel.Draw, result, totalResult, result.Count), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }


        }

        private IQueryable<dynamic> Find()
        {
            var daoFornecedor = new FornecedorBLL();
            var list = daoFornecedor.findAll();
            var select = list.Select(u => new
            {
                id = u.idFornecedor,
                text = u.nmFornecedor,
                u.idFornecedor,
                u.nmFornecedor,
                u.nmApelido,
                u.nrDocumento,
                u.nrRegistro,
                u.nrTelefone,
                u.nrCelular,
                u.dsEmail,
                u.dsSite,
                u.nmContato,
                u.flContato,
                u.dsObservacao,
                u.flTipo,
                u.flSituacao,
                u.nrCEP,
                u.nmLogradouro,
                u.nrNumero,
                u.nmBairro,
                u.dsComplemento,
                u.vlLimite,
                u.dtCadastro,
                u.dtAtualizacao,
                u.dtNascimento,
                u.flSexo,
                u.idCidade

            }).OrderBy(u => u.idFornecedor).ToList();
            return select.AsQueryable();
        }


        private IQueryable<dynamic> Filter(string filter)
        {
            var daoFornecedor = new FornecedorBLL();
            var list = daoFornecedor.findFilter(filter);
            var select = list.Select(u => new
            {
                id = u.idFornecedor,
                text = u.nmFornecedor,
                u.idFornecedor,
                u.nmFornecedor,
                u.nmApelido,
                u.nrDocumento,
                u.nrRegistro,
                u.nrTelefone,
                u.nrCelular,
                u.dsEmail,
                u.dsSite,
                u.nmContato,
                u.flContato,
                u.dsObservacao,
                u.flTipo,
                u.flSituacao,
                u.nrCEP,
                u.nmLogradouro,
                u.nrNumero,
                u.nmBairro,
                u.dsComplemento,
                u.vlLimite,
                u.dtCadastro,
                u.dtAtualizacao,
                u.dtNascimento,
                u.flSexo,
                u.idCidade

            }).OrderBy(u => u.idFornecedor).ToList();
            return select.AsQueryable();
        }


        #endregion

    }
}
