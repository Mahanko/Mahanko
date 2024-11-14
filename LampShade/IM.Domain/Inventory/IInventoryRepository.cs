using _0_Framework.Domain;
using InventoryManagement.Application.Contract.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Domain.Inventory
{
    public interface IInventoryRepository:IRepository<long,InventoryAgg>
    {
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        InventoryAgg GetBy(long productId);
    }
}
