using Assets.Scripts.Player;
using Assets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Scripts.Factoury
{
    internal class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private PlayerStats _player;

        public PlayerStats Create(Vector3 playerPosition, IWeapon weapon, int health, UserInput userInput)
        {
            PlayerStats player = Instantiate(_player, playerPosition, Quaternion.identity);
            player.Init(weapon, health, userInput);
            return player;
        }
    }
}
