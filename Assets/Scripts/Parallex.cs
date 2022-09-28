using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{

    private float lenght, startPos;
    [SerializeField]
    private GameObject Cam;
    [SerializeField]
    private float parallexEffect;

    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update()
    {
        float temp = (Cam.transform.position.x * 1 - parallexEffect);
        float dist = (Cam.transform.position.x * parallexEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + lenght) startPos += lenght;
        else if (temp < startPos - lenght) startPos -= lenght;

    }
}
