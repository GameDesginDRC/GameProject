using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShieldText : MonoBehaviour
{
    [SerializeField]
    Text the_text;
    [SerializeField]
    GenBar genbar;
    
    // Start is called before the first frame update
    void Start()
    {
        genbar = GameObject.FindObjectOfType<GenBar>();
        the_text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int hpval = Player.hp;
        int shieldval = (int)genbar.hpvalue.value;
        the_text.text = hpval.ToString() + "\n" + shieldval.ToString();
    }
}
