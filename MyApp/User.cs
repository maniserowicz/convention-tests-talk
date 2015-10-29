namespace Procent.dotnetconf2015.MyApp
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }
}