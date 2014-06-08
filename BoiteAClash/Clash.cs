using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BoiteAClash
{
    class Clash
    {
        public string PathSound { get; set; }
        public string PathImage { get; set; }

        public string Txt { get; set; }
        public BitmapImage Image
        {
            get
            {
                return new BitmapImage(new Uri(PathImage,UriKind.Relative));
            }
        }

    }
}
