using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPowerUps : MonoBehaviour
{
    private float shrinkTime = 10f;
    private float shrinkSpeed;
    private bool isPickedUp;
    private float remainingTime = 10f;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        // calculate the shrink speed based on the total time
        shrinkSpeed = transform.localScale.x / shrinkTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPickedUp)
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
}
