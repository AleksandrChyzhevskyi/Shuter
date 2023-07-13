using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon
{
    internal class Gan : Weapon
    {
        private readonly string _name;
        private readonly int _damage;
        private readonly int _distance;

        public Gan(string name, int damage, int distance) : base(name, damage, distance)
        {
            _name = name;
            _damage = damage;
            _distance = distance;
        }
    }
}
