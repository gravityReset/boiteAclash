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
                new Clash {PathImage = "/Resources/img/Mother.jpg", PathSound = "/Resources/sound/EtTaMere.mp3",Txt = "Ta mère!"},                
                new Clash {PathImage = "/Resources/img/horse.png", PathSound = "/Resources/sound/HorseRun.mp3",Txt = "horse run"},                
                new Clash {PathImage = "/Resources/img/badjoke.png", PathSound = "/Resources/sound/badjoke.mp3",Txt = ""}    
            };
        }
    }
}
