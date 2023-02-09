using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooooooooooooooooooooooooooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform barrel;
    public float frequency = 0.5f;
    public float bulletSpeed;
    private float ctime;
    public LayerMask layerMask;
    AudioSource shot;
    public bool canshoot;
    public Transform pistol;
    public Transform pistolDestination;
    public float pistolMovementSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        shot = GetComponents<AudioSource>()[2];
    }

    public void EnablePistol()
    {
        canshoot = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.M)) {
            EnablePistol();
        }

        if (canshoot == false)
        {
            return;
        }
        else
        {
            pistol.position = Vector3.MoveTowards(pistol.position, pistolDestination.position, pistolMovementSpeed * Time.deltaTime);

        }
        if (pistol.position == pistolDestination.position)
        {
            if (ctime >= frequency)
            {
                if (Input.GetMouseButton(0))
                {
                    GameObject clone = Instantiate(projectile, barrel.position, barrel.rotation);
                    Rigidbody rb = clone.GetComponent<Rigidbody>();
                    rb.AddForce(barrel.forward * bulletSpeed, ForceMode.Impulse);
                    Destroy(clone, 10);

                    ctime = 0;

                    shot.Play();
                }

            }
            else
            {
                ctime += Time.deltaTime;
            }
        }
    }
}
