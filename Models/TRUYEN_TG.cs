namespace WebTruyen.Models
{
    public class TRUYEN_TG
    {
        public int IDTruyen {  get; set; }
        public int IDTacGia { get; set; }
        public Comic Truyen { get; set; }
        public Author Author { get; set; }
    }
}
