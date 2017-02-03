using BagShop.Common.Entities;
using BagShop.Common.Interfaces.Services;
using System.Linq;
using System.Net.Mail;

namespace BagShop.BLL.Services
{
    public class MailService : IMailService
    {
        private string _host;
        private int _port;
        private string _senderEmail;
        private string _senderPwd;

        public MailService(string host, int port, string senderEmail, string senderPwd)
        {
            _host = host;
            _port = port;
            _senderEmail = senderEmail;
            _senderPwd = senderPwd;
        }

        public void SendOrderInformation(Order order)
        {
            using (var client = new SmtpClient())
            {
                MailMessage mail = new MailMessage(_senderEmail, _senderEmail);
                client.Port = _port;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = _host;
                client.Credentials = new System.Net.NetworkCredential(_senderEmail, _senderPwd);
                client.EnableSsl = true;
                mail.Subject = "Новый заказ";
                mail.Body = $"Заказ №{order.ID} \n{order.Customer.FirstName} {order.Customer.LastName}, {order.Customer.UserName}, {order.DeliveryAddress}, {string.Join("\n", order.Items.Select(i => string.Join(", ", i.Item.Title, i.SelectedColour.Preview.Name, i.Quantity + "шт")))}";
                client.Send(mail);
            }
        }
    }
}
