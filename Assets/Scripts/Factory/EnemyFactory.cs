using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyStats _enemy;

        public EnemyStats Create(Vector3 enemyPosition, int speed, int health, Vector3 evacuationPosition)
        {
            EnemyStats enemy = Instantiate(_enemy, enemyPosition, Quaternion.identity);
            enemy.Init(speed, health, evacuationPosition);
            return enemy;
        }
    }
}
