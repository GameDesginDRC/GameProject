using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegularSword : MonoBehaviour
{
    [SerializeField]
    private GameObject swordHitbox;
    [SerializeField]
    private Animator animator;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip slashSound;
    private bool getItem = false;

    void Start()
    {
        // audio
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (!getItem &&Input.GetKeyDown(KeyCode.Z) && Player.hasSword && !animator.GetCurrentAnimatorStateInfo(0).IsName("MainAttack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("MainTeleport") && sceneName != "Shop 1"&& sceneName != "Abilities")
        {
            if (aSource) aSource.PlayOneShot(slashSound);
            // animator.SetBool("Attack", true);
            animator.SetTrigger("Attack");
        }
    }
    public void SwordAttack()
    {
        swordHitbox.tag = "PlayerAttack";
    }

    public void ResetAttack()
    {
        swordHitbox.tag = "Untagged";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            getItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        getItem = false;
    }
    // Start is called before the first frame update
    
}
