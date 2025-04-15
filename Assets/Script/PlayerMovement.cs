using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private bool isDestroyer;
    private int desiredLane = 1; //0:left 1:middle 2:right
    Vector3 targetPosition = (Vector3.right);
    private Rigidbody playerRb;
    private Animator animator;
    public float laneDistance;
    private bool grounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //private void FixedUpdate()

    //{
    //    float move = Input.GetAxis("Horizontal");

    //    playerRb.linearVelocity = new Vector3(move * moveSpeed * Time.fixedDeltaTime,0,0);
    //    if (Input.GetKeyDown(KeyCode.Space) && isDestroyer)
    //    {
    //        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //        isDestroyer = false;
    //    }
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
            grounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            grounded = true;
            animator.SetBool("IsJumping", false);
        }

        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
        //    Debug.Log("Choque");
        //    //GameManager.gameOver = true;
        //}
    }
}