using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Uteis
{
    public class Email
    {
        public string Assunto { get; set; }
        public string Texto { get; set; }
        public SmtpClient SmtpServer { get; set; }

        public Email()
        {
            SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("vitaclub.producao", "vitaclub123");
            SmtpServer.EnableSsl = true;
        }

        public bool EnviarEmail(string destinatario, AnexoEmail anexo = null)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("vitaclub.producao@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = Assunto;
                mail.Body = Texto;
                mail.IsBodyHtml = true;

                if (anexo.Arquivo != null)
                    mail.Attachments.Add(new Attachment(anexo.Arquivo, anexo.Nome));

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }


        }

    }

    public class AnexoEmail
    {
        public string Nome { get; set; }
        public Stream Arquivo { get; set; }

    }

}
