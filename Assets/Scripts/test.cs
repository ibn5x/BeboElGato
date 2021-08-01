using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour
{
    
    public float speed; //How fast player moves speed
    public float jumpForce; //how much force to jump
    public float jumpsAllowed; //if players in air how many more jumps can they do? (double jump functionality)
    public float timesJumped;
    private Rigidbody2D rb; //apply for to rigid body component
    private float moveInput; //when input -1 go left 1 go right 0 stand still
    private float jumpInput;
    private float previousJumpInput;
   

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //go get the rigidbody conected to sprite
        timesJumped = 0;
        previousJumpInput = 0;
    }

    //unlike update, Fixed update, executes each physics step
    void FixedUpdate() 
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        jumpInput = Input.GetAxis("Vertical");
        if(jumpInput > 0 && timesJumped < jumpsAllowed && previousJumpInput == 0) {
            rb.velocity = new Vector2(rb.velocity.x,  jumpForce);
            timesJumped++;
        }
        previousJumpInput = jumpInput;
        // this will work if you need a down as well as up -> rb.velocity = new Vector2(rb.velocity.x, jumpInput * speed);
    }

    /*
        this special method will be called whenever our player 
        colides with any object but we will set it to the ground 
        using tile map tag 
    */
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag("Ground"))
        {
            timesJumped = 0;
        }
        else if(other.gameObject.CompareTag("Tokens"))
        {
            Destroy(other.gameObject); //this function will remove token.

            textManager.instance.IncreaseScore();
        }
    }

    // Update is called once per frame (60FPS)
    void Update()
    {
        
    }
}
