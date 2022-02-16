using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInvUIText : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    public GameObject FloatingTextPrefab1;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
          Vector3 newvec = new Vector3(7f, 3f, 0);
          Vector3 newvec1 = new Vector3(0, 3f, 0);
          var obj = Instantiate(FloatingTextPrefab, transform.position + newvec, Quaternion.identity, transform);
          var obj1 = Instantiate(FloatingTextPrefab1, transform.position + newvec1, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        // -223.5f and -106.5f
        transform.localPosition = new Vector3(x, y, 0);
    }
}
