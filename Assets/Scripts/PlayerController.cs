using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 35.0f;
    public float jumpSpeed = 150.0f;
    public float leftRange = -13.00f;
    private float lowRange = -0.1f;
    public GameObject projectilePrefab;
    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * jumpSpeed);

        if (transform.position.x < leftRange)
        {
            transform.position = new Vector3(leftRange, transform.position.y, transform.position.z);
        }

        if (transform.position.y < lowRange)
        {
            transform.position = new Vector3(transform.position.x, lowRange, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Instantiate(projectilePrefab, (transform.position + new Vector3 (1.62f, -0.2848748f, 0)), projectilePrefab.transform.rotation);
        }
    }
}
