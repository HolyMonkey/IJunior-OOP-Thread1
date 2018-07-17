using System;

class WendingMachine
{
    public int Balance;
    public GoodsRepository Goods;

    public int ClearBalance()
    {
        int oldBalance = Balance;
        Balance = 0;
        return oldBalance;
    }

    public void ApplyOrder(Order order)
    {
        if (order == null) throw new ArgumentNullException("order", "");
        if (Balance < order.GetTotalPrice()) throw new InvalidOperationException("");

        Balance -= order.GetTotalPrice();
        order.ApplyOrder();
    }

    public Good[] GetProductList()
    {
        return Goods.GetAvialableGoods();
    }

    public Good GetProduct(string name)
    {
        return Goods.GetProduct(name);
    }
}
