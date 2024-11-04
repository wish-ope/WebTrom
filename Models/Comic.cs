using System.ComponentModel.DataAnnotations.Schema;

namespace WebTruyen.Models
{
    public class Comic
    {
        
      
        
        public string Title { get; set; }
        [NotMapped] // Thêm dòng này để không lưu vào database
        public string Cover { get; set; }
        [NotMapped] // Thêm dòng này để không lưu vào database
        public string LatestChap { get; set; }
        [NotMapped] // Thêm dòng này để không lưu vào database
        public List<string> Chapters { get; set; }
       
    }
}
