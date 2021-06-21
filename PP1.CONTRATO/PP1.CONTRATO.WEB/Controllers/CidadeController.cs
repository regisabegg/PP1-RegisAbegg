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
using PP1.CONTRATO.WEB.Models.Cidade;
using PP1.CONTRATO.WEB.Util;

namespace PP1.CONTRATO.WEB.Controllers
{

    public class CidadeController : Controller
    {


        CidadeBLL objCidadeBLL;
        public CidadeController()
        {
            objCidadeBLL = new CidadeBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: Cidade/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidade/Create
        [HttpPost]
        public ActionResult Create(CidadeVM model)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new Cidade());
                    var bll = new CidadeBLL();
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
        // GET: Cidade/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: Cidade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CidadeVM model)
        {

            if (ModelState.IsValid)
            {
                
                try
                {
                    // TODO: Add update logic here
                    CidadeDAO objCidade = new CidadeDAO();
                    var obj = objCidade.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new CidadeBLL();
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

        // GET: Cidade/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }

        // POST: Cidade/Delete/5

        [HttpPost]
        public ActionResult Delete(CidadeVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var bean = model.VM2E(new Cidade());
                    var daoCidade = new CidadeDAO();
                    daoCidade.Delete(model.idPai);

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
            CidadeDAO objCidade = new CidadeDAO();
            EstadoDAO DAOEstado = new EstadoDAO();
            var obj = objCidade.FindID(id);
            var result = new CidadeVM
            {
                idPai = obj.idCidade,
                nmCidade = obj.nmCidade,
                nrDDD = obj.nrDDD,
                nrIBGE = obj.nrIBGE,
                dtCadastro = obj.dtCadastro,
                dtAtualizacao = obj.dtAtualizacao,
                idEstado = obj.idEstado
            };
            var objEstado = DAOEstado.FindID(result.idEstado);
            result.Estado = new Models.Estado.ConsultaVM { id = objEstado.idEstado, text = objEstado.nmEstado };
            return View(result);
        }
        #endregion


        #region JsonResult

        public JsonResult JsCreate(CidadeVM model)
        {

            try
            {
                var bean = model.VM2E(new Cidade());
                var bll = new CidadeBLL();
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
                var daoCidade = new EstadoBLL();
                var select = daoCidade.find(id);
                return Json(select, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult JsEdit(CidadeVM model)
        {
            try
            {
                var bll = new CidadeBLL();
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
            var daoCidade = new CidadeBLL();
            var list = daoCidade.findAll();
            var select = list.Select(u => new
            {
                id = u.idCidade,
                text = u.nmCidade,
                u.idCidade,
                u.nmCidade,
                u.nrDDD,
                u.nrIBGE,
                u.dtCadastro,
                u.dtAtualizacao,
                u.idEstado


            }).OrderBy(u => u.idCidade).ToList();
            return select.AsQueryable();
        }


        private IQueryable<dynamic> Filter(string filter)
        {
            var daoCidade = new CidadeBLL();
            var list = daoCidade.findFilter(filter);
            var select = list.Select(u => new
            {
                id = u.idCidade,
                text = u.nmCidade,
                u.idCidade,
                u.nmCidade,
                u.nrDDD,
                u.nrIBGE,
                u.dtCadastro,
                u.dtAtualizacao,
                u.idEstado

            }).OrderBy(u => u.idCidade).ToList();
            return select.AsQueryable();
        }


        #endregion

    }
}
