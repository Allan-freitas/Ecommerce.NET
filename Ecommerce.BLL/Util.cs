using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Web.UI;

namespace Ecommerce.BLL
{
    public static class Util
    {

        public static bool EnviarEmailCadastroAlterado(string nome, string email, string telefone, string mensagem)
        {
            try
            {
                string servidor = ConfigurationManager.AppSettings["servidor"].ToString();
                string emailContato = ConfigurationManager.AppSettings["emailContato"].ToString();
                string senha = ConfigurationManager.AppSettings["senha"].ToString();

                StringBuilder corpo = new StringBuilder();

                corpo.Append("Este E-mail foi enviado pela Loja Virtual.");
                corpo.Append("<br/><br/>Os dados alterados são: ");
                corpo.Append("<br/>Nome: ");
                corpo.AppendLine(nome);
                corpo.Append("<br/>E-mail: ");
                corpo.AppendLine(email);
                corpo.Append("<br/>Telefone: ");
                corpo.AppendLine(telefone);

                MailMessage mailMensagem = new MailMessage();
                NetworkCredential credenciais = new NetworkCredential(emailContato, senha);

                mailMensagem.From = new MailAddress(email);
                mailMensagem.To.Add(email);
                mailMensagem.Subject = "INFORMAÇÕES ALTERADAS COM SUCESSO!";

                mailMensagem.IsBodyHtml = true;
                mailMensagem.Body = corpo.ToString();

                SmtpClient smtp = new SmtpClient(servidor);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciais;
                smtp.EnableSsl = true;
                //smtp.Host = servidor;
                smtp.Port = 587;

                smtp.Send(mailMensagem);

                return true;

            }
            catch
            {
                return false;
            }
        }

        public static bool EnviarEmailContato(string nome, string email, string telefone, string mensagem) 
        {
            try
            {
                string servidor = ConfigurationManager.AppSettings["servidor"].ToString();
                string emailContato = ConfigurationManager.AppSettings["emailContato"].ToString();
                string senha = ConfigurationManager.AppSettings["senha"].ToString();

                StringBuilder corpo = new StringBuilder();

                corpo.Append("Este E-mail foi enviado pela Loja Virtual.");
                corpo.Append("<br/><br/>Os dados enviado pelo contato são: ");
                corpo.Append("<br/>Nome: ");
                corpo.AppendLine(nome);
                corpo.Append("<br/>E-mail: ");
                corpo.AppendLine(email);
                corpo.Append("<br/>Telefone: ");
                corpo.AppendLine(telefone);
                corpo.Append("<br/>Mensagem Enviada: ");
                corpo.AppendLine(mensagem);

                MailMessage mailMensagem = new MailMessage();
                NetworkCredential credenciais = new NetworkCredential(emailContato, senha);

                mailMensagem.From = new MailAddress(email);
                mailMensagem.To.Add(email);
                mailMensagem.Bcc.Add(emailContato);
                mailMensagem.Subject = "Email Enviado pelo Cliente.";

                mailMensagem.IsBodyHtml = true;
                mailMensagem.Body = corpo.ToString();

                SmtpClient smtp = new SmtpClient(servidor);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciais;
                smtp.EnableSsl = true;
                //smtp.Host = servidor;
                smtp.Port = 587;

                smtp.Send(mailMensagem);

                return true;

            }
            catch 
            {
                return false;
            }
        }

