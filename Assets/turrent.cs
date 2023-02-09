using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrent : MonoBehaviour
{
    public Transform targett;
    public float ratspeed = 5;

    public GameObject projectilee;
    public Transform barrele;
    public float frequencye;
    private float ctime;
    public float bulletspeede = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ctime >= frequencye)
        {
            GameObject clone = Instantiate(projectilee, barrele.position, barrele.rotation);
            clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * bulletspeede, ForceMode.Impulse);
            Destroy(clone, 3);
            ctime = 0;
        }
        else
        {
            ctime += Time.deltaTime;
        }
        if (targett != null)
        {
            Vector3 targetDirection = targett.position - transform.position;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection,ratspeed * Time.deltaTime,.5f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
