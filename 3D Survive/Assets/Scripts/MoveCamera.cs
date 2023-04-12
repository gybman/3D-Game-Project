using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Summary:
 * Makes camera follow the player
 */
public class MoveCamera : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}
