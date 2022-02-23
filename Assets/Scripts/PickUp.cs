using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    // NOTE: WHEN THE OTHER WEAPONS SPRITES ARE IMPLEMENTED CHECKTO SEE IF THEY ARE != NULL
    public GameObject itemDisplay;
    public int count;
    //public GameObject player1_;
    [SerializeField]
    public int price;
    // Start is called before the first frame update

    void Start()
    {
        count = 0;
        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "Shop 1" && item3.GetComponent<HP_Pot>() != null)
        {
            count = 1;
        }*/
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

                if (Input.GetKey(KeyCode.Q) && gameObject.GetComponent<Equipment>() != null)
                {
                    if (count == 0)
                    {
                        count = 1;
                        if (InvTracker.invcount == 0)
                        {
                            // Destroy(Inventory.items[0]);
                            //Inventory.items[0] = Instantiate(itemDisplay, Inventory.spots[InvTracker.invcount].transform, false);
                            Inventory.spots[0].GetComponent<DestroyItem>().dst = true;
                            Instantiate(itemDisplay, Inventory.spots[InvTracker.invcount].transform, false);
                            Inventory.items[0] = itemDisplay;
                        }
                        else
                        {
                            //Destroy(Inventory.items[1]);
                            //Inventory.items[1] = Instantiate(itemDisplay, Inventory.spots[InvTracker.invcount].transform, false);
                            Inventory.spots[1].GetComponent<DestroyItem>().dst = true;
                            Instantiate(itemDisplay, Inventory.spots[InvTracker.invcount].transform, false);
                            Inventory.items[1] = itemDisplay;
                        }
                        ScoreKeeper.SubToGold(price);
                        // Disabling old replaced item
                        if (Inventory.pos_objs[InvTracker.invcount].GetComponent<GunOn>() != null)
                        {
                            RegularGun.CanShoot = false;
                            Destroy(FindObjectOfType<GunOn>());
                        }
                        else if (Inventory.pos_objs[InvTracker.invcount].GetComponent<RLOn>() != null)
                        {
                            RocketLauncher.CanShoot = false;
                            Destroy(FindObjectOfType<RLOn>());
                        }
                        else if (Inventory.pos_objs[InvTracker.invcount].GetComponent<LaserGunOn>() != null)
                        {
                            LaserGun.CanShoot = false;
                            //Destroy(FindObjectOfType<GunOn>());
                        }
                        else if (Inventory.pos_objs[InvTracker.invcount].GetComponent<SwordOn>() != null)
                        {
                            RegularSword.hasSword = false;
                            //Destroy(FindObjectOfType<GunOn>());
                        }
                        // New item picked up
                        //var go = Instantiate(itemDisplay, Inventory.spots[InvTracker.invcount].transform, false);
                        Inventory.pos_objs[InvTracker.invcount] = itemDisplay;
                        if (itemDisplay.GetComponent<GunOn>() != null)
                        {
                            RegularGun.CanShoot = true;
                        }
                        else if (itemDisplay.GetComponent<RLOn>() != null)
                        {
                            RocketLauncher.CanShoot = true;
                            //Destroy(FindObjectOfType<GunOn>());
                        }
                        else if (itemDisplay.GetComponent<LaserGunOn>() != null)
                        {
                            LaserGun.CanShoot = true;
                            //Destroy(FindObjectOfType<GunOn>());
                        }
                        else if (itemDisplay.GetComponent<SwordOn>() != null)
                        {
                            RegularSword.hasSword = true;
                            //Destroy(FindObjectOfType<GunOn>());
                        }
                        Destroy(gameObject);
                    }
                }
            }

            if (Input.GetKey(KeyCode.B) && ScoreKeeper.gold > price)
            {
                if (Inventory._full[2] && Inventory.items[2].GetComponent<Shield_Gen>() != null && itemDisplay.GetComponent<Shield_Gen>() != null)
                //if (Inventory._full[2])
                {
                    if (count == 0)
                    {
                        count = 1;
                        ScoreKeeper.SubToGold(price);
                        Shield_Gen.shield_count += 1;
                        Destroy(gameObject);
                    }

                }
                else if (Inventory._full[2] && Inventory.items[2].GetComponent<HP_Pot>() != null && itemDisplay.GetComponent<HP_Pot>() != null)
                    {
                        if (count == 0)
                        {
                            count = 1;
                            ScoreKeeper.SubToGold(price);
                            HP_Pot.HPpot_count += 1;
                            Destroy(gameObject);
                        }

                    }
                    // Check if second consumable is full and is a shield
                   else if (Inventory._full[3] && Inventory.items[3].GetComponent<Shield_Gen>() != null && itemDisplay.GetComponent<Shield_Gen>() != null)
                  {
                    if (count == 0)
                    {
                        count = 1;
                        ScoreKeeper.SubToGold(price);
                        Shield_Gen.shield_count += 1;
                        Destroy(gameObject);
                    }

                }
                else if (Inventory._full[3] && Inventory.items[3].GetComponent<HP_Pot>() != null && itemDisplay.GetComponent<HP_Pot>() != null)
                {
                    if (count == 0)
                    {
                        count = 1;
                        ScoreKeeper.SubToGold(price);
                        HP_Pot.HPpot_count += 1;
                        Destroy(gameObject);
                    }

                }
                //When item is an equipment
                else if (gameObject.GetComponent<Equipment>() != null) {
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
                                if (i == 0)
                                {
                                    Inventory.spots[0].GetComponent<DestroyItem>().dst = true;
                                    //Inventory.items[0] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Inventory.items[0] = itemDisplay;
                                    Inventory.pos_objs[i] = itemDisplay;
                                } else
                                {
                                    Inventory.spots[1].GetComponent<DestroyItem>().dst = true;
                                    //Inventory.items[1] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Inventory.items[1] = itemDisplay;
                                    Inventory.pos_objs[i] = itemDisplay;
                                }
                                //Inventory.pos_objs[i] = itemDisplay;
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
                    for (int i = 2; i < 4; i++)
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
                                if (i == 2)
                                {
                                    //Inventory.items[2] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Inventory.items[2] = itemDisplay;
                                    Inventory.pos_objs[i] = itemDisplay;
                                    if (itemDisplay.GetComponent<Shield_Gen>() != null)
                                    {
                                        Inventory.items[2].GetComponent<Shield_Gen>().usednum = i;
                                        Shield_Gen.shield_count += 1;
                                    } else if (itemDisplay.GetComponent<HP_Pot>() != null)
                                    {
                                        Inventory.items[2].GetComponent<HP_Pot>().usednum = i;
                                        HP_Pot.HPpot_count += 1;
                                    }
                                }

                                else if (i == 3)
                                {
                                    //Inventory.items[3] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Inventory.items[3] = itemDisplay;
                                    Inventory.pos_objs[i] = itemDisplay;
                                    if (itemDisplay.GetComponent<Shield_Gen>() != null)
                                    {
                                        Inventory.items[3].GetComponent<Shield_Gen>().usednum = i;
                                        Shield_Gen.shield_count += 1;
                                    }
                                    else if (itemDisplay.GetComponent<HP_Pot>() != null)
                                    {
                                        Inventory.items[3].GetComponent<HP_Pot>().usednum = i;
                                        HP_Pot.HPpot_count += 1;
                                    }
                                }
                                //Inventory.pos_objs[i] = itemDisplay;
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
