using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webgiay_NTDH.Models.modelviews;

namespace webgiay_NTDH.Controllers
{
    public class CartController : Controller
    {
        // GET: CartController
       private readonly CartService _cartService = new CartService();

    // Trang hiển thị giỏ hàng
    public ActionResult Index()
    {
        var cartItems = _cartService.GetCartItems();
        return View(cartItems);
    }

    // Thêm sản phẩm vào giỏ hàng
    public ActionResult AddToCart(int productId, string productName, decimal price, int quantity = 1)
    {
        _cartService.AddToCart(productId, productName, price, quantity);
        return RedirectToAction("Index");
    }

    // Xóa sản phẩm khỏi giỏ hàng
    public ActionResult RemoveFromCart(int productId)
    {
        _cartService.RemoveFromCart(productId);
        return RedirectToAction("Index");
    }

    // Cập nhật số lượng sản phẩm trong giỏ hàng
    [HttpPost]
    public ActionResult UpdateCart(int productId, int quantity)
    {
        _cartService.UpdateCartItem(productId, quantity);
        return RedirectToAction("Index");
    }

    // Xóa toàn bộ giỏ hàng
    public ActionResult ClearCart()
    {
        _cartService.ClearCart();
        return RedirectToAction("Index");

        }
    }
}