using ProjectPrn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPrn.DAL
{
    internal class OrderDAO : ProjectPrn212Context
    {
        private ProjectPrn212Context context;

        public OrderDAO()
        {
            context = new ProjectPrn212Context();
        }

        public void AddOrder(Order order, Dictionary<Product, (int Quantity, decimal TotalPrice)> productSelection)
        {

            // Add Order Details
            foreach (var item in productSelection)
            {
                var product = item.Key;
                var quantity = item.Value.Quantity;
                var totalPrice = item.Value.TotalPrice;

                OrderDetail orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = product.ProductId,
                    SoLuong = quantity,
                    DonGia = product.Gia
                };
                context.OrderDetails.Add(orderDetail);
            }

            // Save Order Details
            context.SaveChanges();
        }

    }

}

