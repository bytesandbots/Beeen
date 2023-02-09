using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class lava : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            //anamate deathboi
            StartCoroutine(deathanimationWait());
        }
    }

    IEnumerator deathanimationWait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
