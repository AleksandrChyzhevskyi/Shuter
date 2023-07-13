namespace Assets.Scripts.Weapon
{
    public abstract class Weapon : IWeapon
    {
        private string _name;
        private int _damage;
        private int _distance;
        private int _speedAttac;

        protected Weapon(string name, int damage, int distance)
        {
            _name = name;
            _damage = damage;
            _distance = distance;
        }

        public string Name => _name;

        public int Damage => _damage;

        public int Distance => _distance;

        public int SpeedAttac => _speedAttac;

        public virtual int GetDamage()
        {
            return _damage;
        }
    }
}
