using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ScaleableFunction : MonoBehaviour {

    public float speed;
    public Vector3 startSize;
    public Vector3 endSize;
    private float time;
    private bool isGoing;
    private Vector3 centerPoint;
    // Use this for initialization
    void Start()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        scaling();
    }

    public void initialize()
    {
        
        //attribute seting 
        time = 0;
        isGoing = true;
        speed = 1;
        startSize = Vector3.one;
        endSize = GetComponent<BoxCollider>().bounds.size;
        GetComponent<BoxCollider>().size = startSize;
        //centerPoint = (startPoint.position + endPoint.position) / 2 + this.transform.parent.position;


    }

    public void scaling()
    {
        Vector3 _scale =Vector3.zero;
        if (isGoing)
        {
            _scale = Vector3.Lerp(startSize, endSize, time);
            time += Time.deltaTime * speed;
            if (time >= 1)
            {
                time = 0;
                isGoing = false;
            }
        }
        else
        {
            _scale = Vector3.Lerp(endSize, startSize, time);
            time += Time.deltaTime * speed;
            if (time >= 1)
            {
                time = 0;
                isGoing = true;
            }
        }

        this.transform.localScale = _scale;
    }

}
