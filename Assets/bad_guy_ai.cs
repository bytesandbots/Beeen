using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bad_guy_ai : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject head;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            head.GetComponent<death>().scareboi();
            StartCoroutine(waitkill());
            
            //anamate deathboi

        }
    }
    IEnumerator waitkill()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }
}
