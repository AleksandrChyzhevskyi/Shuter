using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class LookEnemy : MonoBehaviour
    {
        public LayerMask LayerMaskPlayer;
        private float _radiusSphere = 25f;
        private float _distanceSphere = 0.1f;
        private PlayerStats _playerStats;
               
        private void Update()
        {
            LookPlayer();
        }
                
        private void LookPlayer()
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, _radiusSphere, Vector3.forward, _distanceSphere, LayerMaskPlayer);
            foreach (RaycastHit hit in hits)
            {
                _playerStats = hit.collider.GetComponent<PlayerStats>();

                if (_playerStats)
                {
                    _playerStats.TakeDamage(5);
                    Debug.Log($"{hit.collider.name}  {_playerStats.Heslth}");
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radiusSphere);
        }
    }
}
