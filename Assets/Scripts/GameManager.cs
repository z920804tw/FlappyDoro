using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("遊戲參數")]
    [SerializeField] int score;
    public int Score { get { return score; } }
    [Header("物件參考")]
    public PipeSpawner pipeSpawner;
    public PlayerController playerController;
    public Parallax background;
    AudioSource audioSource;

    [Header("UI物件")]
    public GameObject gameOverUI;

    public GameObject hintText;
    public TMP_Text socreText;

    public TMP_Text gameOverScoreText;
    public TMP_Text heighestText;

    bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isStart = true;
                StartNewGame();
            }
        }
    }

    //開始遊戲
    public void StartNewGame()
    {
        //玩家控制打開
        playerController.enabled = true;
        playerController.GetComponent<Rigidbody>().isKinematic = false;

        //地板生成開啟
        pipeSpawner.enabled = true;

        //關閉開始提示
        hintText.SetActive(false);

        //分數重製
        score = 0;
        socreText.text = $"{score}";
    }

    public void EndGame()
    {
        //玩家控制停止
        playerController.enabled = false;
        playerController.GetComponent<Rigidbody>().isKinematic = true;
        //水管移動停止
        pipeSpawner.StopAllPipe();

        //地板移動停止
        StopAllGround();

        //背景移動停止
        background.enabled = false;

        //GameOverUI顯示
        StartCoroutine(AnimUI(1.5f, gameOverUI));


        //設定結算分數
        gameOverScoreText.text = $"本局分數:{score}";
        heighestText.text = $"歷史最高分數:{PlayerPrefs.GetInt("HeighestScore", 0)}";

    }

    public void IncreaseScore()
    {
        score++;
        socreText.text = $"{score}";

        if (score % 10 == 0)
        {
            StartCoroutine(AnimScore(6, socreText));
        }

        int heighestScore = PlayerPrefs.GetInt("HeighestScore", 0);
        if (score > heighestScore)
        {
            PlayerPrefs.SetInt("HeighestScore", score);
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void StopAllGround() //讀取場上所有tag=Ground的物件，然後關閉移動
    {
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject i in grounds)
        {
            i.GetComponent<Ground>().enabled = false;
        }
    }

    IEnumerator AnimUI(float delayTime, GameObject gameObject)
    {
        gameObject.SetActive(true);
        float timer = 0;
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        while (timer <= delayTime)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, timer / delayTime);

            yield return null;
        }

        canvasGroup.alpha = 1;
    }

    IEnumerator AnimScore(int switchCount, TMP_Text text)
    {
        int count = 0;
        int index = 0;  //0=白 1==紅
        while (count < switchCount)
        {
            count++;
            if (index == 0)
            {
                index = 1;
                text.color = Color.red;
            }
            else if (index == 1)
            {
                index = 0;
                text.color = Color.white;
            }
            yield return new WaitForSeconds(0.2f);
        }

        text.color = Color.white;
    }
}
