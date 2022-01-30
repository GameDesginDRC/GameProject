using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlTracker : MonoBehaviour
{
    [SerializeField] string _losename;
    [SerializeField] string _nextlevelname;
    // public static does not show in inspector
    // we need onenable to check to see if all the monsters are alive or dead, which will be coded later
    // void OnEnable()
    // {
    //     _monsters = FindObjectsOfType<Monster>();
    // }
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Progressor.next)
        {
            SceneManager.LoadScene(_nextlevelname);
        }
        if (Player.hp < 1)
        {
            // get component gets component of the entire object of the inspector
            SceneManager.LoadScene(_losename);
        }
    }
}
