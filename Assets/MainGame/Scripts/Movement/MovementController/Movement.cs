using UnityEngine;
using Zenject;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [Inject] private InputPlayer _input;
    private Vector3 direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input.Player.Move.performed += i => direction = i.ReadValue<Vector3>();
        _input.Player.Move.canceled += i => direction = Vector3.zero;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _rb.linearVelocity = new Vector3(direction.x * _speed, _rb.linearVelocity.y, direction.z * _speed);
    }
}
