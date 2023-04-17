using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBarrier : MonoBehaviour
{

    private bool disableBarrier;
    private PlayerMovement player;
    private BoxCollider barrierCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        barrierCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsSliding())
        {
            DisableBarrier();
        }
        else
        {
            EnableBarrier();
        }
    }


    void DisableBarrier()
    {
        barrierCollider.enabled = false;
    }

    void EnableBarrier()
    {
        barrierCollider.enabled = true;
    }
}
