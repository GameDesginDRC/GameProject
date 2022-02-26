using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularSword : MonoBehaviour
{
    [SerializeField]
    private GameObject swordHitbox;
    [SerializeField]
    public static bool hasSword = true;
    [SerializeField]
    private bool coolingDown = false;
    [SerializeField]
    private Animator animator;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip slashSound;

    void SwordCooldown()
    {
        animator.SetBool("Attacking", false);
        coolingDown = false;
        swordHitbox.tag = "Untagged";
    }

    void SwordAttack()
    {
        if (aSource) aSource.PlayOneShot(slashSound);
        animator.SetBool("Attacking", true);
        coolingDown = true;
        swordHitbox.tag = "PlayerAttack";
        Invoke("SwordCooldown", .3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        // audio
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));

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
