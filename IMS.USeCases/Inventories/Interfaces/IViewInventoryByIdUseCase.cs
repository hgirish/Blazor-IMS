using IMS.CoreBusiness;

namespace IMS.USeCases.Inventories.Interfaces;
public interface IViewInventoryByIdUseCase
{
    Task<Inventory> ExecuteAsync(int inventoryId);
}