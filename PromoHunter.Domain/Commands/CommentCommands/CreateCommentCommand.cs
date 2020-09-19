using System;
using Flunt.Notifications;
using Flunt.Validations;
using PromoHunter.Domain.Commands.Contracts;

namespace PromoHunter.Domain.Commands.CommentCommands
{
    public class CreateCommentCommand : Notifiable, ICommand
    {
        public CreateCommentCommand()
        {

        }

        public CreateCommentCommand(string user, Guid promotion, string text)
        {
            User = user;
            Promotion = promotion;
            Text = text;
        }

        public string User { get; set; }
        public Guid Promotion { get; set; }
        public string Text { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Text, 3, "Text", "A Comment must have at least length 3")
                    .HasMaxLen(Text, 256, "Text", "A Comment must have less than 256 characteres")
                    .IsNotNull(Promotion, "Promotion", "A Comment must have a promotion")
                    .HasMinLen(User, 6, "User", "Invalid User")
            );
        }
    }
}