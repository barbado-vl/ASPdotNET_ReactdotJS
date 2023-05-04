using Microsoft.AspNetCore.Mvc;

using ASPdotNET_ReactdotJS.Models;

namespace ASPdotNET_ReactdotJS.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ItemsModelRepository itemsModelRepository;
    public ItemController(ItemsModelRepository itemsModelRepository)
    {
        this.itemsModelRepository = itemsModelRepository;
    }

    [HttpGet("{itemType:int}")]
    public ItemModel[] Get(int itemType)
    {
        return itemsModelRepository.GetItems().Result.ToArray().Where(i => i.ItemType == itemType).ToArray();
    }

    
}
