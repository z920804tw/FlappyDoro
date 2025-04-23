using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x <= -30)
        {
            Destroy(this.gameObject);
        }
    }
}
