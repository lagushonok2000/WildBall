using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Rigidbody _playerRigidBody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeedX;
    [SerializeField] private float _rotationSpeedY;
    [SerializeField] private float _jumpForce;

    private float _horizontal;
    private float _vertical;
    private float _mouseX;
    private float _mouseY;
    private float _jump;
    private float _rotate = 0;
    private float _minAngularY = -70;
    private float _maxAngularY = 80;
    private bool _isGround = true;
    private Vector3 _velocity;

    private void Update()
    {
        CameraRotate();
        PlayerRotate();
    }
    private void FixedUpdate()
    {
        InputMethod();
        PlayerMove();
        CheckGround();
        Jump();
    }

    private void InputMethod()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _mouseX = Input.GetAxisRaw("Mouse X");
        _mouseY = Input.GetAxisRaw("Mouse Y");
        _jump = Input.GetAxisRaw("Jump");
    }

    private void Jump()
    {
        if (_isGround && _jump == 1)
        {
            _isGround = false;
            _playerRigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void CheckGround()
    {
        _isGround = Physics.Raycast(transform.position, Vector3.down, 3f);
    }

    private void PlayerMove()
    {
        _velocity = new Vector3(_horizontal,0,_vertical) * _speed;

        _velocity = Vector3.ClampMagnitude(_velocity, _speed);
        _velocity = transform.TransformDirection(_velocity);
        _velocity.y = _playerRigidBody.velocity.y;
        _playerRigidBody.velocity = _velocity;
    }

    private void PlayerRotate()
    {
        //_playerRigidBody.angularVelocity = new Vector3(0, _mouseX, 0) * _rotationSpeedX;
        transform.localRotation *= Quaternion.Euler(0, _mouseX * _rotationSpeedX, 0);
    }

    private void CameraRotate()
    {
        _rotate += _mouseY * _rotationSpeedY * -1;
        _rotate = Mathf.Clamp(_rotate, _minAngularY, _maxAngularY);
        _camera.localRotation = Quaternion.Euler(_rotate, 0, 0);
    }

}
