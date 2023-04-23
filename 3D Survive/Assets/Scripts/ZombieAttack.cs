using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private float timeToAttack;
    private PlayerHealth player;
    [SerializeField] Animator animator;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("inAttackRange"))
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                player.TakeDamage();
                timer = 0;
                Debug.Log("Attacked the player");
            }
        }
        else
        {
            timer = 0;
        }
    }
}
