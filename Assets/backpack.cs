using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backpack : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> bp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("picky up") && Input.GetKey(KeyCode.E))
        {
            bp.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
