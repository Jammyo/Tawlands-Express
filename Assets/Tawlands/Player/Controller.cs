using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpSpeed;

    private float _verticalSpeed;
    
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
        var collisionFlags = _characterController.Move(Time.deltaTime * new Vector3(direction.x, _verticalSpeed, direction.z));
    }
}
