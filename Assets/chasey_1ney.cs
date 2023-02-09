using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasey_1ney : MonoBehaviour
{
    public Transform[] points;
    public float speed = 5.9f;
    private int currentindex;
    private Vector3 destination;
    public bool triggerbgb;
    // Start is called before the first frame update
    void Start()
    {
        destination = points[0].position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerbgb)
        {
            if (Vector3.Distance(transform.position, destination)<.1f)
            {
                currentindex++;
                if (currentindex > points.Length)
                {
                    currentindex = 0;
                }
                destination = points[currentindex].position;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed);
            }
            
        }
    }
}
