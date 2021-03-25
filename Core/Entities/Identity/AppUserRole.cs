namespace Core.Entities.Identity
{
    public class AppUserRole
    {
        public User User { get; set; }
        public AppRole Role { get; set; }
    }
}