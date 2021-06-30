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
using PP1.CONTRATO.WEB.Models.CondicaoPagto;
using PP1.CONTRATO.WEB.Util;

namespace PP1.CONTRATO.WEB.Controllers
{
    public class CondicaoPagtoController : Controller
    {
        CondicaoPagtoDAO daoCondicaoPagtoes = new CondicaoPagtoDAO();

        CondicaoPagtoBLL objCondicaoPagtoBLL;
        public CondicaoPagtoController()
        {
            objCondicaoPagtoBLL = new CondicaoPagtoBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: CondicaoPagto/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: CondicaoPagto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicaoPagto/Create
        [HttpPost]
        public ActionResult Create(CondicaoPagtoVM model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new CondicaoPagto());
                    var bll = new CondicaoPagtoBLL();
                    bean.dtCadastro = DateTime.Now;
                    bean.dtAtualizacao = DateTime.Now;
                    bean.flSituacao = CondicaoPagto.SITUACAO_ATIVA;
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
        // GET: CondicaoPagto/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: CondicaoPagto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CondicaoPagtoVM model)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add update logic here
                    CondicaoPagtoDAO objCondicaoPagto = new CondicaoPagtoDAO();
                    var obj = objCondicaoPagto.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new CondicaoPagtoBLL();
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

        // GET: CondicaoPagto/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }


        [HttpPost]
        public ActionResult Delete(CondicaoPagtoVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    // TODO: Add update logic here
                    var bean = model.VM2E(new CondicaoPagto());
                    var daoCondicaoPagto = new CondicaoPagtoDAO();
                    daoCondicaoPagto.Delete(model.idPai);

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
            CondicaoPagtoDAO objCondicaoPagto = new CondicaoPagtoDAO();
            //FormaPagtoDAO DAOFormaPagto = new FormaPagtoDAO();
            var obj = objCondicaoPagto.FindID(id);
            var result = new CondicaoPagtoVM
            {
                idPai = obj.idCondicaoPagto,
                nmCondicaoPagto = obj.nmCondicaoPagto,
                flSituacao = obj.flSituacao,
                txJuros = obj.txJuros,
                txMulta = obj.txMulta,
                dtCadastro = obj.dtCadastro,
                dtAtualizacao = obj.dtAtualizacao,
            };
            //var objFormaPagto = DAOFormaPagto.FindID(result.idFormaPagto);
            //result.FormaPagto = new Models.FormaPagto.ConsultaVM { id = objFormaPagto.idFormaPagto, text = objFormaPagto.nmFormaPagto };
            return View(result);
        }
        #endregion


        #region JsonResult
        public JsonResult JsCreate(CondicaoPagtoVM model)
        {

            try
            {
                var bean = model.VM2E(new CondicaoPagto());
                var bll = new CondicaoPagtoBLL();
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
                var daoCondicaoPagtoes = new CondicaoPagtoBLL();
                var select = daoCondicaoPagtoes.find(id);
                return Json(select, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult JsEdit(CondicaoPagtoVM model)
        {
            try
            {
                var bll = new BLL.CondicaoPagtoBLL();
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
            var daoCondicaoPagtoes = new CondicaoPagtoBLL();
            var list = daoCondicaoPagtoes.findAll();
            var select = list.Select(u => new
            {
                id = u.idCondicaoPagto,
                text = u.nmCondicaoPagto,
                u.idCondicaoPagto,
                u.nmCondicaoPagto,
                u.flSituacao,
                u.txJuros,
                u.txMulta,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idCondicaoPagto).ToList();
            return select.AsQueryable();
        }



        private IQueryable<dynamic> Filter(string filter)
        {
            var daoCondicaoPagtoes = new CondicaoPagtoBLL();
            var list = daoCondicaoPagtoes.findFilter(filter);
            var select = list.Select(u => new
            {
                id = u.idCondicaoPagto,
                text = u.nmCondicaoPagto,
                u.idCondicaoPagto,
                u.nmCondicaoPagto,
                u.flSituacao,
                u.txJuros,
                u.txMulta,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idCondicaoPagto).ToList();
            return select.AsQueryable();
        }



        #endregion

    }
}
