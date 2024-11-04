namespace WebTruyen.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TRUYEN_TL> Truyen_Tls { get; set; }
    }
}
