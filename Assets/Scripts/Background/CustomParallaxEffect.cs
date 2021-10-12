using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomParallaxEffect : MonoBehaviour
{
    private float length, startpos;
    private Camera cam;
    public float parallaxEffect;
    public float speed = 0.001f;
    private float camPos;
    private float parentPos;

    void Start()
    {
        cam = Camera.main;
        camPos = cam.transform.position.x;
        length = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
        parentPos = transform.position.x;

        startpos = camPos - length;
        float var = startpos;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).transform.position = new Vector3(var, transform.position.y, transform.position.z);
            var += length;
        }


    }

    void Update()
    {
        if (transform.position.x >= parentPos + length - speed)
        {
            transform.position = new Vector3(parentPos, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + (speed * parallaxEffect), transform.position.y, transform.position.z);
        }

    }
}
