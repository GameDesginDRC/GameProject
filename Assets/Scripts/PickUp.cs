using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject itemDisplay;
    public int count;
    //public GameObject player1_;
    public int price;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 1 && Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {    
            count = 0;
        }
        }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(count);
        if (collision.CompareTag("Player"))
        {
            // This is switching out equpiment
            if (Inventory._full[0] && Inventory._full[1])
            {
                // To switch out first weapon

                if (Input.GetKey(KeyCode.N) && gameObject.GetComponent<Equipment>() != null)
                {
                    ScoreKeeper.SubToGold(price);
                    // Disabling old replaced item
                    if (Inventory.pos_objs[0].GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = false;
                    }

                    // New item picked up
                    var go = Instantiate(itemDisplay, Inventory.spots[0].transform, false);
                    Inventory.pos_objs[0] = itemDisplay;
                    if (itemDisplay.GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = true;
                    }
                    Destroy(gameObject);
                }
                // To switch out second weapon

                if (Input.GetKey(KeyCode.M) && gameObject.GetComponent<Equipment>() != null)
                {
                    ScoreKeeper.SubToGold(price);
                    // Disabling old replaced item
                    if (Inventory.pos_objs[1].GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = false;
                    }

                    // New item picked up
                    var go = Instantiate(itemDisplay, Inventory.spots[1].transform, false);
                    Inventory.pos_objs[1] = itemDisplay;
                    if (itemDisplay.GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = true;
                    }
                    Destroy(gameObject);
                }
            }

            if (Inventory._full[2] && Inventory._full[3])
            {
                // To switch out first weapon

                if (Input.GetKey(KeyCode.N) && gameObject.GetComponent<Consumable>() != null)
                {
                    ScoreKeeper.SubToGold(price);
                    // Disabling old replaced item
                    if (Inventory.pos_objs[2].GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = false;
                    }

                    // New item picked up
                    var go = Instantiate(itemDisplay, Inventory.spots[2].transform, false);
                    Inventory.pos_objs[2] = itemDisplay;
                    if (itemDisplay.GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = true;
                    }
                    Destroy(gameObject);
                }
                // To switch out second weapon

                if (Input.GetKey(KeyCode.M) && gameObject.GetComponent<Consumable>() != null)
                {
                    ScoreKeeper.SubToGold(price);
                    // Disabling old replaced item
                    if (Inventory.pos_objs[3].GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = false;
                    }

                    // New item picked up
                    var go = Instantiate(itemDisplay, Inventory.spots[3].transform, false);
                    Inventory.pos_objs[3] = itemDisplay;
                    if (itemDisplay.GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = true;
                    }
                    Destroy(gameObject);
                }
            }

            if (Input.GetKey(KeyCode.B) && ScoreKeeper.gold > price)
            {
                //When item is an equipment
                if (gameObject.GetComponent<Equipment>() != null) {
                    for (int i = 0; i < 2; i++)
                    {
                        if (count == 0)
                        {

                            //StartCoroutine(Wait());
                            //count = 0;
                            if (Inventory._full[i] == false)
                            {
                                //Debug.Log(ScoreKeeper.gold);
                                ScoreKeeper.SubToGold(price);
                                //Debug.Log(ScoreKeeper.gold);
                                count = 1;
                                //     StartCoroutine(Wait());
                                // CAN PICKUP
                                Inventory._full[i] = true;
                                var go = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                Inventory.pos_objs[i] = itemDisplay;
                                if (itemDisplay.GetComponent<GunOn>() != null)
                                {
                                    RegularGun.CanShoot = true;
                                }

                                Destroy(gameObject);
                                //   StartCoroutine(Wait());
                                break;
                            }
                        }
                    }
                }
                //When item is a consumeable
                else if (gameObject.GetComponent<Consumable>() != null)
                {
                    for (int i = 2; i < 5; i++)
                    {
                        if (count == 0)
                        {

                            //StartCoroutine(Wait());
                            //count = 0;
                            if (Inventory._full[i] == false)
                            {
                                //Debug.Log(ScoreKeeper.gold);
                                ScoreKeeper.SubToGold(price);
                                Debug.Log(ScoreKeeper.gold);
                                count = 1;
                                //     StartCoroutine(Wait());
                                // CAN PICKUP
                                Inventory._full[i] = true;
                                var go = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                Inventory.pos_objs[i] = itemDisplay;

                                if (itemDisplay.GetComponent<Shield_Gen>() != null)
                                {
                                    go.GetComponent<Shield_Gen>().usednum = i;
                                }
                                Destroy(gameObject);
                                //   StartCoroutine(Wait());
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
