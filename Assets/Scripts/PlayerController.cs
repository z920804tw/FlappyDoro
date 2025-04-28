using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("玩家設定")]
    public float flyForce;
    public GameObject jumpPrefab;
    public GameObject deadPrefab;
    [SerializeField] Sprite[] sprites;
    int currentIndex;
    [Header("音效設定")]
    public AudioSource audioSource;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip passClip;



    GameManager gameManager;
    SpriteRenderer spriteRenderer;

    Rigidbody rb;
    Vector3 dir;

    void OnEnable()
    {
        InvokeRepeating("PlayAnimation", 0.15f, 0.15f); //開始動畫
    }

    void OnDisable()
    {
        CancelInvoke("PlayAnimation"); //停止動畫
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
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

        audioSource.PlayOneShot(jumpClip);

        GameObject jumpP = Instantiate(jumpPrefab, transform.position + Vector3.down, Quaternion.identity);
        Destroy(jumpP, 0.5f);
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
                audioSource.PlayOneShot(hitClip);
                GameObject dead = Instantiate(deadPrefab, transform.position + Vector3.up, Quaternion.identity);
                Destroy(dead, 0.5f);
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
                audioSource.PlayOneShot(passClip);
                gameManager.IncreaseScore();
            }
        }

    }


}
