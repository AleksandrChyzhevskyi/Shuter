using Assets.Scripts.Enemy;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(PlayerStats))]
    internal class Shoot : MonoBehaviour
    {
        private LookPlayer _lookShoot;
        private UserInput _userInput;
        public LayerMask _enemyMask;
        private PlayerStats _playerStats;
        private float _distance = 100f;

        private void Awake()
        {
            _playerStats = GetComponent<PlayerStats>();
            _lookShoot = GetComponentInChildren<LookPlayer>();            
        }

        private void OnEnable()
        {
            _userInput = GetComponentInParent<PlayerStats>()._userInput;
            _userInput.Shooting += Shooting;
        }

        private void OnDisable()
        {
            _userInput.Shooting -= Shooting;
        }

        private void Shooting()
        {
            Ray ray = new Ray(_lookShoot.gameObject.transform.position, transform.forward * _distance);
            Debug.DrawRay(_lookShoot.gameObject.transform.position, transform.forward * _distance, Color.white);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, _distance, _enemyMask))
            {
                hit.collider.gameObject.GetComponent<EnemyStats>().TakeDamage(_playerStats.Weapon.GetDamage());
                Debug.Log(hit.collider.gameObject.GetComponent<EnemyStats>().HealthsPoint);
            }
        }

        internal object Activate()
        {
            throw new NotImplementedException();
        }
    }
}
