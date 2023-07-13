using Unity.AI.Navigation;
using UnityEngine;

namespace Assets.Scripts.Factoury
{
    internal class GroundFactory : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface _meshSurface;

        public NavMeshSurface Create(Vector3 createPosition)
        {             
            return Instantiate(_meshSurface, createPosition, Quaternion.identity);
        }
    }
}
