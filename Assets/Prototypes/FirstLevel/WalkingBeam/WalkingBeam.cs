using UnityEngine;

namespace Prototypes.FirstLevel.WalkingBeam
{
    public class WalkingBeam : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private HingeJoint _hingeJoint;
    
        private bool _leaningRight;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _hingeJoint.motor = new JointMotor
                {
                    force = _hingeJoint.motor.force,
                    targetVelocity = 300 * (_leaningRight ? 1 : -1)
                };
                _leaningRight = !_leaningRight;
                _rigidbody.velocity = Vector3.left * 30;
            }
        }
    }
}