using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float AttackValue;
    private Player player_code;

    void Start(){
        player_code = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        AttackValue += player_code.max_atk;
    }

}
