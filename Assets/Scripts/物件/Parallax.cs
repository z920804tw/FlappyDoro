using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    MeshRenderer meshRenderer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.materials[0].mainTextureOffset+=new Vector2(speed*Time.deltaTime,0);
    }
}
