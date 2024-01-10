using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Jumping : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float groundDistance = 0.1f;

    private Rigidbody _rb;
    private bool _isGrounded;
    public void OnClick()
    {
        Jump();
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}
