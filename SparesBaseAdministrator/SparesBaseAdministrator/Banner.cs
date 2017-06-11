using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparesBaseAdministrator
{
    public class Banner
    {
        public Banner(string photoName, string link, Image Image)
        {
            this.PhotoName = photoName;
            this.Link = link;
            this.Image = Image;
        }


        public string PhotoName { get; set; }
        public string Link { get; set; }


        public Image Image { get; set; }

    }
}
