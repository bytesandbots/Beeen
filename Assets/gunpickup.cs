using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunpickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E)) 
        {
            other.GetComponent<shooooooooooooooooooooooooooting>().EnablePistol();
            Destroy(gameObject);
        }
    }
}
