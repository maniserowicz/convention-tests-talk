namespace Procent.dotnetconf2015.MyApp.DataAccess
{
    public interface UsersRepozytoryInterface
    {
        User GetById(int id);
    }

    public class UsersRepozytory : UsersRepozytoryInterface
    {
        public User GetById(int id)
        {
            return new User();
        }
    }
}