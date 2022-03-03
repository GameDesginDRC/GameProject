using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float AttackValue;

    [SerializeField]
    public static int AttackMod;

    public static bool changed = false;

    void update(){
        if (changed){
            AttackValue += AttackMod;
            changed = false;
        }
    }
    
    public static void IncreaseAttack(int atk)
    {
        AttackMod = atk;
        changed = true;
        Increased(atk);
    }
}
