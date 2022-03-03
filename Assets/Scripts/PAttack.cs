using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float AttackValue;

    [SerializeField]
    public int AttackMod;

    private void Start()
    {
        AttackMod = Player.attack_mod;
        Debug.Log("Attack Mod Val = " + AttackMod.ToString());
        AttackValue += AttackMod;
    }

    void Update(){
    }
    
    public static void IncreaseAttack(int atk)
    {
    }
}
