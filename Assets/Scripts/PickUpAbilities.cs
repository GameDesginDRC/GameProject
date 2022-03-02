using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbilities : MonoBehaviour
{
    public int Health_Increase = 50;
    public int Shield_Increase = 200;
    public int Damage_Increase = 5;
    private Player player_code;
    private PAttack pattack;

    void Start()
    {
        player_code = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        pattack = GameObject.FindGameObjectWithTag("Damage").GetComponent<PAttack>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Z))
            { 
                if (gameObject.name == "Damage+(Clone)")
                {
                    pattack.Damage_Increased(Damage_Increase);
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
