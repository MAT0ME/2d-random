using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    public float jumpForce = 60f;
    bool isJumping;
    public float runSpeed = 1.0f;

   public Animator anime;

    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anime.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void FixedUpdate()
    {
        //  body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        body.AddForce(new Vector2(horizontal * runSpeed, 0f), ForceMode2D.Impulse);

        if (!isJumping)
        {
            body.AddForce(new Vector2(0f, vertical * jumpForce), ForceMode2D.Impulse);
        }
       // if (isJumping){ anime.SetBool("IsJumping", true); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            
            isJumping = false;
        }
    }

    public void onLanding() 
    {
       // anime.SetBool("IsJumping", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
           // anime.SetBool("IsJumping", false);
            isJumping = true;
        }
    }

    #region Commented code
    //private Rigidbody2D Rigidbody;
    //float MoveSpeed, JumpForce, MoveHorizontal, MoveVertical;
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    Rigidbody = gameObject.GetComponent<Rigidbody2D>();
    //    MoveSpeed = 3f;
    //    JumpForce = 60f;
    //    isJumping = false;

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    MoveHorizontal = Input.GetAxisRaw("Horizontal");
    //    MoveVertical = Input.GetAxisRaw("Vertical");
    //}

    //private void FixedUpdate()
    //{
    //    if (MoveHorizontal < 0.1f || MoveHorizontal < -0.1f)
    //    {
    //        Rigidbody.AddForce(new Vector2(MoveHorizontal * MoveSpeed, 0f), ForceMode2D.Impulse);
    //    }   
    //    if (MoveVertical < 0.1f)
    //    {
    //        Rigidbody.AddForce(new Vector2(0f, MoveVertical * JumpForce), ForceMode2D.Impulse);
    //    }

    //}
    #endregion

}
