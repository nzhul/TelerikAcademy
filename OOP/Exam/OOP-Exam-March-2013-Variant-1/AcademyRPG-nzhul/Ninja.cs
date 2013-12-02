using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter
    {
        private int _realAttackPoints;
        public int AttackPoints
        {
            get { return _realAttackPoints; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            throw new NotImplementedException();
        }
    }
}
