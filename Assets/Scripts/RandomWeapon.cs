using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Swordobj;
    public GameObject Gunobj;
    public GameObject LaserGunobj;
    public GameObject RocketLauncherobj;
    public static List<int> listofitems = new List<int> {1, 2, 3, 4};
    void Start()
    {
        Vector3 displx = new Vector3(-10f, .5f, 0);
        Vector3 disply = new Vector3(-5f, .5f, 0);
        int xindex = Random.Range(0, listofitems.Count);
        int xcount = listofitems[xindex];
        listofitems.Remove(xcount);
        //int ycount = Random.Range(1, 5);
        //Debug.Log(xcount);
        //Debug.Log(ycount);
        if (xcount == 1)
        {
            // change this later.
            var go = Instantiate(Swordobj, gameObject.transform.position + displx, Quaternion.identity);
            //var go = Instantiate(Swordobj, gameObject.transform.position + displx, Quaternion.identity);
        }
        else if (xcount == 2)
        {
            var go = Instantiate(Gunobj, gameObject.transform.position + displx, Quaternion.identity);
        }
        else if (xcount == 3)
        {
            var go = Instantiate(LaserGunobj, gameObject.transform.position + displx, Quaternion.identity);
        }
        else if (xcount == 4)
        {
            var go = Instantiate(RocketLauncherobj, gameObject.transform.position + displx, Quaternion.identity);
        }
        /*
        if (ycount == 1)
        {
            var go = Instantiate(Swordobj, gameObject.transform.position + disply, Quaternion.identity);
        }
        else if (ycount == 2)
        {
            var go = Instantiate(Gunobj, gameObject.transform.position + disply, Quaternion.identity);
        }
        else if (ycount == 3)
        {
            var go = Instantiate(LaserGunobj, gameObject.transform.position + disply, Quaternion.identity);
        }
        else if (ycount == 4)
        {
            var go = Instantiate(RocketLauncherobj, gameObject.transform.position + disply, Quaternion.identity);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
