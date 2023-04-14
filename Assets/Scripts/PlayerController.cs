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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        spi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Allows player to jump (but not double jump), as well as move left and right & flips the sprite respectively

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

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
            if (!spi.flipX)
            {
                Instantiate(projectilePrefab, (transform.position + new Vector3(1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
            }

            else
            {
                Instantiate(leftProjectilePrefab, (transform.position + new Vector3(-1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
            }

        }

    }

    // Assists in preventing the player from double jumping

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
