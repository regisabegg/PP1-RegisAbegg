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
using PP1.CONTRATO.WEB.Models.Pais;
using PP1.CONTRATO.WEB.Util;

namespace PP1.CONTRATO.WEB.Controllers
{
    public class PaisController : Controller
    {
        PaisDAO daoPaises = new PaisDAO();

        PaisBLL objPaisBLL;
        public PaisController()
        {
            objPaisBLL = new PaisBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        public ActionResult Create(PaisVM model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var bean = model.VM2E(new Pais());
                    var bll = new PaisBLL();
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
        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: Pais/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PaisVM model)
        {

            if (ModelState.IsValid)
            {
                
                try
                {
                    // TODO: Add update logic here
                    PaisDAO objPais = new PaisDAO();
                    var obj = objPais.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new PaisBLL();
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

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }


        [HttpPost]
        public ActionResult Delete(PaisVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    

                    // TODO: Add update logic here
                    var bean = model.VM2E(new Pais());
                    var daoPais = new PaisDAO();
                    daoPais.Delete(model.idPais);

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
            PaisDAO objPais = new PaisDAO();
            var obj = objPais.FindID(id);
            var result = new PaisVM
            {
                idPais = obj.idPais,
                nmPais = obj.nmPais,
                dsSigla = obj.dsSigla,
                nrDDI = obj.nrDDI,
                dtCadastro = obj.dtCadastro,
                dtAtualizacao = obj.dtAtualizacao,
            };
            return View(result);
        }
        #endregion


        #region JsonResult
        public JsonResult JsCreate(PaisVM model)
        {

            try
            {
                var bean = model.VM2E(new Pais());
                var bll = new PaisBLL();
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
                var select = this.Find( q);
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

                var select = this.Find(null);
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
                var daoPaises = new PaisBLL();
                var select = daoPaises.find(id);
                return Json(select, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult JsEdit(PaisVM model)
        {
            try
            {
                var bll = new BLL.PaisBLL();
                var bean = bll.find(model.idPais);
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

                var select = this.Find(filter);

                var totalResult = select.Count();

                var result = select.OrderBy(requestModel.Columns, requestModel.Start, requestModel.Length).ToList();

                return Json(new DataTablesResponse(requestModel.Draw, result, totalResult, result.Count), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }


        }

        private IQueryable<dynamic> Find(string filter)
        {
            var daoPaises = new PaisBLL();
            var list = daoPaises.findAll();
            var select = list.Select(u => new
            {
                id = u.idPais,
                text = u.nmPais,
                u.idPais,
                u.nmPais,
                u.nrDDI,
                u.dsSigla,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idPais).ToList();
            return select.AsQueryable();
        }
        #endregion

    }
}
