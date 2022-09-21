namespace AutoPartsShopAndForum.Services.Data.Mail
{
    using System.Collections.Generic;

    public class MailSendInpuModel
    {
        public string SenderId { get; set; }

        public string RecieverId { get; set; }

        public string Body { get; set; }

        public string Header { get; set; }

        public ICollection<SellerModel> Sellers { get; set; }
    }
}
