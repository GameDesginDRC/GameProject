using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularSword : MonoBehaviour
{
    [SerializeField]
    private GameObject swordHitbox;
    [SerializeField]
    private bool hasSword = false;
    [SerializeField]
    private bool coolingDown = false;

    void SwordCooldown()
    {
        coolingDown = false;
        swordHitbox.tag = "Untagged";
    }

    void SwordAttack()
    {
        coolingDown = true;
        swordHitbox.tag = "PlayerAttack";
        Invoke("SwordCooldown", .5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z) && hasSword && !coolingDown)
        {
            SwordAttack();
        }
    }
}
