﻿using UnityEngine;

public class AssignPlayer : MonoBehaviour
{
    [SerializeField] private Transform _train;

    private void Awake()
    {
        transform.SetParent(_train);
    }
}
