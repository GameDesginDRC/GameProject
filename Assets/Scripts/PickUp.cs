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

    private float waitT;
    // Start is called before the first frame update

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip buySound;

    void Start()
    {
        waitT = .2f;
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));

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
        waitT += Time.deltaTime;
        //if (count == 1 && Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        if (count == 1 && waitT > .5f)
        {    
            count = 0;
        }
        }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(RandomWeapon.listofitems.Count);
        if (collision.CompareTag("Player"))
        {
            // This is switching out equpiment
            if (Inventory._full[0] && Inventory._full[1] && Input.GetKey(KeyCode.B) && gameObject.GetComponent<Equipment>() != null && ScoreKeeper.gold >= price)
            {
                // To switch out first weapon

                // if (Input.GetKey(KeyCode.B) && gameObject.GetComponent<Equipment>() != null && ScoreKeeper.gold >= price)
                // {
                if (count == 0)
                {
                    waitT = 0;
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
                    //ScoreKeeper.SubToGold(price);
                    ScoreKeeper.gold -= price;
                    ScoreKeeper.AddToGold(0);
                    // Disabling old replaced item
                    if (Inventory.pos_objs[InvTracker.invcount].GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = false;
                        //Destroy(FindObjectOfType<GunOn>());
                        RandomWeapon.listofitems.Add(2);
                        Debug.Log("Works!"); 
                    }
                    else if (Inventory.pos_objs[InvTracker.invcount].GetComponent<RLOn>() != null)
                    {
                        RocketLauncher.CanShoot = false;
                        //Destroy(FindObjectOfType<RLOn>());
                        RandomWeapon.listofitems.Add(4);
                    }
                    else if (Inventory.pos_objs[InvTracker.invcount].GetComponent<LaserGunOn>() != null)
                    {
                        LaserGun.CanShoot = false;
                        //Destroy(FindObjectOfType<GunOn>());
                        RandomWeapon.listofitems.Add(3);
                    }
                    else if (Inventory.pos_objs[InvTracker.invcount].GetComponent<SwordOn>() != null)
                    {
                        RegularSword.hasSword = false;
                        RandomWeapon.listofitems.Add(1);
                        //Destroy(FindObjectOfType<GunOn>());
                    }
                    // New item picked up
                    //var go = Instantiate(itemDisplay, Inventory.spots[InvTracker.invcount].transform, false);
                    Inventory.pos_objs[InvTracker.invcount] = itemDisplay;
                    if (itemDisplay.GetComponent<GunOn>() != null)
                    {
                        RegularGun.CanShoot = true;
                        RandomWeapon.listofitems.Remove(2);
                    }
                    else if (itemDisplay.GetComponent<RLOn>() != null)
                    {
                        RocketLauncher.CanShoot = true;
                        RandomWeapon.listofitems.Remove(4);
                        //Destroy(FindObjectOfType<GunOn>());
                    }
                    else if (itemDisplay.GetComponent<LaserGunOn>() != null)
                    {
                        LaserGun.CanShoot = true;
                        RandomWeapon.listofitems.Remove(3);
                        //Destroy(FindObjectOfType<GunOn>());
                    }
                    else if (itemDisplay.GetComponent<SwordOn>() != null)
                    {
                        RegularSword.hasSword = true;
                        RandomWeapon.listofitems.Remove(1);
                        //Destroy(FindObjectOfType<GunOn>());
                    }
                    Destroy(gameObject);
                }
                // }
            }

            else if (Input.GetKey(KeyCode.B) && ScoreKeeper.gold >= price)
            {

                if (Inventory._full[2] && Inventory.items[2].GetComponent<Shield_Gen>() != null && itemDisplay.GetComponent<Shield_Gen>() != null && Shield_Gen.shield_count <= 2)
                //if (Inventory._full[2])
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        //ScoreKeeper.SubToGold(price);
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        Shield_Gen.shield_count += 1;
                        IncrConsume(2);
                        aSource.PlayOneShot(buySound);
                        //   Destroy(gameObject);
                    }

                }
                else if (Inventory._full[2] && Inventory.items[2].GetComponent<HP_Pot>() != null && itemDisplay.GetComponent<HP_Pot>() != null && HP_Pot.HPpot_count <= 2)
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        //ScoreKeeper.SubToGold(price);
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        HP_Pot.HPpot_count += 1;
                        IncrConsume(2);
                        aSource.PlayOneShot(buySound);
                        //   Destroy(gameObject);
                    }

                }
                else if (Inventory._full[2] && Inventory.items[2].GetComponent<GrenadeOn>() != null && itemDisplay.GetComponent<GrenadeOn>() != null && GrenadeOn.GrenadeCount <= 2)
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        //ScoreKeeper.SubToGold(price);
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        GrenadeOn.GrenadeCount += 1;
                        IncrConsume(2);
                        aSource.PlayOneShot(buySound);
                        //   Destroy(gameObject);
                    }

                }
                // Check if second consumable is full and is a shield
                else if (Inventory._full[3] && Inventory.items[3].GetComponent<Shield_Gen>() != null && itemDisplay.GetComponent<Shield_Gen>() != null && Shield_Gen.shield_count <= 2)
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        //ScoreKeeper.SubToGold(price);
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        Shield_Gen.shield_count += 1;
                        IncrConsume(3);
                        aSource.PlayOneShot(buySound);
                        // Destroy(gameObject);
                    }

                }
                else if (Inventory._full[3] && Inventory.items[3].GetComponent<HP_Pot>() != null && itemDisplay.GetComponent<HP_Pot>() != null && HP_Pot.HPpot_count <= 2)
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        HP_Pot.HPpot_count += 1;
                        IncrConsume(3);
                        aSource.PlayOneShot(buySound);
                        //  Destroy(gameObject);
                    }

                }
                else if (Inventory._full[3] && Inventory.items[3].GetComponent<GrenadeOn>() != null && itemDisplay.GetComponent<GrenadeOn>() != null && GrenadeOn.GrenadeCount <= 2)
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        //ScoreKeeper.SubToGold(price);
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        GrenadeOn.GrenadeCount += 1;
                        IncrConsume(3);
                        aSource.PlayOneShot(buySound);
                        // Destroy(gameObject);
                    }

                }
                else if (Inventory._full[4] && Inventory.items[4].GetComponent<Shield_Gen>() != null && itemDisplay.GetComponent<Shield_Gen>() != null && Shield_Gen.shield_count <= 2)
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        //ScoreKeeper.SubToGold(price);
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        Shield_Gen.shield_count += 1;
                        IncrConsume(4);
                        aSource.PlayOneShot(buySound);
                        // Destroy(gameObject);
                    }

                }
                else if (Inventory._full[4] && Inventory.items[4].GetComponent<HP_Pot>() != null && itemDisplay.GetComponent<HP_Pot>() != null && HP_Pot.HPpot_count <= 2)
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        HP_Pot.HPpot_count += 1;
                        IncrConsume(4);
                        aSource.PlayOneShot(buySound);
                        // Destroy(gameObject);
                    }

                }
                else if (Inventory._full[4] && Inventory.items[4].GetComponent<GrenadeOn>() != null && itemDisplay.GetComponent<GrenadeOn>() != null && GrenadeOn.GrenadeCount <= 2)
                {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        //ScoreKeeper.SubToGold(price);
                        ScoreKeeper.gold -= price;
                        ScoreKeeper.AddToGold(0);
                        GrenadeOn.GrenadeCount += 1;
                        IncrConsume(4);
                        aSource.PlayOneShot(buySound);
                        // Destroy(gameObject);
                    }

                }
                //When item is an equipment
                else if (gameObject.GetComponent<Equipment>() != null)
                {
                   // for (int i = 0; i < 2; i++)
                  //  {
                        if (count == 0)
                        {
                            waitT = 0;
                            count = 1; 
                            //StartCoroutine(Wait());
                            //count = 0;
                            if (Inventory._full[0] == false)
                            {


                                //Debug.Log(ScoreKeeper.gold);
                                //ScoreKeeper.SubToGold(price);
                                ScoreKeeper.gold -= price;
                                ScoreKeeper.AddToGold(0);
                                count = 1;
                                Inventory._full[0] = true;
                             //   if (i == 0)
                             //   {
                                Inventory.spots[0].GetComponent<DestroyItem>().dst = true;
                                    //Inventory.items[0] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                Instantiate(itemDisplay, Inventory.spots[0].transform, false);
                                Inventory.items[0] = itemDisplay;
                                Inventory.pos_objs[0] = itemDisplay;
                            }
                                else if (Inventory._full[1] == false)
                                {
                                    Inventory.spots[1].GetComponent<DestroyItem>().dst = true;
                                    //Inventory.items[1] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                    Instantiate(itemDisplay, Inventory.spots[1].transform, false);
                                    Inventory.items[1] = itemDisplay;
                                    Inventory.pos_objs[1] = itemDisplay;

                            if (itemDisplay.GetComponent<GunOn>() != null)
                            {
                                RegularGun.CanShoot = true;
                                RandomWeapon.listofitems.Remove(2);
                            }
                            else if (itemDisplay.GetComponent<RLOn>() != null)
                            {
                                RocketLauncher.CanShoot = true;
                                RandomWeapon.listofitems.Remove(4);
                                //Destroy(FindObjectOfType<GunOn>());
                            }
                            else if (itemDisplay.GetComponent<LaserGunOn>() != null)
                            {
                                LaserGun.CanShoot = true;
                                RandomWeapon.listofitems.Remove(3);
                                //Destroy(FindObjectOfType<GunOn>());
                            }
                            else if (itemDisplay.GetComponent<SwordOn>() != null)
                            {
                                RegularSword.hasSword = true;
                                RandomWeapon.listofitems.Remove(1);
                                //Destroy(FindObjectOfType<GunOn>());
                            }
                        }
                                //Inventory.pos_objs[i] = itemDisplay;
                               // if (itemDisplay.GetComponent<GunOn>() != null)
                               // {
                               //     RegularGun.CanShoot = true;
                               // }

                                Destroy(gameObject);
                                //   StartCoroutine(Wait());
                               
                           // }
                       // }
                    }
                }
                //When item is a consumeable
                else if (gameObject.GetComponent<Consumable>() != null)
                {
                    //   for (int i = 2; i < 5; i++)
                    //    {
                    if (count == 0)
                    {
                        waitT = 0;
                        count = 1;
                        //StartCoroutine(Wait());
                        //count = 0;
                        if (Inventory._full[2] == false && itemDisplay.GetComponent<HP_Pot>() != null)
                        {


                            // if (i == 2 && itemDisplay.GetComponent<HP_Pot>() != null)
                            //{
                            //Debug.Log(ScoreKeeper.gold);
                            //ScoreKeeper.SubToGold(price);
                            ScoreKeeper.gold -= price;
                            ScoreKeeper.AddToGold(0);
                            count = 1;
                            //     StartCoroutine(Wait());
                            // CAN PICKUP
                            Inventory._full[2] = true;
                            IncrConsume(2);

                            //Inventory.items[2] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                            Instantiate(itemDisplay, Inventory.spots[2].transform, false);
                            Inventory.items[2] = itemDisplay;
                            Inventory.pos_objs[2] = itemDisplay;
                            if (itemDisplay.GetComponent<HP_Pot>() != null)
                            {
                                Inventory.items[2].GetComponent<HP_Pot>().usednum = 2;
                                HP_Pot.HPpot_count += 1;
                            }

                        }

                        else if (Inventory._full[3] == false && itemDisplay.GetComponent<Shield_Gen>() != null)
                        {
                            //Debug.Log(ScoreKeeper.gold);
                            //ScoreKeeper.SubToGold(price);
                            ScoreKeeper.gold -= price;
                            ScoreKeeper.AddToGold(0);
                            count = 1;
                            //     StartCoroutine(Wait());
                            // CAN PICKUP
                            Inventory._full[3] = true;
                            IncrConsume(3);

                            //Inventory.items[3] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                            Instantiate(itemDisplay, Inventory.spots[3].transform, false);
                            Inventory.items[3] = itemDisplay;
                            Inventory.pos_objs[3] = itemDisplay;
                            if (itemDisplay.GetComponent<Shield_Gen>() != null)
                            {
                                Inventory.items[3].GetComponent<Shield_Gen>().usednum = 3;
                                Shield_Gen.shield_count += 1;
                            }
                          
                        }
                        else if (Inventory._full[4] == false && itemDisplay.GetComponent<GrenadeOn>() != null)
                        {
                            //Debug.Log(ScoreKeeper.gold);
                            //ScoreKeeper.SubToGold(price);
                            ScoreKeeper.gold -= price;
                            ScoreKeeper.AddToGold(0);
                            count = 1;
                            //     StartCoroutine(Wait());
                            // CAN PICKUP
                            Inventory._full[4] = true;
                            IncrConsume(4);

                            //Inventory.items[3] = Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                            Instantiate(itemDisplay, Inventory.spots[4].transform, false);
                            Inventory.items[4] = itemDisplay;
                            Inventory.pos_objs[4] = itemDisplay;
                            if (itemDisplay.GetComponent<GrenadeOn>() != null)
                            {
                                Inventory.items[4].GetComponent<GrenadeOn>().usednum = 4;
                                GrenadeOn.GrenadeCount += 1;
                            }
                        }

                        //Destroy(gameObject);

                        

                    }
                }
            }
        }
    }
        
    

    private void IncrConsume(int ind)
    {
        if (ind == 2)
        {
            ConsumeCountText.ChangeConsume(1);
        }
        else if (ind == 3)
        {
            ConsumeText2.ChangeConsume2(1);
        }
        else if (ind == 4)
        {
            ConsumeText3.ChangeConsume3(1);
        }
    }

    private void whichEquip()
    {
        if (itemDisplay.GetComponent<LaserGunOn>() != null)
        {
            LaserGun.CanShoot = true;
            RandomWeapon.listofitems.Remove(3);
        }
        else if (itemDisplay.GetComponent<GunOn>() != null)
        {
            RegularGun.CanShoot = true;
            RandomWeapon.listofitems.Remove(2);
        }
        else if (itemDisplay.GetComponent<RLOn>() != null)
        {
            RocketLauncher.CanShoot = true;
            RandomWeapon.listofitems.Remove(4);
        }
        else if (itemDisplay.GetComponent<SwordOn>() != null)
        {
            RegularSword.hasSword = true;
            RandomWeapon.listofitems.Remove(1);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
