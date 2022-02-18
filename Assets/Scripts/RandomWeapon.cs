using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Shieldobj;
    public GameObject Gunobj;
    public GameObject Lanceobj;
    public GameObject LaserGunobj;
    public GameObject RocketLauncherobj;
    public GameObject hpPot;
    void Start()
    {
        Vector3 displx = new Vector3(-10f, .5f, 0);
        Vector3 disply = new Vector3(-5f, .5f, 0);
        int xcount = Random.Range(1, 4);
        int ycount = Random.Range(1, 4);
        Debug.Log(xcount);
        Debug.Log(ycount);
        if (xcount == 1)
        {
            var go = Instantiate(Shieldobj, gameObject.transform.position + displx, Quaternion.identity);
        }
        else if (xcount == 2)
        {
            var go = Instantiate(Gunobj, gameObject.transform.position + displx, Quaternion.identity);
        }
        else if (xcount == 3)
        {
            // var go = Instantiate(Lanceobj, gameObject.transform.position + displx, Quaternion.identity);
            var go = Instantiate(hpPot, gameObject.transform.position + displx, Quaternion.identity);
        }
        else if (xcount == 4)
        {
            var go = Instantiate(LaserGunobj, gameObject.transform.position + displx, Quaternion.identity);
        }
        else if (xcount == 5)
        {
            var go = Instantiate(RocketLauncherobj, gameObject.transform.position + displx, Quaternion.identity);
        }

        if (ycount == 1)
        {
            var go = Instantiate(Shieldobj, gameObject.transform.position + disply, Quaternion.identity);
        }
        else if (ycount == 2)
        {
            var go = Instantiate(Gunobj, gameObject.transform.position + disply, Quaternion.identity);
        }
        else if (ycount == 3)
        {
            //var go = Instantiate(Lanceobj, gameObject.transform.position + disply, Quaternion.identity);
            var go = Instantiate(hpPot, gameObject.transform.position + disply, Quaternion.identity);
        }
        else if (ycount == 4)
        {
            var go = Instantiate(LaserGunobj, gameObject.transform.position + disply, Quaternion.identity);
        }
        else if (ycount == 5)
        {
            var go = Instantiate(RocketLauncherobj, gameObject.transform.position + disply, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
