using System.Drawing;

namespace SparesBase
{
    public class Banner
    {
        public Banner(string link, Image image)
        {
            
            Link = link;
            Image = image;
        }

       
        public string Link { get; set; }
        public Image Image { get; set; }
    }
}
