using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
   public Gun gunScript;
   public Gun currentGun;
   public Rigidbody rb;
   public BoxCollider coll;
   public Transform player, WeaponHolder, fpsCam;

   public float pickUpRange;
   public float dropForwardForce, dropUpwardForce;

   public bool equipped;
   public static bool slotFull;
   public Text ammoDisplay;
   
   public PistolReference deactivate;

    // Used to shrink gun when on the floor
    private float shrinkTime = 10f;
    private float shrinkSpeed;
    private float remainingTime = 10f;
    private Vector3 initialScale;




    private void Awake()
    {
        deactivate = GameObject.Find("WeaponHolder").GetComponent<PistolReference>();
        ammoDisplay = GameObject.Find("ammo").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        WeaponHolder = GameObject.Find("WeaponHolder").GetComponent<Transform>();
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    private void Start() 
   {
              
        if(!equipped)
        {
             //a.selectedWeapon++;
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
          
        }

         if(equipped)
        {
            
           // a.selectedWeapon = 1;
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
           
        }

        initialScale = transform.localScale;
        // calculate the shrink speed based on the total time
        shrinkSpeed = transform.localScale.x / shrinkTime;
    }

   private void Update() 
   {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
            deactivate.DisablePistol();
        }

        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }

        if (!equipped)
        {
            remainingTime -= Time.deltaTime;

            // decrease the object's scale by the shrink speed
            transform.localScale = new Vector3(
                transform.localScale.x - shrinkSpeed * Time.deltaTime,
                transform.localScale.y - shrinkSpeed * Time.deltaTime,
                transform.localScale.z - shrinkSpeed * Time.deltaTime
                );

            // clamp the scale to a minimum value of zero
            transform.localScale = new Vector3(
                Mathf.Max(transform.localScale.x, 0),
                Mathf.Max(transform.localScale.y, 0),
                Mathf.Max(transform.localScale.z, 0)
                );

            if (remainingTime <= 0f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            remainingTime = 10f;
        }

    }

   private void PickUp() 
   {
        equipped = true; 
        slotFull = true;
        
        

        transform.SetParent(WeaponHolder);
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

        deactivate.EnablePistol();
    }

}
