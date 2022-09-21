namespace AutoPartsShopAndForum.Areas.Seller.Models.Input
{
    using System.Collections.Generic;

    public class MailSendInpuModel
    {
        public string SenderId { get; set; }

        public string RecieverId { get; set; }

        public string Body { get; set; }

        public string Header { get; set; }

        ICollection<SellerModel> Sellers { get; set; }
    }
}
