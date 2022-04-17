using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _horizontalMovement = 0f;
    private float _verticalMovement = 0f;
    [SerializeField]
    private Rigidbody _movableBody;
    [SerializeField]
    private float _speed;

    void FixedUpdate()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _movableBody.MovePosition(transform.position + new Vector3(-_verticalMovement * _speed*Time.deltaTime, 0f, _horizontalMovement * _speed*Time.deltaTime));
    }
}
