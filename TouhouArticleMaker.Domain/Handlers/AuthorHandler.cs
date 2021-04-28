using TouhouArticleMaker.Shared;

namespace  TouhouArticleMaker.Domain
{
    public class AuthorHandler : IHandler<CreateAuthorCommand>
    {
        private readonly IAuthorRepository _repository;

        public AuthorHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateAuthorCommand command)
        { 
            //Fail Fast Validations}

            //Create VOs

            //Create Entities

            //Relations            

            //Return command 
            return new CommandResult(true, "Author created successfuly.");
        }
    }
}