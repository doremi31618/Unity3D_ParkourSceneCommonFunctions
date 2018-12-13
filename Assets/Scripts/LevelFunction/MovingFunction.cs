using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boo.Lang;
using UnityEditor;

public class MovingFunction : MonoBehaviour {
    
    public float speed;
    public Transform startPoint;
    public Transform endPoint;
    private float time;
    private bool isGoing;
    private Vector3 centerPoint;
	// Use this for initialization
	void Start () {
        initialize();
	}
	
	// Update is called once per frame
	void Update () {
        moving();
	}

    public void initialize()
    {
        if (startPoint == null || endPoint == null)
        {
            Debug.LogWarning("沒有設定開始點跟結束點");
            return;
        }
        //attribute seting 
        time = 0;
        isGoing = true;
        speed = 1;

        //centerPoint = (startPoint.position + endPoint.position) / 2 + this.transform.parent.position;

        GameObject fatherObject = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
        fatherObject.transform.parent = this.transform.parent;
        transform.parent = fatherObject.transform;

    }

    public void moving()
    {
        Vector3 movingDir;
        if (isGoing)
        {
            movingDir = Vector3.Lerp(startPoint.position, endPoint.position, time) + this.transform.parent.position;
            time += Time.deltaTime * speed;
            if (time >= 1)
            {
                time = 0;
                isGoing = false;
            }
        }
        else
        {
            movingDir = Vector3.Lerp(endPoint.position, startPoint.position, time) + this.transform.parent.position;
            time += Time.deltaTime * speed;
            if (time >= 1)
            {
                time = 0;
                isGoing = true;
            }
        }

        this.transform.position = movingDir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = this.gameObject.transform;
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }

}




