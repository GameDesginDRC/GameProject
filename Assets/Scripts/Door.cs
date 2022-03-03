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
    public int x;
    public int y;
    void Start()
    {
        newvec = new Vector3(x, y, 0);
        first = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Z) && collision.gameObject.GetComponent<Player>() != null)
        {
            SceneManager.LoadScene(next);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (first == 0 && collision.CompareTag("Player"))
        {
            first = 1;
            obj = Instantiate(FloatingTextPrefab, transform.position + newvec, Quaternion.identity, transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (first == 1 && collision.CompareTag("Player"))
        {
            first = 0;
            Destroy(obj);
        }
    }
}
