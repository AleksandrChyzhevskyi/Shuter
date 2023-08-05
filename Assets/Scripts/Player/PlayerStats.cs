using Assets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Scripts.Player
{
    internal class PlayerStats : MonoBehaviour
    {
        private Healths _healths;
        private IWeapon _weapon;
        private Shoot _shoot;
        private PlayerMovement _movement;
        private LookPlayer _lookPlayer;

        public UserInput _userInput { get; private set; }
        public int Heslth => _healths.Points;
        public IWeapon Weapon => _weapon;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                return;

            if (_healths.IsLife == false)
                gameObject.SetActive(false);

            _healths.TakeAwayPoints(damage);
        }

        public void Init(IWeapon weapon, int healths, UserInput userInput)
        {
            _weapon = weapon;
            _healths = new Healths(healths);
            _userInput = userInput;
            ActivElements(true);
        }

        private void ActivElements(bool isActiv)
        {
            GetComponent<Shoot>().enabled = isActiv;
            GetComponent<PlayerMovement>().enabled = isActiv;
            GetComponentInChildren<LookPlayer>().enabled = isActiv;
        }
    }
}
