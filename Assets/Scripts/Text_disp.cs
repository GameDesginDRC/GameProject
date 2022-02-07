using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_disp : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
   // private float DestroyTime = .0001f;
    private Vector3 newvec;
    private GameObject obj;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        newvec = new Vector3(-1.0f, 5.0f, 0);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null & counter == 0)
        {
            obj = Instantiate(FloatingTextPrefab, transform.position + newvec, Quaternion.identity, transform);
            counter++;
           // Destroy(obj, .0001f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (counter == 1)
        {
            counter--;
            Destroy(obj);
        }
    }
}