namespace Assets.Scripts.Weapon
{
    public interface IWeapon
    {
        public string Name { get; }
        public int Damage { get; }
        public int Distance { get;  }
        public int SpeedAttac { get; }

        public int GetDamage();
    }
}
