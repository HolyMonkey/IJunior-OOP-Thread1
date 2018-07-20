using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    public static void Main()
    {
        WendingMachine machine = new WendingMachine();
        machine.Balance = 1000;
        machine.Goods = new GoodsRepository();
        machine.Goods.Goods = new Good[]
        {
            new Good()
            {
                Name = "Test1",
                Count = 2,
                Price = 10
            },
            new Good()
            {
                Name = "Test2",
                Count = 3,
                Price = 15
            },
            new Good()
            {
                Name = "Test3",
                Count = 2,
                Price = 2
            }
        };

        WendingMachineGUI gui = new WendingMachineGUI();
        gui.Machine = machine;
        while (true)
        {
            gui.Update();
        }
    }

    public static Good MakeGood(int price, string name, int count)
    {
        Good good = new Good();
        good.Count = count;
        good.Name = name;
        good.Price = price;

        return good;
    }
}
