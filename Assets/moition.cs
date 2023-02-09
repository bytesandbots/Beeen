using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moition : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float speedx = 70;
    public float speedy = 70;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float h = Input.GetAxis("Mouse X") * speedx;
        float v = Input.GetAxis("Mouse Y") * speedy;
        Vector3 rot = new Vector3(-v, h, 0);
        transform.Rotate(rot * Time.deltaTime);
        Vector3 temp = transform.eulerAngles;
        temp.z = 0;
        transform.eulerAngles = temp;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GetComponent<CharacterController>().height = 1f;
            GetComponent<CharacterController>().center = new Vector3(0,0,0);

            CapsuleCollider c = GetComponent<CapsuleCollider>();
            c.height =1f;
            c.center = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GetComponent<CharacterController>().height = 2f;
            GetComponent<CharacterController>().center = new Vector3(0, 0, 0);
            CapsuleCollider c = GetComponent<CapsuleCollider>();
            c.height = 2f;
            c.center = new Vector3(0, 0, 0);
        }


        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}
