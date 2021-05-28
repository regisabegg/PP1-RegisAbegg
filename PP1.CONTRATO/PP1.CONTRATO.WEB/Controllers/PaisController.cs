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
            model.dtCadastro = DateTime.Now;
            model.dtAtualizacao = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new Pais());
                    var bll = new BLL.PaisBLL();
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
        public ActionResult Edit(PaisVM model)
        {

            if (ModelState.IsValid)
            {
                model.dtAtualizacao = DateTime.Now;
                try
                {
                    // TODO: Add update logic here
                    var bean = model.VM2E(new Pais());
                    var bll = new BLL.PaisBLL();
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

        // POST: Pais/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region MethodPrivate
        private ActionResult GetView(int id)
        {

            

            PaisDAO objPais = new PaisDAO();
            var  obj = objPais.FindID(id);
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



        public JsonResult JsSearch([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                //var query = context.Empresa.AsQueryable();
                //var filter = requestModel.Search.Value;
                //if (!string.IsNullOrEmpty(filter))
                //{
                //    int id;
                //    if (int.TryParse(filter, out id))
                //    {
                //        query = query.Where(u => u.id == id);
                //    }
                //    else
                //    {
                //        query = query.Where(u => u.Nome.ToLower().Contains(filter.ToLower()) || u.Estado.nmEstado.ToLower().Contains(filter.ToLower()));
                //    }
                //}
                //var select = query.Select(u => new
                //{
                //    u.id,
                //    u.Nome,
                //    u.RazaoSocial,
                //    u.CNPJ

                //});

                //return Json(new DataTablesResponse(requestModel, select), JsonRequestBehavior.AllowGet);

                var select = this.Find();

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

        private IQueryable<dynamic> Find()
        {
            var daoPaises = new PaisBLL();
            var list = daoPaises.findAll();
            var select = list.Select(u => new
            {
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
