namespace WebTruyen.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TRUYEN_TG> tRUYEN_TGs { get; set; }
    }
}
