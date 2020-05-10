using UnityEngine;

namespace Tawlands.Train
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _train;
    
        void Update()
        {
            transform.position = new Vector3(_train.position.x, _train.position.y, transform.position.z);
        }
    }
}
