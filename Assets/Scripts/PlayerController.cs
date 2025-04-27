using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flyForce;
    [SerializeField] Sprite[] sprites;
    int currentIndex;


    GameManager gameManager;
    SpriteRenderer spriteRenderer;

    Rigidbody rb;
    Vector3 dir;

    void OnEnable()
    {
        InvokeRepeating("PlayAnimation", 0.15f, 0.15f);
    }

    void OnDisable()
    {
        CancelInvoke("PlayAnimation");
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        currentIndex = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
    }
    void PlayAnimation()
    {
        spriteRenderer.sprite = sprites[currentIndex];
        currentIndex++;

        if (currentIndex >= sprites.Length)
        {
            currentIndex = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.enabled)
        {
            if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground")) //碰到障礙物或是地板
            {
                gameManager.EndGame();
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (this.enabled)
        {
            if (other.gameObject.CompareTag("Score"))
            {
                gameManager.IncreaseScore();
            }
        }

    }


}
