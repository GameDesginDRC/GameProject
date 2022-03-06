using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_disp : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
   // private float DestroyTime = .0001f;
    private Vector3 newvec;
    private GameObject obj;
    private bool created;
    public int x;
    public int y;
    // Start is called before the first frame update
    void Start()
    {
        newvec = new Vector3(x,y, 0);
        created = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && created == false)
        {
            obj = Instantiate(FloatingTextPrefab, transform.position + newvec, Quaternion.identity, transform);
            created = true;
           // Destroy(obj, .0001f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (created == true)
        {
            created= false;
            Destroy(obj);
        }
    }
}
