using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{

    private float normalFOV = 60f;
    private float sprintFOV = 90f;
    private float camMovementSpeed = 10f;

    private Camera cam;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isSprinting() || playerMovement.IsSliding())
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, sprintFOV, Time.deltaTime * camMovementSpeed);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normalFOV, Time.deltaTime * camMovementSpeed);
        }
    }
}
