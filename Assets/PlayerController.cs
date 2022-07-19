using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    [Header("Get key")]
    [SerializeField] public bool hasKey = false;
    //[SerializeField] private bool doorOpen= false;
   
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Death Event")]
    public UnityEvent deathEvent;

    [Header("Hearts & Keys")]
    [SerializeField] public int playerHealth = 3;


    private bool facingRight = true;
    public int keyCount = 0;
    private int blitzCount = 0;
    private Animator _animator;


    private bool isGrounded => Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    int nextLevel = 0;
    int nextLevel2 = 1;
    int nextLevel3 = 2; 
    int Menu = 3;
    
    


    // Start is called before the first frame update
    void Start()
    {
        //nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveInput = Input.GetAxis("Horizontal");
        //var nextLevel = SceneManager.GetActiveScene().buildIndex + 1;


        //Debug.Log(isGrounded);


        //Debug.Log(moveInput);

        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);



        if (!facingRight && moveInput > 0) // move to right
        {
            Flip();
            _animator.SetFloat("Speed", speed);
        }
        else if (facingRight && moveInput < 0) // move to left
        {
            Flip();
            _animator.SetFloat("Speed", speed);
        }

        var jump = Input.GetButtonDown("Jump");

        if (jump && isGrounded)
        {
            Debug.Log("Jump");
            rb.velocity = Vector2.up * jumpForce;
        }

        if (!isGrounded)
        {
            _animator.SetFloat("Speed", speed);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight; // !true = false; !false = true
        var scale = transform.localScale;
        scale.x *= -1; // scale.x = scale.x * -1;

        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    if(collision.gameObject.tag == "Enemy")
        {
           //Debug.Log("Dead!");
            //Application.LoadLevel(Application.loadedLevel);
            playerHealth--;
            Debug.Log("-1 Life");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("is triggered");
        if (other.tag == "deadly")
        {
            Debug.Log("Dead!");
            Application.LoadLevel(Application.loadedLevel); 
          
        }
        else if(other.tag=="next")
        {
                Debug.Log("Next!");
                SceneManager.LoadScene(++nextLevel);
        }
        else if(other.tag =="next2")
        {
            Debug.Log("Next!");
                SceneManager.LoadScene(++nextLevel2);
        }
        else if(other.tag =="next3")
        {
            Debug.Log("Next!");
                SceneManager.LoadScene(++nextLevel3);
        }
        else if(other.tag =="next4")
        {
            Debug.Log("Done!");
                SceneManager.LoadScene(++Menu);
        }
         else if(other.CompareTag("Key") == true)
         {
           keyCount++; 
           Debug.Log($"Key Count = {keyCount}");
           other.gameObject.SetActive(false);
           hasKey = true;
         }
         else if(other.CompareTag("Blitz") == true)
         {
           blitzCount++; 
           Debug.Log($"Blitz Count = {blitzCount}");
           other.gameObject.SetActive(false);
         }
        else if(other.tag=="door")
        {
            
            if(keyCount >= 1)
            {
                other.gameObject.SetActive(false);
                Debug.Log("open");
            }
        }
         
            deathEvent.Invoke();

    }
}

         
            
        

        

    

        


    

    


    

    
   

    











    
