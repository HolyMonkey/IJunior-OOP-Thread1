class Good
{
    public int Price;
    public string Name;
    public int Count;

    public bool IsAvialable()
    {
        return Count > 0;
    }
}
