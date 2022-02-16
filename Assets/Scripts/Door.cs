using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    private GameObject obj;
    [SerializeField] string next;
    private Vector3 newvec;
    private int first;
    // Start is called before the first frame update
    void Start()
    {
        newvec = new Vector3(-1.0f, 3.0f, 0);
        first = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SceneManager.LoadScene(next);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (first == 0)
        {
            first = 1;
            obj = Instantiate(FloatingTextPrefab, transform.position + newvec, Quaternion.identity, transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (first == 1)
        {
            first = 0;
            Destroy(obj);
        }
    }
}
