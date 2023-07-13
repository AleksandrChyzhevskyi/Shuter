using Assets.Scripts.Enemy;
using Assets.Scripts.Factoury;
using Assets.Scripts.Weapon;
using System.Collections.Generic;
using UnityEngine;
using NavMeshSurface = Unity.AI.Navigation.NavMeshSurface;

namespace Assets.Scripts
{
    public class ControllerGame : MonoBehaviour
    {
        [SerializeField] private Transform _wall;
        [SerializeField] private Transform _evacuationPosition;
        [SerializeField] private List<Transform> _positionsSpawn;

        private GroundFactory _groundFactory;
        private PlayerFactory _playerFactoury;
        private EnemyFactory _enemyFactory;
        private List<GameObject> _enemies = new List<GameObject>();
        private UserInput _userInput;

        private int _width = 98;
        private int _height = 400;
        private int _startPoint = 70;
        private int _step = 2;
        private float _wallCreationChance = 0.7f;

        private void Awake()
        {
            _userInput = GetComponentInChildren<UserInput>();
            _playerFactoury = GetComponentInChildren<PlayerFactory>();
            _enemyFactory = GetComponentInChildren<EnemyFactory>();
            _groundFactory = GetComponentInChildren<GroundFactory>();
        }

        private void Start()
        {
            CreateGround();
            CreatePlayer();
            SpawmEnemy();
        }

        private void SpawmEnemy()
        {
            while (_enemies.Count < 30)
            {
                for (int i = 0; i < _positionsSpawn.Count; i++)
                {
                    EnemyStats enemy = _enemyFactory.Create(_positionsSpawn[i].position, 8, 1, _evacuationPosition.position);
                    _enemies.Add(enemy.gameObject);
                }
            }
        }

        private void GeneraateWall()
        {
            int heightCreateWall = (int)_wall.localScale.y / 2;

            for (int x = 0; x <= _width; x += _step)
            {
                for (int y = _startPoint; y < _height; y += _step)
                {
                    if (Random.value > _wallCreationChance)
                    {
                        Vector3 positionWall = new Vector3(x - _width / 2f, heightCreateWall, y - _height / 2f);
                        Instantiate(_wall, positionWall, Quaternion.identity, transform);
                    }
                }
            }
        }

        private void CreatePlayer()
        {
            Gan gan = new Gan("П", 10, 10);
            _playerFactoury.Create(new Vector3(0, 2, -240), gan, 100, _userInput);
        }

        private void CreateGround()
        {
            NavMeshSurface ground = _groundFactory.Create(Vector3.zero);
            GeneraateWall();
            ground.BuildNavMesh();
        }
    }
}
