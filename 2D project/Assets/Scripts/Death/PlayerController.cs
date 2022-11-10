using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float move;
    private Rigidbody2D player_Rgb;
    public float jumpPower;
    bool isJumping = false;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int maxHealth = 100;
    public int currentHealth;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player_Rgb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            animator.SetTrigger("Launching");
            player_Rgb.AddForce(new Vector2((float).5, jumpPower), ForceMode2D.Impulse);
            isJumping = true;
        }
        animator.SetBool("IsJumping", false);
        {
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Attack();
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
    private void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D hit in hitEnemies)
        {
            Debug.Log("We hit " + hit.name);
        }
    }

    private void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    private void SetHealth(int health)
    {
        slider.value = health;
    }
}
