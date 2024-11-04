namespace WebTruyen.Models
{
    public class TRUYEN_TL
    {
        public int IDTruyen { get; set; }
        public int IDTheLoai { get; set; }
        public Comic Truyen {  get; set; }
        public Category TheLoai { get; set; }

    }
}
