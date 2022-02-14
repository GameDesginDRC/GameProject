using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAbilities : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GoldBoost;
    public GameObject HealthBoost;
    public GameObject DamageBoost;
    public GameObject DashCoolDownBoost;
    
    // public static List<GameObject> allAbilities = new List<GameObject>();
    // public static List<Vector3> allPositions = new List<Vector3>();

    void Start()
    {
        Vector3 displ1 = new Vector3(-8f, .5f, 0);
        Vector3 displ2 = new Vector3(0f, .5f, 0);
        Vector3 displ3 = new Vector3(8f, .5f, 0);
        List<int> listofabil = new List<int> {1,2,3,4};
        
        int xindex = Random.Range(0, listofabil.Count);
        int xcount = listofabil[xindex];
        listofabil.Remove(xcount);

        int yindex = Random.Range(0, listofabil.Count);
        int ycount = listofabil[yindex];
        listofabil.Remove(ycount);

        int zindex = Random.Range(0, listofabil.Count);
        int zcount = listofabil[zindex];

        if (xcount == 1)
        {
            var go = Instantiate(GoldBoost, gameObject.transform.position + displ1, Quaternion.identity);
        }
        else if (xcount == 2)
        {
            var go = Instantiate(HealthBoost, gameObject.transform.position + displ1, Quaternion.identity);
        }
        else if (xcount == 3)
        {
            var go = Instantiate(DamageBoost, gameObject.transform.position + displ1, Quaternion.identity);
        }
        else if (xcount == 4)
        {
            var go = Instantiate(DashCoolDownBoost, gameObject.transform.position +displ1, Quaternion.identity);
        }

        if (ycount == 1)
        {
            var go = Instantiate(GoldBoost, gameObject.transform.position + displ2, Quaternion.identity);
        }
        else if (ycount == 2)
        {
            var go = Instantiate(HealthBoost, gameObject.transform.position + displ2, Quaternion.identity);
        }
        else if (ycount == 3)
        {
            var go = Instantiate(DamageBoost, gameObject.transform.position + displ2, Quaternion.identity);
        }
        else if (ycount == 4)
        {
            var go = Instantiate(DashCoolDownBoost, gameObject.transform.position +displ2, Quaternion.identity);
        }

        if (zcount == 1)
        {
            var go = Instantiate(GoldBoost, gameObject.transform.position + displ3, Quaternion.identity);
        }
        else if (zcount == 2)
        {
            var go = Instantiate(HealthBoost, gameObject.transform.position + displ3, Quaternion.identity);
        }
        else if (zcount == 3)
        {
            var go = Instantiate(DamageBoost, gameObject.transform.position + displ3, Quaternion.identity);
        }
        else if (zcount == 4)
        {
            var go = Instantiate(DashCoolDownBoost, gameObject.transform.position +displ3, Quaternion.identity);
        }

    }


//     void Start()
//     {
//         allAbilities.Add(GoldBoost);
//         allAbilities.Add(HealthBoost);
//         allAbilities.Add(DamageBoost);
//         allAbilities.Add(DashCoolDownBoost);
//         allPositions.Add(displ1);
//         allPositions.Add(displ2);
//         allPositions.Add(displ3);
//         List<GameObject> Leftover = GetRandomItemsFromList<GameObject> (allAbilities, 3);

//     }

//     public List<GameObject> GetRandomItemsFromList<GameObject> (List<GameObject> abilities, int number)
//     {

//         List<GameObject> tmpList = new List<GameObject>(abilities);
//         List<GameObject> newList = new List<GameObject>();
    
//         int counter = 0;
//         while (counter < number && tmpList.Count > 0)
//         {
//             int index = Random.Range(0, tmpList.Count);
//             newList.Add(tmpList[index]);
//             Instantiate(tmpList[index], gameObject.transform.position + allPositions[counter], Quaternion.identity);
//             tmpList.RemoveAt(index);
//             counter++;
//         }
    
//         return newList;
//     }
}
