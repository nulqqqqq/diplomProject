using Microsoft.AspNetCore.Mvc;
using Diplom.Domain.Core;

namespace DiplomServer.Interfaces
{
    public interface IOrderFood
    {
        public void OrderFood([FromBody] OrdersModel orders);
    }
}
