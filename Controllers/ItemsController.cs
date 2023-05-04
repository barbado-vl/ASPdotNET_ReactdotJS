using Microsoft.AspNetCore.Mvc;

using ASPdotNET_ReactdotJS.Models;

namespace ASPdotNET_ReactdotJS.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemsModelRepository itemsModelRepository;
    public ItemsController(ItemsModelRepository itemsModelRepository)
    {
        this.itemsModelRepository = itemsModelRepository;
    }

    [HttpGet("{itemType:int}")]
    public ItemModel[] Get(int itemType)
    {
        return itemsModelRepository.GetItems().Result.ToArray().Where(i => i.ItemType == itemType).ToArray();
    }

    
}
