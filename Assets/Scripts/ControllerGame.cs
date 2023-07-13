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

        private int _width = 98;//Взяти понель и определить ее размеры
        private int _height = 400;

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

        private void GeneraateWall(int width, int height, int startPoint = 70, int step = 2, float wallCreationChance = 0.7f)
        {
            int heightCreateWall = (int)_wall.localScale.y / 2;

            for (int x = 0; x <= width; x += step)
            {
                for (int y = startPoint; y < height; y += step)
                {
                    if (Random.value > wallCreationChance)
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
            GraundSize(ground, out int width, out int height);
            GeneraateWall(width, height);
            ground.BuildNavMesh();
        }

        private void GraundSize(NavMeshSurface ground, out int width, out int height)// Разобратся и дописать !!!
        {
            int unitPointGround = 10;

            width = (int)ground.gameObject.transform.localScale.x * unitPointGround;
            height = (int)ground.gameObject.transform.localScale.z * unitPointGround;


        }
    }
}
