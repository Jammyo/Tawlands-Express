using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tawlands.Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpSpeed;

        private float _verticalSpeed;

        private List<GameObject> _activeCollisions = new List<GameObject>();

        private void OnCollisionEnter(Collision other)
        {
            _activeCollisions.Add(other.gameObject);
        }

        private void OnCollisionExit(Collision other)
        {
            _activeCollisions.Remove(other.gameObject);
        }

        void Update()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            var jump = Input.GetButton("Jump");

            var direction = _maxSpeed * new Vector3(horizontal, 0, vertical).normalized;
            if (_characterController.isGrounded)
            {
                _verticalSpeed = jump && _characterController.isGrounded ? _jumpSpeed : 0;
            }
            _verticalSpeed -= 20 * Time.deltaTime;

            if (_characterController.isGrounded && !jump)
            {
                var train = _activeCollisions.FirstOrDefault(o => o.CompareTag("Train"));
                if(train != null)
                {
                    var rigidbody = train.GetComponent<Rigidbody>();
                    if (rigidbody != null)
                    {
                        direction += rigidbody.velocity;
                    }
                }
            }
            
            var collisionFlags = _characterController.Move(Time.deltaTime * new Vector3(direction.x, _verticalSpeed, direction.z));
        }
    }
}
