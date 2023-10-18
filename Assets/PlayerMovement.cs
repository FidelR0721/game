using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
  
    

    private Rigidbody2D rb; 
    private Animator anim;

    private bool grounded;   
    // Start is called before the first frame update
    void Start()
    {
        //Grabs references for rigidbody and animator from object
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Move = horizontalInput;
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        // Flips character when moving left 
        if (Move > 0.01f)
            transform.localScale = Vector3.one;
        else if (Move < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if(Input.GetKey(KeyCode.Space) && grounded)
           Jump();
            
        // Set animator parameters
            anim.SetBool("Run", Move !=0);
            anim.SetBool("grounded", grounded);


        
         
   
    }
     private void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, speed); 
            anim.SetTrigger("jump");
            grounded = false;
        }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
