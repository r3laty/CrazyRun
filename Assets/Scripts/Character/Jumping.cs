using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Jumping : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void OnClick()
    {
        Jump();
    }
    private void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
