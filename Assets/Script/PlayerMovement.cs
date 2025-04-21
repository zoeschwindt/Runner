using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float jumpForce = 7f;
    private bool isDestroyer;
    private int desiredLane = 1; 
    Vector3 targetPosition = (Vector3.right);
    private Rigidbody playerRb;
    private Animator animator;
    public float laneDistance;
    private bool grounded;
    private float position_z;


    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        position_z = transform.position.z;
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane > 2)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane < 0)
            {
                desiredLane = 0;
            }
        }

        
        float targetX = 0f;

        if (desiredLane == 0)
        {
            targetX = -laneDistance;
        }
        else if (desiredLane == 1)
        {
            targetX = 0;
        }
        else if (desiredLane == 2)
        {
            targetX = laneDistance;
        }

   
        targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

       
        transform.position = Vector3.Lerp(transform.position, targetPosition, 10f * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, transform.position.y, position_z);
       
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
            Debug.Log("Estoy en el suelo.");
        }
    }
}