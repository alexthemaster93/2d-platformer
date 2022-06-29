using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator animator;
    public float move;
    private Rigidbody2D player_Rgb;
    public float jumpPower;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        player_Rgb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            player_Rgb.AddForce(new Vector2(0, jumpPower));
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(move, 0.0f, 0.0f);
            this.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            animator.SetBool("IsRunning", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(move, 0.0f, 0.0f);
            this.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }
}
