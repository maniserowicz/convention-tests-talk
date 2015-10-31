using System;
using Procent.dotnetconf2015.MyApp.DataAccess;
using Procent.dotnetconf2015.MyApp._Infrastructure;

namespace Procent.dotnetconf2015.MyApp.UserRegistration
{
    public class RegisterUserCommand : ICommand
    {
        public string Username { get; set; }
    }

    public class UserRegistered : IEvent
    {
        public string Username { get; set; }
        public DateTime RegistrationTime { get; set; }
    }

    public class SaveUserInDatabase : IHandleCommand<RegisterUserCommand>
    {
        private readonly IUsersRepozytory _usersRepo;
        private readonly IEventsBus _events;

        public SaveUserInDatabase(IUsersRepozytory usersRepo, IEventsBus events)
        {
            _usersRepo = usersRepo;
            _events = events;
        }

        public void Handle(RegisterUserCommand command)
        {
            _usersRepo.AddUser(command.Username);

            _events.Publish(new UserRegistered
            {
                Username = command.Username,
                RegistrationTime = DateTime.Now,
            });
        }
    }

    public class SendConfirmationEmail : IHandleEvent<UserRegistered>
    {
        public void Handle(UserRegistered @event)
        {
        }
    }
}