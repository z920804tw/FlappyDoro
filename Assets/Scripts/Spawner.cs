using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    [SerializeField] float spawnTime;
    [SerializeField] float pipeSpeed;
    float timer;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        timer=2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            GameObject pipe =Instantiate(pipePrefab,startPos,Quaternion.identity);
            pipe.GetComponent<Pipe>().moveSpeed=pipeSpeed;
            timer=0;
        }
    }
}
