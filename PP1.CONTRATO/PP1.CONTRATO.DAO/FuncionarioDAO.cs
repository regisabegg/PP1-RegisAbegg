using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class FuncionarioDAO : ConexaoDB
    {

        //Atributos
        //idFuncionario, nmFuncionario, dsUF, nrDDI, dtCadastro, dtAtualizacao, 

        //Método para gravar dados
        public void Insert(Funcionario obj)
        {
            try
            {
                findInsert(obj.nmFuncionario, obj.idFuncionario);

                OpenConection();
                Cmd = new SqlCommand("insert into funcionario (nmfuncionario, nmapelido, flinstrucao, flcivil, flsexo, dtnascimento, dsimagem," +
                    " nrdocumento, nrregistro, nmorgaorg, nrctps, nrpis, nmorgaoctps, nrtitulo, nrzona, nrsecao," +
                    "nmmae, nmpai, nrcep, nmlogradouro, nrnumero, nmbairro, dscomplemento," +
                    "nrtelefone, nrcelular, dsemail, dssite, dslinkedin, dsfacebook, dsinstagram, " +
                    "nmcontato, flcontato, nrfoneemergecia, nrcelularemergecia, " +
                    "dtadmissao, dtdemissao, nmfuncao, nmdepartamento, flexperiencia," +
                    "nmbanco, fltipoconta, nragencia, nrconta, nrdigito,  nrpix," +
                    "dsobservacao, flsituacao, dtcadastro, dtatualizacao, idcidade) " +
                    "values (@nmfuncionario, @nmapelido, @flinstrucao, @flcivil, @flsexo, @dtnascimento, @dsimagem," +
                    "@nrdocumento, @nrregistro, @nmorgaorg, @nrctps, @nrpis, @nmorgaoctps, @nrtitulo, @nrzona, @nrsecao," +
                    "@nmmae, @nmpai, @nrcep, @nmlogradouro, @nrnumero, @nmbairro, @dscomplemento," +
                    "@nrtelefone, @nrcelular, @dsemail, @dssite, @dslinkedin, @dsfacebook, @dsinstagram, " +
                    "@nmcontato, @flcontato, @nrfoneemergecia, @nrcelularemergecia, " +
                    "@dtadmissao, @dtdemissao, @nmfuncao, @nmdepartamento, @flexperiencia," +
                    "@nmbanco, @fltipoconta, @nragencia, @nrconta, @nrdigito, @nrpix," +
                    "@dsobservacao, @flsituacao, @dtcadastro, @dtatualizacao, @idcidade)", Con);

                Cmd.Parameters.AddWithValue("@nmfuncionario", obj.nmFuncionario);
                Cmd.Parameters.AddWithValue("@nmapelido", obj.nmApelido ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flinstrucao", obj.flInstrucao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flcivil", obj.flCivil ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flsexo", obj.flSexo ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtnascimento", ((object)obj.dtNascimento) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsimagem", !string.IsNullOrEmpty(obj.dsImagem) ? obj.dsImagem : obj.dsImagem = null);
                //Cmd.Parameters.AddWithValue("@nmapelido", obj.imagem ?? (object)DBNull.Value);
                //Documentos
                Cmd.Parameters.AddWithValue("@nrdocumento", obj.nrDocumento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrregistro", obj.nrRegistro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmorgaorg", obj.nmOrgaoRG ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrctps", obj.nrCTPS ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrpis", obj.nrPIS ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmorgaoctps", obj.nmOrgaoCTPS ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrtitulo", obj.nrTitulo ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrzona", obj.nrZona ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrsecao", obj.nrSecao ?? (object)DBNull.Value);
                //Filiação
                Cmd.Parameters.AddWithValue("@nmmae", obj.nmMae ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmpai", obj.nmPai ?? (object)DBNull.Value);
                //Endereço
                Cmd.Parameters.AddWithValue("@nrcep", obj.nrCEP ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmlogradouro", obj.nmLogradouro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrnumero", obj.nrNumero ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmbairro", obj.nmBairro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dscomplemento", obj.dsComplemento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@idcidade", ((object)obj.idCidade) ?? DBNull.Value);
                //Contato
                Cmd.Parameters.AddWithValue("@nrtelefone", obj.nrTelefone ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrcelular", obj.nrCelular ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsemail", obj.dsEmail ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dssite", obj.dsSite ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dslinkedin", obj.dsLinkedin ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsfacebook", obj.dsFacebook ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsinstagram", obj.dsInstagram ?? (object)DBNull.Value);
                //Emergência
                Cmd.Parameters.AddWithValue("@nmcontato", obj.nmContato ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flcontato", obj.flContato ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrfoneemergecia", obj.nrFoneEmergecia ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrcelularemergecia", obj.nrCelularEmergecia ?? (object)DBNull.Value);
                //Admissão
                Cmd.Parameters.AddWithValue("@dtadmissao", ((object)obj.dtAdmissao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtdemissao", ((object)obj.dtDemissao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmfuncao", obj.nmFuncao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmdepartamento", obj.nmDepartamento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flexperiencia", obj.flExperiencia ?? (object)DBNull.Value);
                //Bancários
                Cmd.Parameters.AddWithValue("@nmbanco", obj.nmBanco ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@fltipoconta", obj.flTipoConta ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nragencia", obj.nrAgencia ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrconta", obj.nrConta ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrdigito", obj.nrDigito ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrpix", obj.nrPix ?? (object)DBNull.Value);
                //Geral
                Cmd.Parameters.AddWithValue("@dsobservacao", obj.dsObservacao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao ?? (object)DBNull.Value);               
                Cmd.Parameters.AddWithValue("@dtcadastro", ((object)obj.dtCadastro) ?? DBNull.Value );
                Cmd.Parameters.AddWithValue("@dtatualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);

                //cmd.Parameters.Add("@units", SqlDbType.Int).Value = units ?? (object)DBNull.Value; 
                //cmd.Parameters.Add("@range", SqlDbType.Int).Value = range ?? (object)DBNull.Value;
                //cmd.Parameters.Add("@scale", SqlDbType.Int).Value = scale ?? (object)DBNull.Value; 
                //cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description ?? (object)DBNull.Value;



                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir o Funcionario: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para atualizar dados
        public void Update(Funcionario obj)
        {
            try
            {

                findInsert(obj.nmFuncionario, obj.idFuncionario);

                OpenConection();
                Cmd = new SqlCommand("update funcionario set nmfuncionario=@nmfuncionario, nmapelido=@nmapelido, flinstrucao=@flinstrucao, flcivil=@flcivil, flsexo=@flsexo, dtnascimento=@dtnascimento, dsimagem=@dsimagem," +
                    "nrdocumento=@nrdocumento, nrregistro=@nrregistro, nmorgaorg=@nmorgaorg, nrctps=@nrctps, nrpis=@nrpis, nmorgaoctps=@nmorgaoctps, nrtitulo=@nrtitulo, nrzona=@nrzona, nrsecao=@nrsecao," +
                    "nmmae=@nmmae, nmpai=@nmpai, nrcep=@nrcep, nmlogradouro=@nmlogradouro, nrnumero=@nrnumero, nmbairro=@nmbairro, dscomplemento=@dscomplemento," +
                    "nrtelefone=@nrtelefone, nrcelular=@nrcelular, dsemail=@dsemail, dssite=@dssite, dslinkedin=@dslinkedin, dsfacebook=@dsfacebook, dsinstagram=@dsinstagram, " +
                    "nmcontato=@nmcontato, flcontato=@flcontato, nrfoneemergecia=@nrfoneemergecia, nrcelularemergecia=@nrcelularemergecia, " +
                    "dtadmissao=@dtadmissao, dtdemissao=@dtdemissao, nmfuncao=@nmfuncao, nmdepartamento=@nmdepartamento, flexperiencia=@flexperiencia," +
                    "nmbanco=@nmbanco, fltipoconta=@fltipoconta, nragencia=@nragencia, nrconta=@nrconta, nrdigito=@nrdigito, nrpix=@nrpix," +
                    "dsobservacao=@dsobservacao, flsituacao=@flsituacao, dtcadastro=@dtcadastro, dtatualizacao=@dtatualizacao, idcidade=@idcidade " +
                    "where idfuncionario = @idfuncionario", Con);

                Cmd.Parameters.AddWithValue("@nmfuncionario", obj.nmFuncionario);
                Cmd.Parameters.AddWithValue("@nmapelido", obj.nmApelido ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flinstrucao", obj.flInstrucao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flcivil", obj.flCivil ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flsexo", obj.flSexo ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtnascimento", ((object)obj.dtNascimento) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsimagem", !string.IsNullOrEmpty(obj.dsImagem) ? obj.dsImagem : obj.dsImagem = null);
                //Cmd.Parameters.AddWithValue("@nmapelido", obj.imagem ?? (object)DBNull.Value);
                //Documentos
                Cmd.Parameters.AddWithValue("@nrdocumento", obj.nrDocumento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrregistro", obj.nrRegistro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmorgaorg", obj.nmOrgaoRG ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrctps", obj.nrCTPS ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrpis", obj.nrPIS ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmorgaoctps", obj.nmOrgaoCTPS ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrtitulo", obj.nrTitulo ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrzona", obj.nrZona ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrsecao", obj.nrSecao ?? (object)DBNull.Value);
                //Filiação
                Cmd.Parameters.AddWithValue("@nmmae", obj.nmMae ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmpai", obj.nmPai ?? (object)DBNull.Value);
                //Endereço
                Cmd.Parameters.AddWithValue("@nrcep", obj.nrCEP ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmlogradouro", obj.nmLogradouro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrnumero", obj.nrNumero ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmbairro", obj.nmBairro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dscomplemento", obj.dsComplemento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@idcidade", ((object)obj.idCidade) ?? DBNull.Value);
                //Contato
                Cmd.Parameters.AddWithValue("@nrtelefone", obj.nrTelefone ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrcelular", obj.nrCelular ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsemail", obj.dsEmail ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dssite", obj.dsSite ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dslinkedin", obj.dsLinkedin ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsfacebook", obj.dsFacebook ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsinstagram", obj.dsInstagram ?? (object)DBNull.Value);
                //Emergência
                Cmd.Parameters.AddWithValue("@nmcontato", obj.nmContato ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flcontato", obj.flContato ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrfoneemergecia", obj.nrFoneEmergecia ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrcelularemergecia", obj.nrCelularEmergecia ?? (object)DBNull.Value);
                //Admissão
                Cmd.Parameters.AddWithValue("@dtadmissao", ((object)obj.dtAdmissao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtdemissao", ((object)obj.dtDemissao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmfuncao", obj.nmFuncao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmdepartamento", obj.nmDepartamento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flexperiencia", obj.flExperiencia ?? (object)DBNull.Value);
                //Bancários
                Cmd.Parameters.AddWithValue("@nmbanco", obj.nmBanco ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@fltipoconta", obj.flTipoConta ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nragencia", obj.nrAgencia ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrconta", obj.nrConta ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrdigito", obj.nrDigito ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrpix", obj.nrPix ?? (object)DBNull.Value);
                //Geral
                Cmd.Parameters.AddWithValue("@dsobservacao", obj.dsObservacao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtcadastro", ((object)obj.dtCadastro) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtatualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@idfuncionario", ((object)obj.idFuncionario) ?? DBNull.Value);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o Funcionário: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para ecluir dados
        public void Delete(int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("delete from funcionario where idfuncionario = @v1", Con);

                Cmd.Parameters.AddWithValue("@v1", id);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o Funcionário: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar pelo Código
        public Funcionario FindID(int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from funcionario where idfuncionario=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();

                Funcionario obj = null;
                if (Dr.Read())
                {
                    obj = new Funcionario();

                    obj.idFuncionario = Convert.ToInt32(Dr["idfuncionario"]);
                    obj.nmFuncionario = Convert.ToString(Dr["nmfuncionario"] != DBNull.Value ? Dr["nmfuncionario"] : null);
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"] != DBNull.Value ? Dr["nmapelido"] : null);
                    obj.flInstrucao = Convert.ToString(Dr["flinstrucao"] != DBNull.Value ? Dr["flinstrucao"] : null);
                    obj.flCivil = Convert.ToString(Dr["flcivil"] != DBNull.Value ? Dr["flcivil"] : null);
                    obj.flSexo = Convert.ToString(Dr["flsexo"] != DBNull.Value ? Dr["flsexo"] : null);
                    obj.dtNascimento = Convert.ToDateTime(Dr["dtnascimento"] != DBNull.Value ? Dr["dtnascimento"] : null);
                    obj.dsImagem = Convert.ToString(Dr["dsimagem"] != null ? Dr["dsimagem"] : DBNull.Value);
                    //Documentos
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"] != DBNull.Value ? Dr["nrdocumento"] : null);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"] != DBNull.Value ? Dr["nrregistro"] : null);
                    obj.nmOrgaoRG = Convert.ToString(Dr["nmorgaorg"] != DBNull.Value ? Dr["nmorgaorg"] : null);
                    obj.nrCTPS = Convert.ToString(Dr["nrctps"] != DBNull.Value ? Dr["nrctps"] : null);
                    obj.nrPIS = Convert.ToString(Dr["nrpis"] != DBNull.Value ? Dr["nrpis"] : null);
                    obj.nmOrgaoCTPS = Convert.ToString(Dr["nmorgaoctps"] != DBNull.Value ? Dr["nmorgaoctps"] : null);
                    obj.nrTitulo = Convert.ToString(Dr["nrtitulo"] != DBNull.Value ? Dr["nrtitulo"] : null);
                    obj.nrZona = Convert.ToString(Dr["nrzona"] != DBNull.Value ? Dr["nrzona"] : null);
                    obj.nrSecao = Convert.ToString(Dr["nrsecao"] != DBNull.Value ? Dr["nrsecao"] : null);
                    //Filiação
                    obj.nmMae = Convert.ToString(Dr["nmmae"] != DBNull.Value ? Dr["nmmae"] : null);
                    obj.nmPai = Convert.ToString(Dr["nmpai"] != DBNull.Value ? Dr["nmpai"] : null);
                    //Endereço
                    obj.nrCEP = Convert.ToString(Dr["nrcep"] != DBNull.Value ? Dr["nrcep"] : null);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"] != DBNull.Value ? Dr["nmlogradouro"] : null);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"] != DBNull.Value ? Dr["nrnumero"] : null);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"] != DBNull.Value ? Dr["nmbairro"] : null);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"] != DBNull.Value ? Dr["dscomplemento"] : null);
                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);
                    //Contato
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"] != DBNull.Value ? Dr["nrtelefone"] : null);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"] != DBNull.Value ? Dr["nrcelular"] : null);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"] != DBNull.Value ? Dr["dsemail"] : null);
                    obj.dsSite = Convert.ToString(Dr["dssite"] != DBNull.Value ? Dr["dssite"] : null);
                    obj.dsLinkedin = Convert.ToString(Dr["dslinkedin"] != DBNull.Value ? Dr["dslinkedin"] : null);
                    obj.dsFacebook = Convert.ToString(Dr["dsfacebook"] != DBNull.Value ? Dr["dsfacebook"] : null);
                    obj.dsInstagram = Convert.ToString(Dr["dsinstagram"] != DBNull.Value ? Dr["dsinstagram"] : null);
                    //Emergência
                    obj.nmContato = Convert.ToString(Dr["nmcontato"] != DBNull.Value ? Dr["nmcontato"] : null);
                    obj.flContato = Convert.ToString(Dr["flcontato"] != DBNull.Value ? Dr["flcontato"] : null);
                    obj.nrFoneEmergecia = Convert.ToString(Dr["nrfoneemergecia"] != DBNull.Value ? Dr["nrfoneemergecia"] : null);
                    obj.nrCelularEmergecia = Convert.ToString(Dr["nrcelularemergecia"] != DBNull.Value ? Dr["nrcelularemergecia"] : null);
                    //Admissão (object)obj.dtCadastro) ?? DBNull.Value
                    obj.dtAdmissao = Convert.ToDateTime(Dr["dtadmissao"] != DBNull.Value ? Dr["dtadmissao"] : null);
                    obj.dtDemissao = (Dr["dtdemissao"] == DBNull.Value) ? (DateTime?)null: ((DateTime?)Dr["dtadmissao"]);
                    obj.nmFuncao = Convert.ToString(Dr["nmfuncao"] != DBNull.Value ? Dr["nmfuncao"] : null);
                    obj.nmDepartamento = Convert.ToString(Dr["nmdepartamento"] != DBNull.Value ? Dr["nmdepartamento"] : null);
                    obj.flExperiencia = Convert.ToString(Dr["flexperiencia"] != DBNull.Value ? Dr["flexperiencia"] : null);
                    //Bancários
                    obj.nmBanco = Convert.ToString(Dr["nmbanco"] != DBNull.Value ? Dr["nmbanco"] : null);
                    obj.flTipoConta = Convert.ToString(Dr["fltipoconta"] != DBNull.Value ? Dr["fltipoconta"] : null);
                    obj.nrAgencia = Convert.ToString(Dr["nragencia"] != DBNull.Value ? Dr["nragencia"] : null);
                    obj.nrConta = Convert.ToString(Dr["nrconta"] != DBNull.Value ? Dr["nrconta"] : null);
                    obj.nrDigito = Convert.ToString(Dr["nrdigito"] != DBNull.Value ? Dr["nrdigito"] : null);
                    obj.nrPix = Convert.ToString(Dr["nrpix"] != DBNull.Value ? Dr["nrpix"] : null);
                    //Geral
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"] != DBNull.Value ? Dr["dsobservacao"] : null);                
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"] != DBNull.Value ? Dr["flsituacao"] : null);                   
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"] != DBNull.Value ? Dr["dtcadastro"] : null);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"] != DBNull.Value ? Dr["dtatualizacao"] : null);
                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Funcionário: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        public List<Funcionario> FindFilter(string filter)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from funcionario where nmfuncionario like @v1 or  nmapelido like @v2 or nrdocumento like @v3", Con);
                Cmd.Parameters.AddWithValue("@v1", "%" + filter + "%");
                Cmd.Parameters.AddWithValue("@v2", "%" + filter + "%");
                Cmd.Parameters.AddWithValue("@v3", "%" + filter + "%");
                Dr = Cmd.ExecuteReader();

                List<Funcionario> list = new List<Funcionario>();

                while (Dr.Read())
                {
                    Funcionario obj = new Funcionario();

                    obj.idFuncionario = Convert.ToInt32(Dr["idfuncionario"]);
                    obj.nmFuncionario = Convert.ToString(Dr["nmfuncionario"] != DBNull.Value ? Dr["nmfuncionario"] : null);
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"] != DBNull.Value ? Dr["nmapelido"] : null);
                    obj.flInstrucao = Convert.ToString(Dr["flinstrucao"] != DBNull.Value ? Dr["flinstrucao"] : null);
                    obj.flCivil = Convert.ToString(Dr["flcivil"] != DBNull.Value ? Dr["flcivil"] : null);
                    obj.flSexo = Convert.ToString(Dr["flsexo"] != DBNull.Value ? Dr["flsexo"] : null);
                    obj.dtNascimento = Convert.ToDateTime(Dr["dtnascimento"] != DBNull.Value ? Dr["dtnascimento"] : null);
                    obj.dsImagem = Convert.ToString(Dr["dsimagem"] != null ? Dr["dsimagem"] : DBNull.Value);
                    //Documentos
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"] != DBNull.Value ? Dr["nrdocumento"] : null);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"] != DBNull.Value ? Dr["nrregistro"] : null);
                    obj.nmOrgaoRG = Convert.ToString(Dr["nmorgaorg"] != DBNull.Value ? Dr["nmorgaorg"] : null);
                    obj.nrCTPS = Convert.ToString(Dr["nrctps"] != DBNull.Value ? Dr["nrctps"] : null);
                    obj.nrPIS = Convert.ToString(Dr["nrpis"] != DBNull.Value ? Dr["nrpis"] : null);
                    obj.nmOrgaoCTPS = Convert.ToString(Dr["nmorgaoctps"] != DBNull.Value ? Dr["nmorgaoctps"] : null);
                    obj.nrTitulo = Convert.ToString(Dr["nrtitulo"] != DBNull.Value ? Dr["nrtitulo"] : null);
                    obj.nrZona = Convert.ToString(Dr["nrzona"] != DBNull.Value ? Dr["nrzona"] : null);
                    obj.nrSecao = Convert.ToString(Dr["nrsecao"] != DBNull.Value ? Dr["nrsecao"] : null);
                    //Filiação
                    obj.nmMae = Convert.ToString(Dr["nmmae"] != DBNull.Value ? Dr["nmmae"] : null);
                    obj.nmPai = Convert.ToString(Dr["nmpai"] != DBNull.Value ? Dr["nmpai"] : null);
                    //Endereço
                    obj.nrCEP = Convert.ToString(Dr["nrcep"] != DBNull.Value ? Dr["nrcep"] : null);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"] != DBNull.Value ? Dr["nmlogradouro"] : null);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"] != DBNull.Value ? Dr["nrnumero"] : null);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"] != DBNull.Value ? Dr["nmbairro"] : null);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"] != DBNull.Value ? Dr["dscomplemento"] : null);
                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);
                    //Contato
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"] != DBNull.Value ? Dr["nrtelefone"] : null);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"] != DBNull.Value ? Dr["nrcelular"] : null);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"] != DBNull.Value ? Dr["dsemail"] : null);
                    obj.dsSite = Convert.ToString(Dr["dssite"] != DBNull.Value ? Dr["dssite"] : null);
                    obj.dsLinkedin = Convert.ToString(Dr["dslinkedin"] != DBNull.Value ? Dr["dslinkedin"] : null);
                    obj.dsFacebook = Convert.ToString(Dr["dsfacebook"] != DBNull.Value ? Dr["dsfacebook"] : null);
                    obj.dsInstagram = Convert.ToString(Dr["dsinstagram"] != DBNull.Value ? Dr["dsinstagram"] : null);
                    //Emergência
                    obj.nmContato = Convert.ToString(Dr["nmcontato"] != DBNull.Value ? Dr["nmcontato"] : null);
                    obj.flContato = Convert.ToString(Dr["flcontato"] != DBNull.Value ? Dr["flcontato"] : null);
                    obj.nrFoneEmergecia = Convert.ToString(Dr["nrfoneemergecia"] != DBNull.Value ? Dr["nrfoneemergecia"] : null);
                    obj.nrCelularEmergecia = Convert.ToString(Dr["nrcelularemergecia"] != DBNull.Value ? Dr["nrcelularemergecia"] : null);
                    //Admissão
                    obj.dtAdmissao = Convert.ToDateTime(Dr["dtadmissao"] != DBNull.Value ? Dr["dtadmissao"] : null);
                    obj.dtDemissao = (Dr["dtdemissao"] == DBNull.Value) ? (DateTime?)null : ((DateTime?)Dr["dtadmissao"]);
                    obj.nmFuncao = Convert.ToString(Dr["nmfuncao"] != DBNull.Value ? Dr["nmfuncao"] : null);
                    obj.nmDepartamento = Convert.ToString(Dr["nmdepartamento"] != DBNull.Value ? Dr["nmdepartamento"] : null);
                    obj.flExperiencia = Convert.ToString(Dr["flexperiencia"] != DBNull.Value ? Dr["flexperiencia"] : null);
                    //Bancários
                    obj.nmBanco = Convert.ToString(Dr["nmbanco"] != DBNull.Value ? Dr["nmbanco"] : null);
                    obj.flTipoConta = Convert.ToString(Dr["fltipoconta"] != DBNull.Value ? Dr["fltipoconta"] : null);
                    obj.nrAgencia = Convert.ToString(Dr["nragencia"] != DBNull.Value ? Dr["nragencia"] : null);
                    obj.nrConta = Convert.ToString(Dr["nrconta"] != DBNull.Value ? Dr["nrconta"] : null);
                    obj.nrDigito = Convert.ToString(Dr["nrdigito"] != DBNull.Value ? Dr["nrdigito"] : null);
                    obj.nrPix = Convert.ToString(Dr["nrpix"] != DBNull.Value ? Dr["nrpix"] : null);
                    //Geral
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"] != DBNull.Value ? Dr["dsobservacao"] : null);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"] != DBNull.Value ? Dr["flsituacao"] : null);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"] != DBNull.Value ? Dr["dtcadastro"] : null);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"] != DBNull.Value ? Dr["dtatualizacao"] : null);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Funcionário: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar todos os dados
        public List<Funcionario> FindAll()
        {
            try
            {

               

                OpenConection();
                Cmd = new SqlCommand("select * from funcionario", Con);
                Dr = Cmd.ExecuteReader();

                List<Funcionario> list = new List<Funcionario>();


                while (Dr.Read())
                {
                    Funcionario obj = new Funcionario();

                    obj.idFuncionario = Convert.ToInt32(Dr["idfuncionario"]);
                    obj.nmFuncionario = Convert.ToString(Dr["nmfuncionario"] != DBNull.Value ? Dr["nmfuncionario"] : null);
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"] != DBNull.Value ? Dr["nmapelido"] : null);
                    obj.flInstrucao = Convert.ToString(Dr["flinstrucao"] != DBNull.Value ? Dr["flinstrucao"] : null);
                    obj.flCivil = Convert.ToString(Dr["flcivil"] != DBNull.Value ? Dr["flcivil"] : null);
                    obj.flSexo = Convert.ToString(Dr["flsexo"] != DBNull.Value ? Dr["flsexo"] : null);
                    obj.dtNascimento = Convert.ToDateTime(Dr["dtnascimento"] != DBNull.Value ? Dr["dtnascimento"] : null);
                    obj.dsImagem = Convert.ToString(Dr["dsimagem"] != null ? Dr["dsimagem"] : DBNull.Value);
                    //Documentos
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"] != DBNull.Value ? Dr["nrdocumento"] : null);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"] != DBNull.Value ? Dr["nrregistro"] : null);
                    obj.nmOrgaoRG = Convert.ToString(Dr["nmorgaorg"] != DBNull.Value ? Dr["nmorgaorg"] : null);
                    obj.nrCTPS = Convert.ToString(Dr["nrctps"] != DBNull.Value ? Dr["nrctps"] : null);
                    obj.nrPIS = Convert.ToString(Dr["nrpis"] != DBNull.Value ? Dr["nrpis"] : null);
                    obj.nmOrgaoCTPS = Convert.ToString(Dr["nmorgaoctps"] != DBNull.Value ? Dr["nmorgaoctps"] : null);
                    obj.nrTitulo = Convert.ToString(Dr["nrtitulo"] != DBNull.Value ? Dr["nrtitulo"] : null);
                    obj.nrZona = Convert.ToString(Dr["nrzona"] != DBNull.Value ? Dr["nrzona"] : null);
                    obj.nrSecao = Convert.ToString(Dr["nrsecao"] != DBNull.Value ? Dr["nrsecao"] : null);
                    //Filiação
                    obj.nmMae = Convert.ToString(Dr["nmmae"] != DBNull.Value ? Dr["nmmae"] : null);
                    obj.nmPai = Convert.ToString(Dr["nmpai"] != DBNull.Value ? Dr["nmpai"] : null);
                    //Endereço
                    obj.nrCEP = Convert.ToString(Dr["nrcep"] != DBNull.Value ? Dr["nrcep"] : null);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"] != DBNull.Value ? Dr["nmlogradouro"] : null);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"] != DBNull.Value ? Dr["nrnumero"] : null);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"] != DBNull.Value ? Dr["nmbairro"] : null);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"] != DBNull.Value ? Dr["dscomplemento"] : null);
                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);
                    //Contato
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"] != DBNull.Value ? Dr["nrtelefone"] : null);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"] != DBNull.Value ? Dr["nrcelular"] : null);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"] != DBNull.Value ? Dr["dsemail"] : null);
                    obj.dsSite = Convert.ToString(Dr["dssite"] != DBNull.Value ? Dr["dssite"] : null);
                    obj.dsLinkedin = Convert.ToString(Dr["dslinkedin"] != DBNull.Value ? Dr["dslinkedin"] : null);
                    obj.dsFacebook = Convert.ToString(Dr["dsfacebook"] != DBNull.Value ? Dr["dsfacebook"] : null);
                    obj.dsInstagram = Convert.ToString(Dr["dsinstagram"] != DBNull.Value ? Dr["dsinstagram"] : null);
                    //Emergência
                    obj.nmContato = Convert.ToString(Dr["nmcontato"] != DBNull.Value ? Dr["nmcontato"] : null);
                    obj.flContato = Convert.ToString(Dr["flcontato"] != DBNull.Value ? Dr["flcontato"] : null);
                    obj.nrFoneEmergecia = Convert.ToString(Dr["nrfoneemergecia"] != DBNull.Value ? Dr["nrfoneemergecia"] : null);
                    obj.nrCelularEmergecia = Convert.ToString(Dr["nrcelularemergecia"] != DBNull.Value ? Dr["nrcelularemergecia"] : null);
                    //Admissão
                    obj.dtAdmissao = Convert.ToDateTime(Dr["dtadmissao"] != DBNull.Value ? Dr["dtadmissao"] : null);
                    obj.dtDemissao = (Dr["dtdemissao"] == DBNull.Value) ? (DateTime?)null : ((DateTime?)Dr["dtadmissao"]);
                    obj.nmFuncao = Convert.ToString(Dr["nmfuncao"] != DBNull.Value ? Dr["nmfuncao"] : null);
                    obj.nmDepartamento = Convert.ToString(Dr["nmdepartamento"] != DBNull.Value ? Dr["nmdepartamento"] : null);
                    obj.flExperiencia = Convert.ToString(Dr["flexperiencia"] != DBNull.Value ? Dr["flexperiencia"] : null);
                    //Bancários
                    obj.nmBanco = Convert.ToString(Dr["nmbanco"] != DBNull.Value ? Dr["nmbanco"] : null);
                    obj.flTipoConta = Convert.ToString(Dr["fltipoconta"] != DBNull.Value ? Dr["fltipoconta"] : null);
                    obj.nrAgencia = Convert.ToString(Dr["nragencia"] != DBNull.Value ? Dr["nragencia"] : null);
                    obj.nrConta = Convert.ToString(Dr["nrconta"] != DBNull.Value ? Dr["nrconta"] : null);
                    obj.nrDigito = Convert.ToString(Dr["nrdigito"] != DBNull.Value ? Dr["nrdigito"] : null);
                    obj.nrPix = Convert.ToString(Dr["nrpix"] != DBNull.Value ? Dr["nrpix"] : null);
                    //Geral
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"] != DBNull.Value ? Dr["dsobservacao"] : null);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"] != DBNull.Value ? Dr["flsituacao"] : null);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"] != DBNull.Value ? Dr["dtcadastro"] : null);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"] != DBNull.Value ? Dr["dtatualizacao"] : null);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Funcionário: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }


        public void findInsert(string text, int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from funcionario where nmfuncionario=@v1 and idfuncionario <> @v2", Con);
                Cmd.Parameters.AddWithValue("@v1", text);
                Cmd.Parameters.AddWithValue("@v2", id);
                Dr = Cmd.ExecuteReader();

                Pais obj = null;
                if (Dr.Read())
                {
                    obj = new Pais();


                    obj.nmPais = Convert.ToString(Dr["nmfuncionario"]);
                    throw new Exception("Já existe um funcionário cadastrado com esse nome, verifique!");

                }
            }
            finally
            {
                CloseConection();
            }
        }

    }
}
