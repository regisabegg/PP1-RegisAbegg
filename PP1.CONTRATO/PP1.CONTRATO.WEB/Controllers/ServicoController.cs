using PP1.CONTRATO.BLL;
using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using PP1.CONTRATO.WEB.Models.Servico;
using PP1.CONTRATO.WEB.Util;
using PP1.CONTRATO.WEB.Util.DataTables;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Controllers
{
    public class ServicoController : Controller
    {
        ServicoDAO daoServicoes = new ServicoDAO();

        ServicoBLL objServicoBLL;
        public ServicoController()
        {
            objServicoBLL = new ServicoBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: Servico/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: Servico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servico/Create
        [HttpPost]
        public ActionResult Create(ServicoVM model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new Servico());
                    var bll = new ServicoBLL();
                    bean.dtCadastro = DateTime.Now;
                    bean.dtAtualizacao = DateTime.Now;
                    bean.flSituacao = Servico.SITUACAO_ATIVA;
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
        // GET: Servico/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: Servico/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ServicoVM model)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add update logic here
                    ServicoDAO objServico = new ServicoDAO();
                    var obj = objServico.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new ServicoBLL();
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

        // GET: Servico/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }


        [HttpPost]
        public ActionResult Delete(ServicoVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    // TODO: Add update logic here
                    var bean = model.VM2E(new Servico());
                    var daoServico = new ServicoDAO();
                    daoServico.Delete(model.idPai);

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
            ServicoDAO objServico = new ServicoDAO();
            var obj = objServico.FindID(id);
            var result = new ServicoVM
            {
                idPai = obj.idServico,
                nmServico = obj.nmServico,
                flSituacao = obj.flSituacao,
                vlServico = obj.vlServico,
                dtCadastro = obj.dtCadastro,
                dtAtualizacao = obj.dtAtualizacao,
            };

            return View(result);
        }
        #endregion


        #region JsonResult
        public JsonResult JsCreate(ServicoVM model)
        {

            try
            {
                var bean = model.VM2E(new Servico());
                var bll = new ServicoBLL();
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
                var daoServicoes = new ServicoBLL();
                var select = daoServicoes.find(id);
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


        public JsonResult JsEdit(ServicoVM model)
        {
            try
            {
                var bll = new BLL.ServicoBLL();
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
            var daoServicoes = new ServicoBLL();
            var list = daoServicoes.findAll();
            var select = list.Select(u => new
            {
                id = u.idServico,
                text = u.nmServico,
                u.idServico,
                u.nmServico,
                u.flSituacao,
                u.vlServico,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idServico).ToList();
            return select.AsQueryable();
        }



        private IQueryable<dynamic> Filter(string filter)
        {
            var daoServicoes = new ServicoBLL();
            var list = daoServicoes.findFilter(filter);
            var select = list.Select(u => new
            {
                id = u.idServico,
                text = u.nmServico,
                u.idServico,
                u.nmServico,
                u.flSituacao,
                u.vlServico,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idServico).ToList();
            return select.AsQueryable();
        }



        #endregion

    }
}
