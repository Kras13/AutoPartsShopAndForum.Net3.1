namespace AutoPartsShopAndForum.Services.Web.Town
{
    using AutoPartsShopAndForum.Services.Data.Town;
    using System.Collections.Generic;

    public interface ITownService
    {
        public ICollection<TownModel> GetAllTowns();
    }
}