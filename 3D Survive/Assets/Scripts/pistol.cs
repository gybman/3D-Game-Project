
using System;
using System.Diagnostics;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pistol : MonoBehaviour{


    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public float maxAmmo = Mathf.Infinity;
    public float currentAmmo;
    public float magazineSize = 50;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpscamera;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;

    public Animator animator;
    public AudioClip shooting;
    public AudioClip Re;
    public Text ammoDisplay;
    public pistolPickup pk;
    

    
    
    


    private float nextTimeToFire = 0f;

    public void Start ()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable ()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    // Update is called once per frame
   public void Update ()
    {
        ammoDisplay.text = currentAmmo.ToString();
        if(currentAmmo == 0  &&  magazineSize == 0) 
        {
            
            animator.SetBool("Reloading", false);
            
            
            
            
            return;
        }

        if (isReloading)
            return;
        

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if(currentAmmo == 0 &&  magazineSize > 0 && !isReloading) 
        {
            StartCoroutine(Reload());
        }

    }

    IEnumerator Reload ()
    {
        isReloading = true;

        animator.SetBool("Reloading", true);
        GetComponentInParent<AudioSource>().PlayOneShot(Re);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);

        if(magazineSize >= maxAmmo) 
        {
            currentAmmo = maxAmmo;
            magazineSize -= maxAmmo;
        }

        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }
        isReloading = false;
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(1f);

        
    }

    void Shoot ()
    {
        muzzleflash.Play();
        
        currentAmmo--;
        GetComponentInParent<AudioSource>().PlayOneShot(shooting);

        RaycastHit hit;
        if (Physics.Raycast(fpscamera.transform.position, fpscamera.transform.forward, out hit, range))
        {
            // UnityEngine.Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }
}