using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireStarter : MonoBehaviour
{

    public int numFires;
    public GameObject fire;
    public List<GameObject> fireBushes;

    private List<GameObject> allBushes;

    void Awake()
    {
        //get all bushes
        allBushes = GameObject.FindGameObjectsWithTag("Bush").ToList();

        //sort bushes randomly
        System.Random rnd = new System.Random();
        allBushes = allBushes.OrderBy(item => rnd.Next()).ToList();

        //set random number of random bushes on fire
        for (int i = 0; i < numFires; i++)
        {
            Instantiate(fire, allBushes[i].transform);
            allBushes[i].AddComponent<GeneralFireObject>();
            allBushes[i].transform.parent = this.transform;

            //add bush to list of all fire bushes
            fireBushes.Add(allBushes[i]);

            //set this as the fire starter
            allBushes[i].GetComponentInChildren<FireController>().fireStarter = this;
        }
    }
}
