using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour
{
    [SerializeField]
    private GameObject lanceHitbox;
    [SerializeField]
    public static bool hasLance = false;
    [SerializeField]
    private bool coolingDown = false;
    [SerializeField]
    private Animator animator;

    void LanceCooldown()
    {
        animator.SetBool("Attacking", false);
        coolingDown = false;
        lanceHitbox.tag = "Untagged";
    }

    void LanceAttack()
    {
        animator.SetBool("Attacking", true);
        coolingDown = true;
        lanceHitbox.tag = "PlayerAttack";
        Invoke("LanceCooldown", .3f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && hasLance && !coolingDown)
        {
            LanceAttack();
        }
    }
}
