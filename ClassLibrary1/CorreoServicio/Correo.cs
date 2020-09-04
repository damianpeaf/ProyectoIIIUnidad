using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.CorreoServicio
{
    public abstract class Correo
    {

        private SmtpClient clienteSmtp;
        protected String correo { get; set; }
        protected String pass { get; set; }
        protected String host { get; set; }
        protected int puerto { get; set; }
        protected bool ssl { get; set; }

        protected void InicioCliente()
        {
           
            try
            {
                clienteSmtp = new SmtpClient();
                clienteSmtp.Credentials = new NetworkCredential(correo, pass);
                clienteSmtp.Host = host;
                clienteSmtp.Port = puerto;
                clienteSmtp.EnableSsl = ssl;
            }
            catch (Exception ex)
            {
                Console.WriteLine("HOLAAAAAAAAAAAAAAAAAAAA 333 " + ex);
            }

        }

        public void EnviarMensaje(string asunto, string cuerpo, string correoR)
        {
            var mensaje = new MailMessage();

            try
            {
                mensaje.From = new MailAddress(correo);
                mensaje.To.Add(new MailAddress(correoR));

                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;
                mensaje.Priority = MailPriority.Normal;

                clienteSmtp.Send(mensaje);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                mensaje.Dispose();
                clienteSmtp.Dispose();
            }
        }

    }
}
