using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float waterRequiredToExtinguish;
    private Color burntBush = new Color(0.42f, 0.42f, 0.42f);
    private Color normalBush = new Color(1, 1, 1);

    void Start()
    {
        this.GetComponentInParent<MeshRenderer>().materials[0].color = burntBush;
        waterRequiredToExtinguish = Random.Range(0.5f, 1.5f);
    }

    private void Update()
    {
        //once fire is extinguished change bush back to normal color and destroy this and fire/smoke children
        if (waterRequiredToExtinguish <= 0)
        {
            this.GetComponentInParent<MeshRenderer>().materials[0].color = normalBush;
            Destroy(this.gameObject);
        }
    }
}
