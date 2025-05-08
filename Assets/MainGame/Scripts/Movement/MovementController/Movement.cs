using UnityEngine;
using Zenject;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    private InputPlayer _input;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input.Enable();
    }

    [Inject]
    private void Constructor(InputPlayer input)
    {
        _input = input;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 direction = _input.Player.Move.ReadValue<Vector3>();
        _rb.linearVelocity = new Vector3(direction.x * _speed, _rb.linearVelocity.y, direction.z * _speed);
    }
    private void OnDestroy()
    {
        _input.Disable();
    }

}
