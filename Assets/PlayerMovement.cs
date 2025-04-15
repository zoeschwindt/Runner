using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rd;
    private bool isDestroyer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    
    {
        float move = Input.GetAxis("Horizontal");

        rd.linearVelocity = new Vector3(move * moveSpeed * Time.fixedDeltaTime,0,0);
        if (Input.GetKeyDown(KeyCode.Space) && isDestroyer)
        {
            rd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isDestroyer = false;
        }
    }
    
}
