using BagShop.Common.Entities;

namespace BagShop.Common.Interfaces.Services
{
    public interface IMailService
    {
        void SendOrderInformation(Order order);
    }
}
