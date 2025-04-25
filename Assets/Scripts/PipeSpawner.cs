using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    [SerializeField] float spawnTime;
    [SerializeField] float pipeSpeed;

    [SerializeField] float minY;
    [SerializeField] float maxY;
    float timer;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            GameObject pipe = Instantiate(pipePrefab, startPos, Quaternion.identity);
            pipe.transform.position = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
            pipe.GetComponent<Pipe>().moveSpeed = pipeSpeed;


            timer = 0;
        }
    }


    public void StopAllPipe()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject i in pipes)
        {
            i.GetComponent<Pipe>().enabled=false;
        }

        this.enabled=false;
    }
}
