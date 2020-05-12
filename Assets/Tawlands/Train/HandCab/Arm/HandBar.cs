using UnityEngine;

public class HandBar : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private Transform _armAngle;
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private Rigidbody _accelerationBody;

    [SerializeField] private float _speed;
    [SerializeField] private float _targetVelocity;
    [SerializeField] private float _maxArmAngle;

    private const float GreenHue = 120f / 360;
    private bool _isPlayerTouching = false;
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _meshRenderer.material.color = Color.HSVToRGB(GreenHue, 1, 1);
            _isPlayerTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _meshRenderer.material.color = Color.HSVToRGB(GreenHue, 0, 1);
            _isPlayerTouching = false;
        }
    }

    private float _previousArmAngle;
    
    private void Update()
    {
        if (_isPlayerTouching && Input.GetKeyDown(KeyCode.E))
        {
            if (Mathf.Abs(_armAngle.localRotation.eulerAngles.z - _maxArmAngle) < 1)
            {
                var motor = _hingeJoint.motor;
                motor = new JointMotor{force = motor.force, freeSpin = motor.freeSpin, targetVelocity = _targetVelocity};
                _hingeJoint.motor = motor;
            }
        }

        if (Mathf.Abs(_armAngle.localRotation.eulerAngles.z - _maxArmAngle) > 1 && Mathf.Abs(_hingeJoint.velocity) > Mathf.Abs(_targetVelocity / 3))
        {
            _accelerationBody.velocity = _speed * Time.deltaTime * Vector3.left;
        }
    }
}
