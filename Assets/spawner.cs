using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public int wave;
    public GameObject enemy;
    public Transform Spawnp;
    public float nextwave = 30;
    private float ctime;
    public float spawnfrec = 1;
    private float sctime;

    private int enemiestospawn;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int enemycount = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (enemycount <= 0)
        {
            enemiestospawn = wave * 4;
            if (ctime < nextwave)
            {
                ctime += Time.deltaTime;
            }
        }
        if (ctime >= nextwave)
        {
            if (sctime >= spawnfrec && enemiestospawn > 0)
            {
                GameObject clone = Instantiate(enemy, Spawnp);
                enemiestospawn--;
                sctime = 0;
            }
            else if (enemiestospawn == 0) {
                ctime = 0;
                wave++;
            }
            else
            {
                sctime += Time.deltaTime;
            }

        }
    }
}