using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootPlayerRacket : Engine
    {
        public ShootPlayerRacket(IRenderer renderer, IUserInterface userInterface, int speed)
            : base(renderer, userInterface, speed)
        { }
    }
}
