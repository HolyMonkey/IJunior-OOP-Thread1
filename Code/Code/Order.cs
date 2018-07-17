class Order
{
    public Good Good;
    public int Count;

    public int GetTotalPrice()
    {
        return Good.Price * Count;
    }

    //TODO: Rename
    public void ApplyOrder()
    {
        Good.Count -= Count;
    }
}
