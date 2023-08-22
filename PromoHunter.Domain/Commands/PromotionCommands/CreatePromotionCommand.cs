using System;
using Flunt.Notifications;
using Flunt.Validations;
using PromoHunter.Domain.Commands.Contracts;

namespace PromoHunter.Domain.Commands.PromotionCommands
{
    public class CreatePromotionCommand : Notifiable, ICommand
    {
        public CreatePromotionCommand()
        {

        }

        public CreatePromotionCommand(string name, string storeName, string url, string imageUrl, string user)
        {
            Name = name;
            StoreName = storeName;
            Url = url;
            ImageUrl = imageUrl;
            User = user;
        }

        public string Name { get; set; }
        public string StoreName { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Title", "Please, describe the product better")
                    .IsNotNullOrWhiteSpace(StoreName, "StoreName", "Please provide a store name")
                    .IsUrl(Url, "PromotionLink", "A Promotion must have a link")
                    .HasMinLen(User, 6, "User", "Invalid User")
            );
        }
    }
}