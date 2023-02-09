using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public enum mode
{
    patrol, chase, idle
}
public class enemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 target;
    public Transform[] waypoints;
    int currentlocation;
    Transform destination;
    public mode currentstatus = mode.patrol;
    public Transform Player;
    private float ctime;
    private float ridle;

    public Animator anim;

    Transform respawn_for_enemy;
    bool dead;
    public AudioSource pupet;


    // Start is called before the first frame update

    public void ragdollOn()
    {
        dead = true;
        
        Rigidbody[] ragdoll = GetComponentsInChildren<Rigidbody>();
        BoxCollider[] Ragdoll = GetComponentsInChildren<BoxCollider>();
        SphereCollider[] ragdol = GetComponentsInChildren<SphereCollider>();
        CapsuleCollider[] Ragdol = GetComponentsInChildren<CapsuleCollider>();
        GetComponentInChildren<Animator>().StopPlayback();
        GetComponentInChildren<Animator>().enabled=false;

        foreach (Rigidbody rb in ragdoll)
        {
            if (rb.gameObject.tag != "enemy")
            {
                rb.useGravity = true;
            }

        }

        foreach (BoxCollider rb in Ragdoll)
        {
            if (rb.gameObject.tag != "enemy")
            {
                rb.isTrigger = false;
            }
        }

        foreach (SphereCollider rb in ragdol)
        {
            if (rb.gameObject.tag != "enemy")
            {
                rb.isTrigger = false;
            }


        }

        foreach (CapsuleCollider rb in Ragdol)
        {
            if (rb.gameObject.tag != "enemy")
            {
                rb.isTrigger = false;
            }
        }
        Player = null;
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
    }
    void Start()
    {
        pupet = Player.gameObject.GetComponents<AudioSource>()[3];
        Rigidbody[] ragdoll = GetComponentsInChildren<Rigidbody>();
        BoxCollider[] Ragdoll = GetComponentsInChildren<BoxCollider>();
        SphereCollider[] ragdol = GetComponentsInChildren<SphereCollider>();
        CapsuleCollider[] Ragdol = GetComponentsInChildren<CapsuleCollider>();

        foreach (Rigidbody rb in ragdoll)
        {
            if (rb.gameObject.tag != "enemy")
            {
                rb.useGravity = false;
            }
        }

        foreach (BoxCollider rb in Ragdoll)
        {
            if (rb.gameObject.tag != "enemy")
            {
                rb.isTrigger = true;
            }
        }

        foreach (SphereCollider rb in ragdol)
        {
            if (rb.gameObject.tag != "enemy")
            {
                rb.isTrigger = true;
            }


        }

        foreach (CapsuleCollider rb in Ragdol)
        {
            if (rb.gameObject.tag != "enemy")
            {
                rb.isTrigger = true;
            }
        }
        destination = waypoints[currentlocation];
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null) {
            return;
        }
        if (currentstatus == mode.idle)
        {

            agent.isStopped = true;

            ctime += Time.deltaTime;
            if (ctime > ridle)
            {
                currentstatus = mode.patrol;
                agent.isStopped = false;
                ctime = 0;
            }

        }


        if (currentstatus == mode.patrol)
        {


            float distance = Vector3.Distance(transform.position, destination.position);
            Debug.Log(distance);
            if (distance <= 1f)
            {
                ridle = Random.Range(3.0f, 7.0f);
                currentstatus = mode.idle;
                ctime = 0;
                currentlocation++;
                if (currentlocation >= waypoints.Length)
                {
                    currentlocation = 0;
                }
                destination = waypoints[currentlocation];
            }
            else
            {
                agent.SetDestination(destination.position);
            }
        }
        if (currentstatus == mode.chase)
        {
            agent.SetDestination(Player.position);
        }

        anim.SetFloat("speed", agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.isStopped = false;
            currentstatus = mode.chase;
            pupet.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentstatus = mode.idle;
            pupet.Pause();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (dead) {
            return;
           }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(deathanimationWait());
            //anamate deathboi

        }
        if (collision.gameObject.CompareTag("pew pew"))
        {
            //gameObject.SetActive(false);
            //transform.position = respawn_for_enemy.position;
            Debug.Log("dioe");
            ragdollOn();
            tag = "Untagged";
            Destroy(collision.gameObject);
            pupet.Pause();
        }

        IEnumerator deathanimationWait()
        {
            anim.SetTrigger("oof1");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(3);
        }

    }
}
