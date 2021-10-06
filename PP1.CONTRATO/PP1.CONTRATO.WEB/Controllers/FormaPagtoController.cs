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
using PP1.CONTRATO.WEB.Models.FormaPagto;
using PP1.CONTRATO.WEB.Util;

namespace PP1.CONTRATO.WEB.Controllers
{
    public class FormaPagtoController : Controller
    {
        FormaPagtoDAO daoFormaPagtoes = new FormaPagtoDAO();

        FormaPagtoBLL objFormaPagtoBLL;
        public FormaPagtoController()
        {
            objFormaPagtoBLL = new FormaPagtoBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: FormaPagto/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: FormaPagto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPagto/Create
        [HttpPost]
        public ActionResult Create(FormaPagtoVM model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new FormaPagto());
                    var bll = new FormaPagtoBLL();
                    bean.dtCadastro = DateTime.Now;
                    bean.dtAtualizacao = DateTime.Now;
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
        // GET: FormaPagto/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: FormaPagto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormaPagtoVM model)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add update logic here
                    FormaPagtoDAO objFormaPagto = new FormaPagtoDAO();
                    var obj = objFormaPagto.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new FormaPagtoBLL();
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

        // GET: FormaPagto/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }


        [HttpPost]
        public ActionResult Delete(FormaPagtoVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    // TODO: Add update logic here
                    var bean = model.VM2E(new FormaPagto());
                    var daoFormaPagto = new FormaPagtoDAO();
                    daoFormaPagto.Delete(model.idPai);

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
            FormaPagtoDAO objFormaPagto = new FormaPagtoDAO();
            var obj = objFormaPagto.FindID(id);
            var result = new FormaPagtoVM
            {
                idPai = obj.idFormaPagto,
                nmFormaPagto = obj.nmFormaPagto,
                flSituacao = obj.flSituacao,
                dtCadastro = obj.dtCadastro,
                dtAtualizacao = obj.dtAtualizacao,
            };
            return View(result);
        }
        #endregion


        #region JsonResult
        public JsonResult JsCreate(FormaPagtoVM model)
        {

            try
            {
                var bean = model.VM2E(new FormaPagto());
                var bll = new FormaPagtoBLL();
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
                var daoFormaPagtoes = new FormaPagtoBLL();
                var select = daoFormaPagtoes.find(id);
                if (select != null)
                {
                    return Json(select, JsonRequestBehavior.AllowGet);
                }
                return Json(string.Empty, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult JsEdit(FormaPagtoVM model)
        {
            try
            {
                var bll = new BLL.FormaPagtoBLL();
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
            var daoFormaPagtoes = new FormaPagtoBLL();
            var list = daoFormaPagtoes.findAll();
            var select = list.Select(u => new
            {
                id = u.idFormaPagto,
                text = u.nmFormaPagto,
                u.idFormaPagto,
                u.nmFormaPagto,
                u.flSituacao,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idFormaPagto).ToList();
            return select.AsQueryable();
        }



        private IQueryable<dynamic> Filter(string filter)
        {
            var daoFormaPagtoes = new FormaPagtoBLL();
            var list = daoFormaPagtoes.findFilter(filter);
            var select = list.Select(u => new
            {
                id = u.idFormaPagto,
                text = u.nmFormaPagto,
                u.idFormaPagto,
                u.nmFormaPagto,
                u.flSituacao,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idFormaPagto).ToList();
            return select.AsQueryable();
        }



        #endregion

    }
}
