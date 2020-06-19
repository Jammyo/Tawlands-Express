using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
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
        [CanBeNull] private Rigidbody _groundRigidBody;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _groundRigidBody = other.rigidbody;
            }
        }

        private void Update()
        {
            _isGrounded = Physics.CheckSphere(_groundPosition.position, _groundDistance, _ground, QueryTriggerInteraction.Ignore);
            
            
            var nameToLayer = ~LayerMask.NameToLayer("Ground");
            if (Physics.Raycast(transform.position, Vector3.down, out var hitInfo, 20, nameToLayer))
            {
                if (!hitInfo.collider.CompareTag("Train"))
                {
                    _groundRigidBody = null;
                }
            }

            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            var jump = Input.GetButtonDown("Jump");

            var direction = _maxSpeed * new Vector3(horizontal, 0, vertical).normalized;
            
            if (_isGrounded && jump)
            {
                _characterController.AddForce(_jumpSpeed * Vector3.up, ForceMode.VelocityChange);
            }
            
            if (_groundRigidBody != null)
            {
                direction += _groundRigidBody.velocity;
            }
            
            _characterController.velocity = new Vector3(direction.x, _characterController.velocity.y, direction.z);
        }
    }
}
