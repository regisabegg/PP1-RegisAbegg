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
using PP1.CONTRATO.WEB.Models.Estado;
using PP1.CONTRATO.WEB.Util;

namespace PP1.CONTRATO.WEB.Controllers
{

    public class EstadoController : Controller
    {


        EstadoBLL objEstadoBLL;
        public EstadoController()
        {
            objEstadoBLL = new EstadoBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: Estado/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado/Create
        [HttpPost]
        public ActionResult Create(EstadoVM model)
        {
            model.dtCadastro = DateTime.Now;
            model.dtAtualizacao = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new Estado());
                    var bll = new BLL.EstadoBLL();
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
        // GET: Estado/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: Estado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EstadoVM model)
        {

            if (ModelState.IsValid)
            {
                model.dtAtualizacao = DateTime.Now;
                try
                {
                    // TODO: Add update logic here
                    EstadoDAO objEstado = new EstadoDAO();
                    var obj = objEstado.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new BLL.EstadoBLL();
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

        // GET: Estado/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }

        // POST: Estado/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {


                //objEstadoBLL = new EstadoBLL();
                //var obj = objEstadoBLL.delete(id);


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



            EstadoDAO objEstado = new EstadoDAO();
            var obj = objEstado.FindID(id);
            var result = new EstadoVM
            {
                idEstado = obj.idEstado,
                nmEstado = obj.nmEstado,
                dsUF = obj.dsUF,
                dtCadastro = obj.dtCadastro,
                dtAtualizacao = obj.dtAtualizacao,
                idPais = obj.idPais,
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
            var daoEstadoes = new EstadoBLL();
            var list = daoEstadoes.findAll();
            var select = list.Select(u => new
            {
                id = u.idEstado,
                text = u.nmEstado,
                u.idEstado,
                u.nmEstado,
                u.dsUF,
                u.dtCadastro,
                u.dtAtualizacao,
                u.idPais


            }).OrderBy(u => u.idEstado).ToList();
            return select.AsQueryable();
        }


        #endregion

    }
}
