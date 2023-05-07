using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon = 0;
    

    // Start is called before the first frame update
    void Start() {
        SelectWeapon();
    }

    // Update is called once per frame
    public void Update() {

        int prevWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if(prevWeapon != selectedWeapon) 
        {
            SelectWeapon(); 
        }      

    }

   public void SelectWeapon()
    {
        int increase = 0;
        foreach (Transform weapon in transform)
        {
    
            if (increase == selectedWeapon){
                weapon.gameObject.SetActive(true);
            }
            else{

                weapon.gameObject.SetActive(false);
            }    
            increase++;
            
        }
    }
}