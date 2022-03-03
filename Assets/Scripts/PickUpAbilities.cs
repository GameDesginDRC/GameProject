using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbilities : MonoBehaviour
{
    private int Health_Increase = 50;
    private int Shield_Increase = 200;
    private int Damage_Increase = 1;
    private Player player_code;

    void Start()
    {
        player_code = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Z))
            { 
                if (gameObject.name == "Damage+(Clone)")
                {
                    Player.attack_mod += Damage_Increase;
                    Destroy(gameObject); 
                }
                else if (gameObject.name == "Shield+(Clone)")
                {
                    player_code.ShieldIncrease(Shield_Increase);
                    Destroy(gameObject); 
                }
                else if (gameObject.name == "Health+(Clone)")
                {
                    player_code.HealthIncrease(Health_Increase);
                    Destroy(gameObject); 
                }
                  
            }

               
        }
    }
}
