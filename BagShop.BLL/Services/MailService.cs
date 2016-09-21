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
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.Credentials = new System.Net.NetworkCredential("hederabrand@gmail.com", "Hedera!1");
                client.EnableSsl = true;
                mail.Subject = "Новый заказ";
                mail.Body = $"Заказ №{order.ID} \n{order.Customer.FirstName} {order.Customer.LastName}, {order.Customer.UserName}, {order.DeliveryAddress}, {string.Join("\n", order.Items.Select(i => string.Join(", ", i.Item.Title, i.SelectedColour.Preview.Name, i.Quantity + "шт")))}";
                client.Send(mail);
            }
        }
    }
}
