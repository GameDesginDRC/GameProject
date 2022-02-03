using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inv;
    public GameObject itemDisplay;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           if (Input.GetKey(KeyCode.E))
           {
               // StartCoroutine(Wait());
                for (int i = 0; i < inv.spots.Length; i++)
                {
                 //   StartCoroutine(Wait());
                    if (inv._full[i] == false)
                    {
                   //     StartCoroutine(Wait());
                        // CAN PICKUP
                        inv._full[i] = true;
                        Instantiate(itemDisplay, inv.spots[i].transform, false);
                        Destroy(gameObject);
                     //   StartCoroutine(Wait());
                        break;
                    }
                }
               // StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