        public static bool EnviarEmailCadastro(string nome, string email, string senhaUsuario)
        {
            try
            {
                string servidor = ConfigurationManager.AppSettings["servidor"].ToString();
                string emailContato = ConfigurationManager.AppSettings["emailContato"].ToString();
                string senha = ConfigurationManager.AppSettings["senha"].ToString();

                StringBuilder corpo = new StringBuilder();

                corpo.Append("Este E-mail foi enviado pela Loja Virtual.");
                corpo.Append("<br/><br/>Cadastro realizado com sucesso, segue os dados: ");
                corpo.Append("<br/>Nome: ");
                corpo.AppendLine(nome);
                corpo.Append("<br/>E-mail: ");
                corpo.AppendLine(email);
                corpo.Append("<br/>Senha cadastrada é: ");
                corpo.AppendLine(senhaUsuario);

                MailMessage mailMensagem = new MailMessage();
                NetworkCredential credenciais = new NetworkCredential(emailContato, senha);

                mailMensagem.From = new MailAddress(email);
                mailMensagem.To.Add(email);
                mailMensagem.Subject = "Obrigado por cadastrar-se em nossa Loja Virtual.";

                mailMensagem.IsBodyHtml = true;
                mailMensagem.Body = corpo.ToString();

                SmtpClient smtp = new SmtpClient(servidor);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciais;
                smtp.EnableSsl = true;
                //smtp.Host = servidor;
                smtp.Port = 587;

                smtp.Send(mailMensagem);

                return true;

            }
            catch
            {
                return false;
            }
        }

        public static bool EnviarEmailCadastroAdmin(string nome, string email)
        {
            try
            {
                string servidor = ConfigurationManager.AppSettings["servidor"].ToString();
                string emailContato = ConfigurationManager.AppSettings["emailContato"].ToString();
                string senha = ConfigurationManager.AppSettings["senha"].ToString();

                StringBuilder corpo = new StringBuilder();

                corpo.Append("Este E-mail foi enviado pela Loja Virtual.");
                corpo.Append("<br/><br/>Cadastro de novo Cliente realizado com sucesso, segue os dados: ");
                corpo.Append("<br/>Nome: ");
                corpo.AppendLine(nome);
                corpo.Append("<br/>E-mail: ");
                corpo.AppendLine(email);

                MailMessage mailMensagem = new MailMessage();
                NetworkCredential credenciais = new NetworkCredential(emailContato, senha);

                mailMensagem.From = new MailAddress(email);
                mailMensagem.To.Add(emailContato);
                mailMensagem.Subject = "AVISO DE NOVO CLIENTE CADASTRADO.";

                mailMensagem.IsBodyHtml = true;
                mailMensagem.Body = corpo.ToString();

                SmtpClient smtp = new SmtpClient(servidor);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciais;
                smtp.EnableSsl = true;
                //smtp.Host = servidor;
                smtp.Port = 587;

                smtp.Send(mailMensagem);

                return true;

            }
            catch
            {
                return false;
            }
        }

        public static bool EnviarEmailSenha(string nome, string email, string mensagem)
        {
            try
            {
                string servidor = ConfigurationManager.AppSettings["servidor"].ToString();
                string emailContato = ConfigurationManager.AppSettings["emailContato"].ToString();
                string senha = ConfigurationManager.AppSettings["senha"].ToString();

                StringBuilder corpo = new StringBuilder();

                corpo.Append("Este E-mail foi enviado pela Loja Virtual.");
                corpo.Append("<br/><br/>Os dados sobre a recuperação de senha: ");
                corpo.Append("<br/>Nome: ");
                corpo.AppendLine(nome);
                corpo.Append("<br/>E-mail: ");
                corpo.AppendLine(email);
                corpo.Append("<br/><strong>Senha é: </strong>");
                corpo.AppendLine(mensagem);

                MailMessage mailMensagem = new MailMessage();
                NetworkCredential credenciais = new NetworkCredential(emailContato, senha);

                mailMensagem.From = new MailAddress(email);
                mailMensagem.To.Add(email);
                mailMensagem.Subject = "RECUPERAÇÃO DE SENHA DA LOJA VIRTUAL";

                mailMensagem.IsBodyHtml = true;
                mailMensagem.Body = corpo.ToString();

                SmtpClient smtp = new SmtpClient(servidor);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciais;
                smtp.EnableSsl = true;
                //smtp.Host = servidor;
                smtp.Port = 587;

                smtp.Send(mailMensagem);

                return true;

            }
            catch
            {
                return false;
            }
        }

        public static void showMessage(Page page, string message, string pageToRedirect = "", string key = "myKey")
        {
            if (String.IsNullOrEmpty(pageToRedirect))
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, "alert('" + message + ".');", true);
            else
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, "alert('" + message + ".');window.location='" + pageToRedirect + "'", true);
        }
    }
}
