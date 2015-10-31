using Procent.dotnetconf2015.MyApp.DataAccess;
using Procent.dotnetconf2015.MyApp._Infrastructure;

namespace Procent.dotnetconf2015.MyApp.UserRegistration
{
    public class RegisterUserCommand : ICommand
    {
        public string Username { get; set; }
    }

    public class SaveUserInDatabase : IHandleCommand<RegisterUserCommand>
    {
        private readonly IUsersRepozytory _usersRepo;

        public SaveUserInDatabase(IUsersRepozytory usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public void Handle(RegisterUserCommand command)
        {
            _usersRepo.AddUser(command.Username);
        }
    }

    public class SendConfirmationEmail : IHandleCommand<RegisterUserCommand>
    {
        public void Handle(RegisterUserCommand command)
        {
        }
    }
}