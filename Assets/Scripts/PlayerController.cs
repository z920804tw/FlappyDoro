using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flyForce;
    [SerializeField] float gravity = -9.8f;

    [SerializeField] Sprite[] sprites;
    int currentIndex;

    SpriteRenderer spriteRenderer;
    Rigidbody rb;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        currentIndex = 0;

        InvokeRepeating("PlayAnimation", 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            this.enabled=false;
        }
    }


}
