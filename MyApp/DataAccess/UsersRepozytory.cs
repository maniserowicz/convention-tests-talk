namespace Procent.dotnetconf2015.MyApp.DataAccess
{
    public interface IUsersRepozytory
    {
        User GetById(int id);
    }

    public class UsersRepozytory : IUsersRepozytory
    {
        public User GetById(int id)
        {
            return new User();
        }
    }
}