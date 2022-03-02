using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAbilities : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ShieldBoost;
    public GameObject HealthBoost;
    public GameObject DamageBoost;
    
    void Start()
    {
        Vector3 displ1 = new Vector3(-8f, .5f, 0);
        Vector3 displ2 = new Vector3(0f, .5f, 0);
        Vector3 displ3 = new Vector3(8f, .5f, 0);
        
        Instantiate(ShieldBoost, gameObject.transform.position + displ1, Quaternion.identity);
        Instantiate(HealthBoost, gameObject.transform.position + displ2, Quaternion.identity);
        Instantiate(DamageBoost, gameObject.transform.position + displ3, Quaternion.identity);
        
    }



}
