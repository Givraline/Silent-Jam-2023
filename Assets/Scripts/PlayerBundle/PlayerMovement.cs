using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;

    public void Move(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        _rb.velocity = new Vector2(value * _speed, _rb.velocity.y);
    }
}
