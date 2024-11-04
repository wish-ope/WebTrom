namespace WebTruyen.Models
{
    public class User
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<TRUYEN_USER> Truyen_Users { get; set; }
    }
}
