using Flunt.Notifications;
using PromoHunter.Domain.Commands;
using PromoHunter.Domain.Commands.Contracts;
using PromoHunter.Domain.Commands.PromotionCommands;
using PromoHunter.Domain.Entities;
using PromoHunter.Domain.Handlers.Contracts;
using PromoHunter.Domain.Repositories;

namespace PromoHunter.Domain.Handlers
{
    public class PromotionHandler :
            Notifiable,
            IHandler<CreatePromotionCommand>
    {

        private readonly IPromotionRepository _repository;

        public PromotionHandler(IPromotionRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePromotionCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Error, there's something wrong in this promotion", command.Notifications);

            var promotion = new Promotion(command.Name, command.StoreName, command.PromotionLink, command.User);
            _repository.SavePromotion(promotion);


            return new GenericCommandResult(true, "Promotion created.", promotion);
        }
    }
}