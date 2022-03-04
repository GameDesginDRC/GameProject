using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopDoor : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    private GameObject obj;
    private Vector3 newvec;
    private int first;
    public static int doorcnt = 0;
    // Start is called before the first frame update
    public int x;
    public int y;
    void Start()
    {
        newvec = new Vector3(x, y, 0);
        first = 0;
        doorcnt += 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Z) && collision.gameObject.GetComponent<Player>() != null)
        {
            if (doorcnt == 1)
            {
                SceneManager.LoadScene("Transition2");
            } else if (doorcnt == 2)
            {
                SceneManager.LoadScene("Transition3");
            }
            else if (doorcnt == 3)
            {
                SceneManager.LoadScene("Transition4");
            }
            else if (doorcnt == 4)
            {
                SceneManager.LoadScene("Transition5");
            }
            else if (doorcnt == 5)
            {
                SceneManager.LoadScene("Transition6");
            }
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
