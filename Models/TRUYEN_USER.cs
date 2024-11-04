namespace WebTruyen.Models
{
    public class TRUYEN_USER
    {
        public int IDTruyen {  get; set; }
        public int IDUser { get; set; }
        public Comic Truyen { get; set; }
        public User User { get; set; }
    }
}
