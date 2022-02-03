using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject itemDisplay;
    public int count;
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
        Debug.Log(count);
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                // StartCoroutine(Wait());

                    for (int i = 0; i < Inventory.spots.Length; i++)
                    {
                        if (count == 0)
                        {
                            
                            //StartCoroutine(Wait());
                            //count = 0;
                            if (Inventory._full[i] == false)
                            {
                                count = 1;
                            //     StartCoroutine(Wait());
                            // CAN PICKUP
                                Inventory._full[i] = true;
                                Instantiate(itemDisplay, Inventory.spots[i].transform, false);
                                Inventory.pos_objs[i] = itemDisplay;
                                Destroy(gameObject);
                                //   StartCoroutine(Wait());
                                break;
                            }
                        }
                    
                    // StartCoroutine(Wait());
                }
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
