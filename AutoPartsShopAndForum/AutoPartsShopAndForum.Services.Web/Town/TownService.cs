using AutoPartsShopAndForum.Data;
using AutoPartsShopAndForum.Services.Data.Town;
using System.Collections.Generic;
using System.Linq;

namespace AutoPartsShopAndForum.Services.Web.Town
{
    public class TownService : ITownService
    {
        private readonly ApplicationDbContext context;

        public TownService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<TownModel> GetAllTowns()
        {
            return this.context.Towns
                .Select(t => new TownModel() { Id = t.Id, Name = t.Name })
                .ToArray();
        }
    }
}
