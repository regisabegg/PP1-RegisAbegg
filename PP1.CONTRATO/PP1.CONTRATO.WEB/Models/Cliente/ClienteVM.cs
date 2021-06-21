using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Cliente
{
    public class ClienteVM : Pessoa.PessoaVM
    {
        [Display(Name = "Limite crédito")]
        public decimal vlLimite { get; set; }


        public Entity.Cliente VM2E(Entity.Cliente bean)
        {
            bean.nmCliente = this.nmPessoa;
            bean.nmApelido = this.nmApelido;
            bean.nrDocumento = this.nrDocumento;
            bean.nrRegistro = this.nrRegistro;
            bean.nrTelefone = this.nrTelefone;
            bean.nrCelular = this.nrCelular;
            bean.dsEmail = this.dsEmail;
            bean.dsSite = this.dsSite;
            bean.nmContato = this.nmContato;
            bean.flContato = this.flContato;
            bean.dsObservacao = this.dsObservacao;
            bean.flTipo = this.flTipo;
            bean.flSituacao = this.flSituacao;
            bean.nrCEP = this.nrCEP;
            bean.nmLogradouro = this.nmLogradouro;
            bean.nrNumero = this.nrNumero;
            bean.nmBairro = this.nmBairro;
            bean.dsComplemento = this.dsComplemento;
            bean.vlLimite = this.vlLimite;
            bean.dtAtualizacao = this.dtAtualizacao;
            bean.dtCadastro = this.dtCadastro;
            bean.idCidade = this.Cidade.id ?? 0;

            return bean;
        }

    }
}