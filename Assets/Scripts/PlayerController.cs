using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float leftRange = -13.00f;
    public float rightRange = 430;
    public GameObject projectilePrefab;
    public GameObject leftProjectilePrefab;
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    SpriteRenderer spi;
    private GameManager gameManager;
    private Animator playerAnim;
    public int pointValue;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        spi = gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Allows player to jump (but not double jump), as well as move left and right & flips the sprite respectively

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spi.flipX = true;
        }
 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spi.flipX = false;
        }

        // Plays walking animation

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (isOnGround)
            {
                playerAnim.SetFloat("speed", 2);
                isMoving = true;
            }
            
        }

        else
        {
            playerAnim.SetFloat("speed", 1);
            isMoving = false;
        }

        // Prevents player from moving out of bounds left or right

        if (transform.position.x < leftRange)
        {
            transform.position = new Vector3(leftRange, transform.position.y, transform.position.z);
            
        }

        if (transform.position.x > rightRange)
        {
            transform.position = new Vector3(rightRange, transform.position.y, transform.position.z);
            
        }


        // Allows player to fire bullets from their parasol in the direction they're facing

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isOnGround)
            {
                if (!spi.flipX)
                {
                    Instantiate(projectilePrefab, (transform.position + new Vector3(1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
                    playerAnim.SetTrigger("isShooting2");
                }

                else
                {
                    Instantiate(leftProjectilePrefab, (transform.position + new Vector3(-1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
                    playerAnim.SetTrigger("isShooting2");
                }
            }

            if (isMoving)
            {
                if (!spi.flipX)
                {
                    Instantiate(projectilePrefab, (transform.position + new Vector3(1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
                    playerAnim.SetTrigger("isShooting3");
                }

                else
                {
                    Instantiate(leftProjectilePrefab, (transform.position + new Vector3(-1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
                    playerAnim.SetTrigger("isShooting3");
                }
            }

            else
            {
                if (!spi.flipX)
                {
                    Instantiate(projectilePrefab, (transform.position + new Vector3(1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
                    playerAnim.SetTrigger("isShooting1");
                }

                else
                {
                    Instantiate(leftProjectilePrefab, (transform.position + new Vector3(-1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
                    playerAnim.SetTrigger("isShooting1");
                }
            }

        }


        if (!isOnGround)
        {
            playerAnim.SetFloat("speed", 0);
        }

    }

    // Assists in preventing the player from double jumping

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Island"))
        {
            isOnGround = true;
        }

        else
        {
            isOnGround = false;
        }
    }

    // Damages the player when colliding with a ghost & tracks gems collected

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            gameManager.DamagePlayer();
        }

        if (other.CompareTag("Ruby"))
        {
            gameManager.RubyTracker(pointValue);
        }

        if (other.CompareTag("Emerald"))
        {
            gameManager.EmeraldTracker(pointValue);
        }

        if (other.CompareTag("Sapphire"))
        {
            gameManager.SapphireTracker(pointValue);
        }

        
    }
}
