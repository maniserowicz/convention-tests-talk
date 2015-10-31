namespace Procent.dotnetconf2015.MyApp.DataAccess
{
    public interface IUsersRepozytory
    {
        User GetById(int id);
        void AddUser(string username);
    }

    public class UsersRepozytory : IUsersRepozytory
    {
        public User GetById(int id)
        {
            return new User();
        }

        public void AddUser(string username)
        {

        }
    }
}