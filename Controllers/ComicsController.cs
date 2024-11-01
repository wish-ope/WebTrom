using Microsoft.AspNetCore.Mvc;
using WebTruyen.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebTruyen.Controllers
{
    public class ComicsController : Controller
    {
        private readonly string _comicsDirectory;

        public ComicsController(IWebHostEnvironment env)
        {
            _comicsDirectory = Path.Combine(env.WebRootPath, "comic");
        }

        public IActionResult Index()
        {
            var comics = new List<Comic>();

            if (Directory.Exists(_comicsDirectory))
            {
                var comicFolders = Directory.GetDirectories(_comicsDirectory);

                foreach (var folder in comicFolders)
                {
                    var title = Path.GetFileName(folder);
                    var chapterFolders = Directory.GetDirectories(folder);

                    if (chapterFolders.Length > 0)
                    {
                        var latestChapter = Path.GetFileName(chapterFolders.Last());
                        var coverPath = $"/comic/{title}/0.jpg";

                        comics.Add(new Comic
                        {
                            Title = title,
                            Cover = coverPath,
                            LatestChap = latestChapter
                        });
                    }
                }
            }

            return View(comics);
        }
    }
}
