using System.Collections.Generic;
using System.Linq;

class GoodsRepository
{
    public Good[] Goods;

    public bool Contains(Good good)
    {
        return Goods.Contains(good);
    }

    public Good[] GetAvialableGoods()
    {
        List<Good> result = new List<Good>();

        foreach (Good good in Goods)
        {
            if (good != null && good.Count > 0)
            {
                result.Add(good);
            }
        }

        return result.ToArray();
    }

    public Good GetProduct(string name)
    {
        foreach (Good good in Goods)
        {
            if (good.Name == name)
            {
                return good;
            }
        }

        return null;
    }
}
