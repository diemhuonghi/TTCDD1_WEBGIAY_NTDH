using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webgiay_NTDH.Models.modelviews
{


public class CartService
    {
        private const string CartSessionKey = "CartSession";

        // Lấy giỏ hàng từ Session
        public List<CartItem> GetCartItems()
        {
            var cart = HttpContext.Current.Session[CartSessionKey] as List<CartItem>;
            if (cart == null)
            {
                cart = new List<CartItem>();
                HttpContext.Current.Session[CartSessionKey] = cart;
            }
            return cart;
        }

        // Thêm sản phẩm vào giỏ hàng
        public void AddToCart(int productId, string productName, decimal price, int quantity = 1)
        {
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.ProductID == productId);

            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductID = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public void RemoveFromCart(int productId)
        {
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.ProductID == productId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }
        }

        // Cập nhật số lượng sản phẩm
        public void UpdateCartItem(int productId, int quantity)
        {
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.ProductID == productId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
            }
        }

        // Xóa toàn bộ giỏ hàng
        public void ClearCart()
        {
            HttpContext.Current.Session[CartSessionKey] = null;
        }

        // Tính tổng tiền của giỏ hàng
        public decimal GetTotalAmount()
        {
            return GetCartItems().Sum(c => c.Total);
        }
    }

}
