using System;
using System.Linq;

public class CartService
{
    public CartModel CartModel { get; set; } = new CartModel();
    public void AddToCart(ProductCartModel newProduct)
    {
        ProductCartModel item = CartModel.ProductCartList.Find(p => p.Id == newProduct.Id);
        if (item != null)
        {
            item.Quantity += 1;
        }
        else
        {
            CartModel.ProductCartList.Add(newProduct);
        }
        NotifyStateChanged();

    }
    public void DeleteProduct(int id)
    {
        ProductCartModel prod = CartModel.ProductCartList.Find(prod => prod.Id == id);
        CartModel.ProductCartList.Remove(prod);
        NotifyStateChanged();

    }
    public void ChangeQuantity(int id, int quantity)
    {
        ProductCartModel prod = CartModel.ProductCartList.Find(p => p.Id == id);
        prod.Quantity += quantity;
        NotifyStateChanged();
    }
    public event Action OnChange;
    // Phương thức NotifyStateChanged sẽ kích hoạt sự kiện OnChange
    // Khi OnChange được kích hoạt, tất cả các component đăng ký với sự kiện này sẽ biết state đã thay đổi
    private void NotifyStateChanged() => OnChange?.Invoke();
}
