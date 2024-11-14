using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterMovement3D : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject screen;
    [SerializeField] GameObject screenCam;
    public float speed = 12f;
    public float gravity = -10f;
    CharacterController controller;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistace = 0.4f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] LayerMask interactionMask;

    bool lockMovement = false;
    bool inPc = false;

    Vector3 velocity;
    bool grounded;

    public float sensitivity = 100f;
    float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockMovement)
        {
            grounded = Physics.CheckSphere(groundCheck.position, groundDistace, groundMask);

            if (grounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            //Cam Stuff
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            playerCam.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
            player.transform.Rotate(Vector3.up * mouseX);
            transform.Rotate(Vector3.up * mouseX);

            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(playerCam.transform.position, playerCam.transform.TransformDirection(Vector3.forward), out hit, 2.5f, interactionMask))
                {
                    if (hit.transform.gameObject.layer == 7)
                    {
                        screenCam.SetActive(true);
                        player.SetActive(false);
                        lockMovement = true;
                    }
                }
            }
        }
        else if (inPc)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                player.SetActive(true);
                inPc = false;
                screenCam.SetActive(false);
                screen.SetActive(false);
            }
        }
    }
    public void Test(ICinemachineCamera cam1, ICinemachineCamera cam2)
    {
        if(cam2 != null)
        {
            if (cam1.Name == "PCCam")
            {
                Invoke("startPc", 0.5f);
            }
            else if (cam2.Name == "PCCam")
            {
                Invoke("stopPc", 0.5f);
            }
        }
    }

    public void startPc()
    {
        Cursor.lockState = CursorLockMode.None;
        screen.SetActive(true);
        inPc = true;
    }

    public void stopPc()
    {
        Cursor.lockState = CursorLockMode.Locked;
        lockMovement = false;
    }
}
