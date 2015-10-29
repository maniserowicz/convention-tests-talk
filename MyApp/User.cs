namespace Procent.dotnetconf2015.MyApp
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual bool IsActive { get; set; }
    }
}