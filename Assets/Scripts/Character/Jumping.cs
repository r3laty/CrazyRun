using UnityEngine;
using UnityEngine.TerrainUtils;

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
    private void Update()
    {
        isGroundCheck();
    }
    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        _isGrounded = true;
    //    }
    //}
    private void isGroundCheck()
    {
        Ray isGround = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(isGround, out var hitInfo, groundDistance * 10f))
        {
            _isGrounded = true;
            Debug.Log("is ground");
        }
        else
        {
            _isGrounded = false;
        }
    }
}
