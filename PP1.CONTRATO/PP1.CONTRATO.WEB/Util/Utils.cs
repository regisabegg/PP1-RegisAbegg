using System.Text;
using System.Security.Cryptography;
using System;
using System.Linq;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.Web;

namespace PP1.CONTRATO.WEB.Util
{
    public class Utils
    {
        public static string GerarHash(string texto)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();
        }

        public static string GeraSenha(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789/*-+";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }


        public void EnviarEmailComNovaSenha(string email, string senha, string nome, string login, string link)
        {
            //var _paramBLL = db.usuario.FirstOrDefault(u => u.dsEmail);
            //var smtp = new System.Net.Mail.SmtpClient();
            //var cred = smtp.Credentials.GetCredential(smtp.Host, smtp.Port, "Basic");
            //var pwd = _paramBLL.nrSenha("mail_password"); //System.Configuration.ConfigurationManager.AppSettings["mail:pwd"];

            //cred.Password = "M@ster123";
            //smtp.Credentials = cred;

            //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            //message.To.Add(email);
            //message.Subject = "Senha para acesso aos módulos " + ConfigurationManager.AppSettings["Sistema:nome"];
            //message.Body = (string.Format(
            //        @"Sr(a) {0} para acesso ao sistema {1} utilize os dados abaixo: <br/>
            //         <strong>LOGIN: {2}</strong><br/>
            //         <strong>SENHA: {3}</strong><br/><br/>
            //        <strong>ENDEREÇO: </strong><a href='{4}'>{4}</a>.<br/><br/>
            //        Para sua maior segurança, após entrar no sistema altere sua senha.",
            //        nome, ConfigurationManager.AppSettings["Sistema:nome"], login, novaSenha, link));
            //message.IsBodyHtml = true;

            //smtp.Send(message);                    

            //----Envio pelo smarterasp PADRAO para teste----//
            var envia = new MailAddress("no-reply@rpsmart.com.br");
            var receptor = new MailAddress(email);

            SmtpClient smtp = new SmtpClient("mail.rpsmart.com.br");

            NetworkCredential Credentials = new NetworkCredential("no-reply@rpsmart.com.br", "vysu@123");
            smtp.Credentials = Credentials;
            var msg = new MailMessage();
            msg.From = new MailAddress("no-reply@rpsmart.com.br");
            //----Fim envio Padra----//

            //----Envio pelo g-mail para teste----//
            //var envia = new MailAddress("regisabegg@gmail.com");
            //var receptor = new MailAddress(email);

            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.EnableSsl = true;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.UseDefaultCredentials = false;

            //NetworkCredential Credentials = new NetworkCredential("regisabegg@gmail.com", "sat1989/*");
            //smtp.Credentials = Credentials;

            //var msg = new MailMessage();
            //msg.From = new MailAddress("regisabegg@gmail.com");
            //----Fim teste Gmail----//





            msg.ReplyToList.Add(new MailAddress(email));

            //msg.To.Add(new MailAddress("contato@rpsmart.com.br"));
            //msg.To.Add(new MailAddress("regis.aa@rpsmart.com.br"));
            msg.To.Add(new MailAddress("regis.rp4it@gmail.com"));

            msg.Subject = "E-mail de contato via site RPSMART";
            msg.IsBodyHtml = true;

            msg.Body = (string.Format(
                    @"Sr(a) {0} para acesso ao sistema {1} utilize os dados abaixo: <br/>
                     <strong>LOGIN: {2}</strong><br/>
                     <strong>SENHA: {3}</strong><br/><br/>
                    <strong>ENDEREÇO: </strong><a href='{4}'>{4}</a>.<br/><br/>
                    Para sua maior segurança, após entrar no sistema altere sua senha.",
                    nome, ConfigurationManager.AppSettings["Sistema:nome"], login, senha, link));

            //msg.Body = "<html><body>" +
            //           "<p> " +
            //           "<b>Contato: </b>" + nome + "<br />" +
            //           "<b>Fone: </b>" + email + "<br />" +
            //           "<b>Empresa: </b>" + login + "<br />" +
            //           "<b>CNPJ: </b>" + senha +
            //           "</p>" +
            //           "<hr>" +
            //           "<b>Mensagem: </b>" + body +
            //           "<hr>" +
            //           "</body></html>";

            msg.Priority = System.Net.Mail.MailPriority.Normal;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.Send(msg);

            //var result = new
            //{
            //    message = "E-mail enviado com sucesso! Em breve entraremos em contato!",
            //    type = "success"
            //};




        }

        public static string UploadPhoto(HttpPostedFileBase file)
        {
            // Upload image
            string path = string.Empty;
            string pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/UserImage"), pic);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }

            return pic;
        }


        public static bool ValidaCnpj(string cnpj)

        {

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;

            int resto;

            string digito;

            string tempCnpj;

            cnpj = cnpj.Trim();

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)

                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);

        }

    }
}
