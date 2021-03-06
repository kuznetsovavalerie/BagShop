﻿using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using System.Collections.Generic;

namespace BagShop.BLL.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return unitOfWork.ProductRepository.GetAll();
        }

        public ShoppingItem GetItem(int id)
        {
            return unitOfWork.ProductRepository.FindById(id);
        }

        public Colour GetColour(int id)
        {
            return unitOfWork.ColourRepository.FindById(id);
        }

        public void AddItem(ShoppingItem item)
        {
            unitOfWork.ProductRepository.Add(item);
            unitOfWork.SaveChanges();
        }
    }
}
