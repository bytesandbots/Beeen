using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_boi : MonoBehaviour
{
    public Transform destination;
    public GameObject Keyobj;
    bool open;
    public float openspeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open) {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, openspeed * Time.deltaTime);
        }
      

        }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<backpack>().bp.Contains(Keyobj) && Input.GetKey(KeyCode.E) && !open)
            {
                open = true;
            }
        }
    }
}
