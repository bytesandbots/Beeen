using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet_ai : MonoBehaviour
{
    // Start is called before the first frame update
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
            StartCoroutine(deathanimationWait());
            //anamate deathboi

        }
        Destroy(gameObject);

        

    }

    IEnumerator deathanimationWait()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(2);
    }
}
