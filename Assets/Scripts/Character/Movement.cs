using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    [SerializeField] private Joystick joystick;

    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 moveMobile = new Vector3(joystick.Horizontal * speed, _rb.velocity.y, joystick.Vertical * speed);
        _rb.velocity = moveMobile;

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
    }
}
