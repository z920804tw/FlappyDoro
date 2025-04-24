using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed;

    bool canMove;
    public bool CanMove{get{return canMove;}set{canMove=value;}}
    // Start is called before the first frame update
    void Start()
    {   
        canMove=true;
    }

    // Update is called once per frame
    void Update()
    {

        if(!canMove) return;

        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -30)
        {
            Destroy(this.gameObject);
        }
    }
}
