using System.Drawing;

namespace SparesBaseAdministrator
{
    public class Banner
    {
        public Banner(string photoName, string link, Image image, string checkSum)
        {
            PhotoName = photoName;
            Link = link;
            Image = image;
            Checksum = checkSum;
        }

        public string PhotoName { get; set; }
        public string Link { get; set; }
        public Image Image { get; set; }
        public string Checksum { get; set; }
    }
}
