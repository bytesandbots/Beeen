using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgbtrigger : MonoBehaviour
{
    public GameObject buddy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buddy.GetComponent<chasey_1ney>().triggerbgb = true;
        }
    }
}


