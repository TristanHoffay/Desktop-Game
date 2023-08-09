using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    [SerializeField]
    private float movementForce = 5000f;

    private Rigidbody2D rb;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * Time.deltaTime * movementForce);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * Time.deltaTime * movementForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * Time.deltaTime * movementForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * Time.deltaTime * movementForce);
        }


    }
    public void Death()
    {
        GameManager.Instance.Loss();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You win!");
            GameManager.Instance.Win();
        }
        else if (collision.gameObject.CompareTag("Pickup"))
        {
            if (collision.gameObject.GetComponent<Pickup>().PickUp())
            {
                Debug.Log("Picked up tool");
                MetaControls.Instance.AddTool(collision.gameObject.GetComponent<Pickup>().pickupTool);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Death();
        }
    }
}
