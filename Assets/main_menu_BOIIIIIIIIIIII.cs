using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class main_menu_BOIIIIIIIIIIII : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Changescene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
