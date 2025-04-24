using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("物件參考")]
    public Spawner spawner;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        spawner.enabled = false;
        playerController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //開始遊戲
    public void StartNewGame()
    {
        spawner.enabled = true;
        spawner.ClearAllPipe();

        playerController.enabled = true;
        playerController.GetComponent<Rigidbody>().isKinematic=false;
        playerController.transform.position=new Vector3(0,0,0);


    }

    public void EndGame()
    {
        spawner.StopAllPipe();
        spawner.enabled=false;

        playerController.enabled=false;
    }
}
