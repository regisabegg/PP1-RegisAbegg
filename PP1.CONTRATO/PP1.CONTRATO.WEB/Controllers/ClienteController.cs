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
using PP1.CONTRATO.WEB.Models.Cliente;
using PP1.CONTRATO.WEB.Util;

namespace PP1.CONTRATO.WEB.Controllers
{

    public class ClienteController : Controller
    {


        ClienteBLL objClienteBLL;
        public ClienteController()
        {
            objClienteBLL = new ClienteBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteVM model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new Cliente());
                    var bll = new ClienteBLL();
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
        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClienteVM model)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add update logic here
                    ClienteDAO objCliente = new ClienteDAO();
                    var obj = objCliente.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new ClienteBLL();
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }

        // POST: Cliente/Delete/5

        [HttpPost]
        public ActionResult Delete(ClienteVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var bean = model.VM2E(new Cliente());
                    var daoCliente = new ClienteDAO();
                    daoCliente.Delete(model.idPai);

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
            ClienteDAO objCliente = new ClienteDAO();
            CidadeDAO DAOCidade = new CidadeDAO();
            var obj = objCliente.FindID(id);
            var result = new ClienteVM
            {
                idPai = obj.idCliente,
                nmPessoa = obj.nmCliente,


                nrTelefone = obj.nrTelefone,
                nrCelular = obj.nrCelular,
                dsEmail = obj.dsEmail,

                dsObservacao = obj.dsObservacao,
                flTipo = obj.flTipo,
                dsTipo = (obj.flTipo == Cliente.TIPO_FISICA ? "FÍSICA" : "JURÍDICA"),
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
                Fisica = new ClienteVM.PessoaFisicaVM
                {
                    nmApelido = obj.nmApelido,
                    nrCPF = obj.nrDocumento,
                    nrRG = obj.nrRegistro,
                    dtNascimento = obj.dtNascimento,
                    flSexo = obj.flSexo
                },
                Juridica = new ClienteVM.PessoaJuridicaVM
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

        public JsonResult JsCreate(ClienteVM model)
        {

            try
            {
                var bean = model.VM2E(new Cliente());
                var bll = new ClienteBLL();
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
                var daoCliente = new CidadeBLL();
                var select = daoCliente.find(id);
                return Json(select, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult JsEdit(ClienteVM model)
        {
            try
            {
                var bll = new ClienteBLL();
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
            var daoCliente = new ClienteBLL();
            var list = daoCliente.findAll();
            var select = list.Select(u => new
            {
                id = u.idCliente,
                text = u.nmCliente,
                u.idCliente,
                u.nmCliente,
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

            }).OrderBy(u => u.idCliente).ToList();
            return select.AsQueryable();
        }


        private IQueryable<dynamic> Filter(string filter)
        {
            var daoCliente = new ClienteBLL();
            var list = daoCliente.findFilter(filter);
            var select = list.Select(u => new
            {
                id = u.idCliente,
                text = u.nmCliente,
                u.idCliente,
                u.nmCliente,
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

            }).OrderBy(u => u.idCliente).ToList();
            return select.AsQueryable();
        }


        #endregion

    }
}
