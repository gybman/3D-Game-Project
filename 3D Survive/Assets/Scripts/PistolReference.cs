using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolReference : MonoBehaviour
{
    public GameObject pistolRef;
    // Start is called before the first frame update
    void Awake()
    {
        pistolRef = GameObject.Find("Pistol equiped");
    }

    public void DisablePistol()
    {
        pistolRef.SetActive(false);
    }

    public void EnablePistol()
    {
        pistolRef.SetActive(true);
    }
}
