using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tawlands.Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Rigidbody _characterController;
        [SerializeField] private Transform _groundPosition;
        [SerializeField] private LayerMask _ground;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _groundDistance;

        private bool _isGrounded = true;

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
            _isGrounded = Physics.CheckSphere(_groundPosition.position, _groundDistance, _ground, QueryTriggerInteraction.Ignore);
            
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            var jump = Input.GetButtonDown("Jump");

            var direction = _maxSpeed * new Vector3(horizontal, 0, vertical).normalized;
            
            if (_isGrounded && jump)
            {
                _characterController.AddForce(_jumpSpeed * Vector3.up, ForceMode.VelocityChange);
            }
            
            if (_isGrounded && !jump)
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
            
            _characterController.velocity = new Vector3(direction.x, _characterController.velocity.y, direction.z);
        }
    }
}
