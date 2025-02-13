using DemoShop.Domain.Core.Common.Interfaces;
using O = DemoShop.Domain.Core.Order.Order;

namespace DemoShop.Domain.Core.Common.DataAccess;

public class DataAccess : IDataAccess
{
    private readonly O _order;

    public DataAccess()
    {
        _order = O.Create();
        _order.AddItem("Computer", 123.45m, 2);
        _order.AddItem("Car", 513.33m, 10);
        _order.AddItem("Bread", 3.11m, 1);
    }

    public O GetOrder()
    {
        return _order;
    }
}