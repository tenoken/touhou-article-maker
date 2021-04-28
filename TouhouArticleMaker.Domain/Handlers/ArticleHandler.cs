using System.Collections.Generic;
using Flunt.Notifications;
using TouhouArticleMaker.Shared;

namespace  TouhouArticleMaker.Domain
{
    public class ArticleHandler : IHandler<CreateArticleCommand>
    {
        private readonly IArticleRepository _repository;
        //TODO: Create a Handler abstract class which has own validation
        private EntityValidation _validation;

        public ArticleHandler(IArticleRepository repository)
        {
            _repository = repository;
            _validation = new EntityValidation();
        }
        public ICommandResult Handle(CreateArticleCommand command)
        { 
            //Fail Fast Validations
            command.Validate();
            if (command.IsValid)
            {
                _validation.AddNotifications(command.Notifications);
                return new CommandResult(false, "It was not possible to create the article.");
            }

            //Create VOs
            var name = new Name(command.FirstName, command.LastName);
            var username = new Title(command.UserName);
            var password = command.Password;
            var email = new Email(command.Email);
            var validation =  new EntityValidation();

            var title = new Title(command.Title);
            var intro = new Intro(command.Intro);

            //Create Entities
            var author = new Author(name, username, password, email, validation);
            var aritcle = new Article(title, intro, ECategory.Games, validation);

            //Entities Validation
            if(!author.IsValid){
                 _validation.AddNotifications(author.Notifications);
                 return new CommandResult(true, "Author is not valid.");
            }

            if(!aritcle.IsValid){
                _validation.AddNotifications(aritcle.Notifications);
                return new CommandResult(true, "Article is not valid.");
            }

            author.AddArticle(aritcle);

            _repository.CreateArticle(author);

            //Return command 
            return new CommandResult(true, "Article created successfuly.");
        }

        public IReadOnlyCollection<Notification> Notifications { get{ return _validation.Notifications;} }
    }
}