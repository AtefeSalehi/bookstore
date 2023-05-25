using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IBasketService
    {
        void AddBasket(User user);
    }
}
