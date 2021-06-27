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
using PP1.CONTRATO.WEB.Models.Funcionario;
using PP1.CONTRATO.WEB.Util;

namespace PP1.CONTRATO.WEB.Controllers
{

    public class FuncionarioController : Controller
    {


        FuncionarioBLL objFuncionarioBLL;
        public FuncionarioController()
        {
            objFuncionarioBLL = new FuncionarioBLL();
        }
        // GET: Clube
        public ActionResult Index()
        {

            return View();
        }


        // GET: Funcionario/Details/5
        public ActionResult Details(int id)
        {
            return this.GetView(id);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(FuncionarioVM model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var bean = model.VM2E(new Funcionario());
                    var bll = new FuncionarioBLL();
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
        // GET: Funcionario/Edit/5
        public ActionResult Edit(int id)
        {
            return this.GetView(id);
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FuncionarioVM model)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add update logic here
                    FuncionarioDAO objFuncionario = new FuncionarioDAO();
                    var obj = objFuncionario.FindID(id);

                    var bean = model.VM2E(obj);
                    var bll = new FuncionarioBLL();
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

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            return this.GetView(id);
        }

        // POST: Funcionario/Delete/5

        [HttpPost]
        public ActionResult Delete(FuncionarioVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var bean = model.VM2E(new Funcionario());
                    var daoFuncionario = new FuncionarioDAO();
                    daoFuncionario.Delete(model.idPai);

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
            FuncionarioDAO objFuncionario = new FuncionarioDAO();
            CidadeDAO DAOCidade = new CidadeDAO();
            var obj = objFuncionario.FindID(id);
            var result = new FuncionarioVM
            {
                idPai = obj.idFuncionario,
                nmPessoa = obj.nmFuncionario,
                nmApelido = obj.nmApelido,
                flInstrucao = obj.flInstrucao,
                flCivil = obj.flCivil,
                flSexo = obj.flSexo,
                dtNascimento = obj.dtNascimento,
                dsImagem = obj.dsImagem,
                //nmapelido = obj.imagem,
                //Documentos
                nrCPF = obj.nrDocumento,
                nrRG = obj.nrRegistro,
                nmOrgaoRG = obj.nmOrgaoRG,
                nrCTPS = obj.nrCTPS,
                nrPIS = obj.nrPIS,
                nmOrgaoCTPS = obj.nmOrgaoCTPS,
                nrTitulo = obj.nrTitulo,
                nrZona = obj.nrZona,
                nrSecao = obj.nrSecao,
                //Filiação
                nmMae = obj.nmMae,
                nmPai = obj.nmPai,
                //Endereço
                nrCEP = obj.nrCEP,
                nmLogradouro = obj.nmLogradouro,
                nrNumero = obj.nrNumero,
                nmBairro = obj.nmBairro,
                dsComplemento = obj.dsComplemento,
                idCidade = obj.idCidade,
                //Contato
                nrTelefone = obj.nrTelefone,
                nrCelular = obj.nrCelular,
                dsEmail = obj.dsEmail,
                dsSite = obj.dsSite,
                dsLinkedin = obj.dsLinkedin,
                dsFacebook = obj.dsFacebook,
                dsInstagram = obj.dsInstagram,
                //Emergência
                nmContato = obj.nmContato,
                flContato = obj.flContato,
                nrFoneEmergecia = obj.nrFoneEmergecia,
                nrCelularEmergecia = obj.nrCelularEmergecia,
                //Admissão
                dtAdmissao = obj.dtAdmissao,
                dtDemissao = obj.dtDemissao,
                nmFuncao = obj.nmFuncao,
                nmDepartamento = obj.nmDepartamento,
                flExperiencia = obj.flExperiencia,
                //Bancários
                nmBanco = obj.nmBanco,
                flTipoConta = obj.flTipoConta,
                nrAgencia = obj.nrAgencia,
                nrConta = obj.nrConta,
                nrDigito = obj.nrDigito,
                nrPIX = obj.nrPix,
                //Geral
                dsObservacao = obj.dsObservacao,
                flSituacao = obj.flSituacao,
                dtCadastro = obj.dtCadastro,
                dtAtualizacao = obj.dtAtualizacao

            };
            var objCidade = DAOCidade.FindID(result.idCidade);
            result.Cidade = new Models.Cidade.ConsultaVM { id = objCidade.idCidade, text = objCidade.nmCidade };
            return View(result);
        }
        #endregion


        #region JsonResult

        public JsonResult JsCreate(FuncionarioVM model)
        {

            try
            {
                var bean = model.VM2E(new Funcionario());
                var bll = new FuncionarioBLL();
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
                var daoFuncionario = new CidadeBLL();
                var select = daoFuncionario.find(id);
                return Json(select, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw new Exception(ex.Message);
            }
        }


        public JsonResult JsEdit(FuncionarioVM model)
        {
            try
            {
                var bll = new FuncionarioBLL();
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
            var daoFuncionario = new FuncionarioBLL();
            var list = daoFuncionario.findAll();
            var select = list.Select(u => new
            {
                id = u.idFuncionario,
                text = u.nmFuncionario,
                u.idFuncionario,
                u.nmFuncionario,
                u.nmApelido,
                u.flInstrucao,
                u.flCivil,
                u.flSexo,
                u.dtNascimento,
                u.dsImagem,
                //nmapelido = u.imagem,
                //Documentos
                u.nrDocumento,
                u.nrRegistro,
                u.nmOrgaoRG,
                u.nrCTPS,
                u.nrPIS,
                u.nmOrgaoCTPS,
                u.nrTitulo,
                u.nrZona,
                u.nrSecao,
                //Filiação
                u.nmMae,
                u.nmPai,
                //Endereço
                u.nrCEP,
                u.nmLogradouro,
                u.nrNumero,
                u.nmBairro,
                u.dsComplemento,
                u.idCidade,
                //Contato
                u.nrTelefone,
                u.nrCelular,
                u.dsEmail,
                u.dsSite,
                u.dsLinkedin,
                u.dsFacebook,
                u.dsInstagram,
                //Emergência
                u.nmContato,
                u.flContato,
                u.nrFoneEmergecia,
                u.nrCelularEmergecia,
                //Admissão
                u.dtAdmissao,
                u.dtDemissao,
                u.nmFuncao,
                u.nmDepartamento,
                u.flExperiencia,
                //Bancários
                u.nmBanco,
                u.flTipoConta,
                u.nrAgencia,
                u.nrConta,
                u.nrDigito,
                u.nrPix,
                //Geral
                u.dsObservacao,
                u.flSituacao,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idFuncionario).ToList();
            return select.AsQueryable();
        }


        private IQueryable<dynamic> Filter(string filter)
        {
            var daoFuncionario = new FuncionarioBLL();
            var list = daoFuncionario.findFilter(filter);
            var select = list.Select(u => new
            {
                id = u.idFuncionario,
                text = u.nmFuncionario,
                u.idFuncionario,
                u.nmFuncionario,
                u.nmApelido,
                u.flInstrucao,
                u.flCivil,
                u.flSexo,
                u.dtNascimento,
                u.dsImagem,
                //nmapelido = u.imagem,
                //Documentos
                u.nrDocumento,
                u.nrRegistro,
                u.nmOrgaoRG,
                u.nrCTPS,
                u.nrPIS,
                u.nmOrgaoCTPS,
                u.nrTitulo,
                u.nrZona,
                u.nrSecao,
                //Filiação
                u.nmMae,
                u.nmPai,
                //Endereço
                u.nrCEP,
                u.nmLogradouro,
                u.nrNumero,
                u.nmBairro,
                u.dsComplemento,
                u.idCidade,
                //Contato
                u.nrTelefone,
                u.nrCelular,
                u.dsEmail,
                u.dsSite,
                u.dsLinkedin,
                u.dsFacebook,
                u.dsInstagram,
                //Emergência
                u.nmContato,
                u.flContato,
                u.nrFoneEmergecia,
                u.nrCelularEmergecia,
                //Admissão
                u.dtAdmissao,
                u.dtDemissao,
                u.nmFuncao,
                u.nmDepartamento,
                u.flExperiencia,
                //Bancários
                u.nmBanco,
                u.flTipoConta,
                u.nrAgencia,
                u.nrConta,
                u.nrDigito,
                u.nrPix,
                //Geral
                u.dsObservacao,
                u.flSituacao,
                u.dtCadastro,
                u.dtAtualizacao

            }).OrderBy(u => u.idFuncionario).ToList();
            return select.AsQueryable();
        }


        #endregion

    }
}
