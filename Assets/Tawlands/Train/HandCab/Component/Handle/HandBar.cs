using UnityEngine;

public class HandBar : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private MeshRenderer _meshRenderer;

    private Rigidbody _accelerationBody;

    [SerializeField] private float _speed;
    [SerializeField] private string _barName;

    private const float GreenHue = 120f / 360;
    private bool _isPlayerTouching;

    private void Awake()
    {
        _accelerationBody = transform.parent.GetComponentInParent<Rigidbody>();
    }

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
            _animator.SetTrigger($"{_barName} Handle Down");
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName($"{_barName} Handle Down"))
        {
            _accelerationBody.AddRelativeForce(_speed * Time.deltaTime * Vector3.left);
        }
    }
}
