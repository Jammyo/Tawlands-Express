using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _characterSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private CharacterController _characterController;

    private void FixedUpdate()
    {
        _characterController.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * Math.Min(Time.fixedDeltaTime * _characterSpeed, _maxSpeed));
    }
}
