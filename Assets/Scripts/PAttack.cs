using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float AttackValue;
 

    public void Damage_Increased(int x){
        AttackValue += x;

    }
}
