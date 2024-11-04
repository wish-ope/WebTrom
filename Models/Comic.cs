using System.ComponentModel.DataAnnotations;

namespace WebTruyen.Models
{
    public class Comic
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Cover { get; set; }
        public string LatestChap { get; set; }
        public List<string> Chapters { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public ICollection<TRUYEN_TG> Truyen_TGs { get; set; }
        public ICollection<TRUYEN_TL> Truyen_Tls { get; set; }
        public ICollection<TRUYEN_USER> Truyen_Users { get; set; }
    }
}
