using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private float _dirX, _dirZ;

    [SerializeField] private Joystick joystick;

    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _dirX = joystick.Horizontal * speed;
        _dirZ = joystick.Vertical * speed;
    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(_dirX, _rb.velocity.y, _dirZ);
        _rb.velocity = move * speed * Time.fixedDeltaTime;
    }
}
