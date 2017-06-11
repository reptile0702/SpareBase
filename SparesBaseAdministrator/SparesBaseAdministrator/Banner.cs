﻿using System.Drawing;

namespace SparesBaseAdministrator
{
    public class Banner
    {
        public Banner(string photoName, string link, Image image)
        {
            PhotoName = photoName;
            Link = link;
            Image = image;
        }

        public string PhotoName { get; set; }
        public string Link { get; set; }
        public Image Image { get; set; }
    }
}
