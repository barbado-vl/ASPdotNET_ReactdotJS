using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_ReactdotJS.Models
{
    public class ItemsModelRepository
    {
        private readonly WebSiteContext webSiteContext;
        public ItemsModelRepository(WebSiteContext webSiteContext)
        {
            this.webSiteContext = webSiteContext;
        }

        
        public async Task<ItemModel> GetItem(int id)
        {
            var item = await webSiteContext.ItemsModel.SingleOrDefaultAsync(c => c.Id == id);
            return item;
        }
        public async Task<IEnumerable<ItemModel>> GetItems()
        {
            var items = await webSiteContext.ItemsModel.ToListAsync();
            return items;
        }
    }
}