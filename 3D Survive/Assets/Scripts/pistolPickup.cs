using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pistolPickup : MonoBehaviour
{
   public pistol gunScript;
   public pistol currentGun;
   public Rigidbody rb;
   public BoxCollider coll;
   public Transform player, WeaponHolder, fpsCam;

   public float pickUpRange;
   public float dropForwardForce, dropUpwardForce;

   public bool equipped;
   public static bool slotFull;
   public Text ammoDisplay;
   public WeaponSwitching wp;
   public GameObject deactivate;
   
  

   public void Start() 
   {
        if(!equipped)
        {
            
            //wp.selectedWeapon++;
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            
        }

         if(equipped)
        {
            //wp.selectedWeapon++;
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = false;
            
            
        }


   }

   public void Update() 
   {
    Vector3 distanceToPlayer = player.position - transform.position;
    if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)) 
        {
        
        //wp.selectedWeapon++;
        PickUp();
        
        
        }

   }

   public void PickUp() 
   {
          
        //wp.selectedWeapon = 1;
        deactivate.SetActive(false);
        equipped = true;
        slotFull = true;
        //transform.SetParent(WeaponHolder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;
        gunScript.enabled = true;
        
        
        

   }

   public void Drop() 
   {
        ammoDisplay.text = " ";
        equipped = false; 
        slotFull = false;
        

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-1f,1f);
        rb.AddTorque(new Vector3(random,random,random)*10);
        gunScript.enabled = false;


   }

}
