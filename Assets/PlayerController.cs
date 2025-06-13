using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public float _speed = 5f;
    public Animator animator;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float spaceInput = Input.GetAxis("Jump");

        Vector3 move = new Vector3(horizontalInput, spaceInput, verticalInput);
        Vector3 newPosition = _rb.position + move * _speed * Time.deltaTime;
        _rb.MovePosition(newPosition);

        if (animator != null)
        {
            animator.SetFloat("Test", horizontalInput);
        }
    }
}
