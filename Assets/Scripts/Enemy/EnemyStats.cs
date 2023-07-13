using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]

    public class EnemyStats : MonoBehaviour
    {
        private Healths _healths;
        private NavMeshAgent _agent;

        public int HealthsPoint => _healths.Points;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }       

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                return;

            if (_healths.IsLife == false)
                gameObject.SetActive(false);

            _healths.TakeAwayPoints(damage);

            if (_healths.Points <= 0)
                gameObject.SetActive(false);
        }

        private void Move(Vector3 positionEvacuation)
        {
            _agent.SetDestination(positionEvacuation);
        }

        public void Init(int speed, int healths, Vector3 evacuationPosition)
        {
            _agent.speed = speed;
            _healths = new Healths(healths);             
            Move(evacuationPosition);
        }
    }
}
