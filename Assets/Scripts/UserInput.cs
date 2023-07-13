using Assets.Scripts.Cotalog;
using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public event Action<Vector3> MovePlayer;
    public event Action<Vector2> RotationPlayer;
    public event Action Shooting;
    public event Action JumpPlayer;
    private Vector3 _move;    
    private Vector2 _mouseRotation;
    private float _mouseSensitivity = 100f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
        Move();
        Jump();
        Shoot();
    }

    private void Rotate()
    {
        _mouseRotation.x = Input.GetAxis(ConstCatalog.LeftRightRotation) * _mouseSensitivity * Time.deltaTime;
        _mouseRotation.y = Input.GetAxis(ConstCatalog.UpDownRotation) * _mouseSensitivity * Time.deltaTime;
        RotationPlayer?.Invoke(_mouseRotation);
    }

    private void Move()
    {
        _move.x = Input.GetAxis(ConstCatalog.LeftRightMove);
        _move.z = Input.GetAxis(ConstCatalog.UpDownMove);
        MovePlayer?.Invoke(_move);
    }

    private void Jump()
    {
        if (Input.GetButtonDown(ConstCatalog.JumpPlayer))
            JumpPlayer?.Invoke();
    }   

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
            Shooting?.Invoke();
    }
}
