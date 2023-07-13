using Assets.Scripts.Player;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    private PlayerStats _bodyPlayer;
    private UserInput _userInput;
    private float _lookUpDown = 0f;
    private float _minAngelLook = -90f;
    private float _maxAngelLook = 90f;

    private void Awake()
    {
        _bodyPlayer = GetComponentInParent<PlayerStats>();        
    }

    private void OnEnable()
    {
        _userInput = GetComponentInParent<PlayerStats>()._userInput;
        _userInput.RotationPlayer += Roteitions;
    }

    private void OnDisable()
    {
        _userInput.RotationPlayer -= Roteitions;
    }

    private void Roteitions(Vector2 look)
    {
        _lookUpDown -= look.y;
        _lookUpDown = Mathf.Clamp(_lookUpDown, _minAngelLook, _maxAngelLook);

        transform.localRotation = Quaternion.Euler(_lookUpDown, 0f, 0f);
        _bodyPlayer.gameObject.transform.Rotate(Vector3.up * look.x);
    }
}
