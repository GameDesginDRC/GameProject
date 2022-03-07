using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbilities : MonoBehaviour
{
    private int Health_Increase = 25;
    private int Shield_Increase = 50;
    private int Damage_Increase = 2;
    private Player player_code;
    private float waitE = 0;

    void Start()
    {
        player_code = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        waitE = 0;
    }

    void Update()
    {
        waitE += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Z) && waitE >= 0)
            { 
                if (gameObject.name == "Damage+(Clone)")
                {
                    Player.attack_mod += Damage_Increase;
                    Destroy(gameObject); 
                }
                else if (gameObject.name == "Shield+(Clone)")
                {
                    player_code.ShieldIncrease(Shield_Increase);
                    GenBar.Sabill = true;
                    Destroy(gameObject); 
                }
                else if (gameObject.name == "Health+(Clone)")
                {
                    player_code.HealthIncrease(Health_Increase);
                    HPBar.abill = true;
                    Destroy(gameObject); 
                }
                waitE = -1;
            }
               
        }
    }
}
