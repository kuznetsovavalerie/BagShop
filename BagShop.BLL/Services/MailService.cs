using BagShop.Common.Entities;
using System.Linq;
using System.Net.Mail;

namespace BagShop.BLL.Services
{
    public static class MailService
    {
        public static void SendOrderInformation(Order order)
        {
            using (var client = new SmtpClient())
            {
                MailMessage mail = new MailMessage("hederabrand@gmail.com", "hederabrand@gmail.com");
                client.Port = 465;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.Credentials = new System.Net.NetworkCredential("hederabrand@gmail.com", "Hedera!1");
                mail.Subject = "Новый заказ";
                mail.Body = $"<html><body><h2>Заказ №{order.ID}</h2><p>{order.Customer.FirstName} {order.Customer.LastName}</p><p>{order.Customer.UserName}</p><p>{order.DeliveryAddress}</p><p>{string.Join("\n", order.Items.Select(i => string.Join(", ", i.Item.Title, i.SelectedColour.Preview.Name, i.Quantity + "шт")))}</p></body></html>";
                client.Send(mail);
            }
        }
    }
}
