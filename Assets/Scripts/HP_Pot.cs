using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP_Pot : MonoBehaviour
{
    public GameObject empty1;
    public static bool used;
    public int usednum = 0;
    private Scene currentScene;
    string sceneName;
    public static int HPpot_count = 0;
    public static int hpIncr = 0;
    private float waitTime = 0;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip useHPPotSound;
    // Start is called before the first frame update
    void Start()
    {
        // audio
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
        AudioSource HPPotSound = GameObject.Find("HPPotSound").GetComponent<AudioSource>();
        if (HPPotSound) useHPPotSound = HPPotSound.clip;

        waitTime = .2f;
        hpIncr = 0;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        //Informant.bought_pot = true;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.A) && sceneName != "Shop 1" && waitTime <= 0)
        {
            waitTime = .2f;
            UseHPPot();
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void DecrConsume(int ind)
    {
        if (ind == 2)
        {
            ConsumeCountText.ChangeConsume(-1);
        }
        else if (ind == 3)
        {
            ConsumeText2.ChangeConsume2(-1);
        }
        else if (ind == 4)
        {
            ConsumeText3.ChangeConsume3(-1);
        }
    }

    void UseHPPot()
    {
        //Debug.Log(usednum);
        // look at this code, should be when == 1???
        if (HPpot_count == 1)
        {
            aSource.PlayOneShot(useHPPotSound);
            DecrConsume(usednum);
            HPpot_count--;
            Inventory.pos_objs[usednum] = empty1;
            Inventory._full[usednum] = false;
            int healAmt = (int)(HPBar.maxVal * .40);
            Player.hp += healAmt;
            if (Player.hp > HPBar.maxVal)
            {
                Player.hp = HPBar.maxVal;
            }
            hpIncr = 1;
            Destroy(gameObject);
        }
        else
        {
            aSource.PlayOneShot(useHPPotSound);
            DecrConsume(usednum);
            HPpot_count--;
            int healAmt = (int)(HPBar.maxVal * .40);
            Player.hp += healAmt;
            if (Player.hp > HPBar.maxVal)
            {
                Player.hp = HPBar.maxVal;
            }
            hpIncr = 1;
        }
    }
}
