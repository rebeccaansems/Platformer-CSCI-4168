using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    private float waterRequiredToExtinguish;
    private Color burntBush = new Color(0.52f, 0.52f, 0.52f);
    private Color normalBush = new Color(0, 0, 0);

    void Start()
    {
        this.GetComponentInParent<MeshRenderer>().materials[0].color = burntBush;
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
