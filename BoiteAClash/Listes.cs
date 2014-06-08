using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiteAClash
{
    class Listes
    {
        public ObservableCollection<Clash> Clashes { get; set; }

        public Listes()
        {
            Clashes = new ObservableCollection<Clash>
            {
                new Clash {PathImage = "/Resources/img/PoPoPo.png", PathSound = "/Resources/sound/Popopo_guys.wav",Txt = "Popopo"},
                new Clash {PathImage = "/Resources/img/bagare.jpg", PathSound = "/Resources/sound/SachsFight.wav",Txt = "La bagarre"},                
                new Clash {PathImage = "/Resources/img/jeuxdemot.jpg", PathSound = "/Resources/sound/jeuxdemot.mp3",Txt = "Jeu de mot"},                
            };
        }
    }
}
