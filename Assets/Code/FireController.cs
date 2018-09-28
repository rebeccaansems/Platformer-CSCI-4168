using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float waterRequiredToExtinguish;
    public FireStarter fireStarter;

    private Color burntBush = new Color(0.42f, 0.42f, 0.42f);
    private Color normalBush = new Color(1, 1, 1);

    private float waterRequiredToExtinguishStart;
    private float fireEmissionsStart;
    private ParticleSystem fireParticles, smokeParticles;
    private bool hasBeenExtinguished = false;

    void Start()
    {
        this.GetComponentInParent<MeshRenderer>().materials[0].color = burntBush;
        waterRequiredToExtinguish = Random.Range(0.5f, 1.5f);
        waterRequiredToExtinguishStart = waterRequiredToExtinguish;

        fireParticles = GetComponentsInChildren<ParticleSystem>()[0];
        smokeParticles = GetComponentsInChildren<ParticleSystem>()[1];

        fireEmissionsStart = fireParticles.emission.rateOverTime.constant;
        smokeEmissionsStart = smokeParticles.emission.rateOverTime.constant;
    }

    private void Update()
    {
        if (hasBeenExtinguished == false)
        {
            //decrease fire as waterRequiredToExtinguish gets smaller
            var emission = fireParticles.emission;
            emission.rateOverTime = fireEmissionsStart * (waterRequiredToExtinguish / waterRequiredToExtinguishStart);

            //once fire is extinguished change bush back to normal color and destroy this and fire/smoke children and remove
            //this from list of all fire bushes
            if (waterRequiredToExtinguish <= 0)
            {
                hasBeenExtinguished = true;

                this.GetComponentInParent<MeshRenderer>().materials[0].color = normalBush;
                fireStarter.fireBushes.Remove(this.transform.parent.gameObject);

                StartCoroutine(CleanUp());
            }
        }
    }

    private IEnumerator CleanUp()
    {
        //destroy the minimap icon
        Destroy(this.transform.GetComponentInChildren<SpriteRenderer>().gameObject);

        //stop particle systems
        fireParticles.Stop();
        smokeParticles.Stop();

        //wait for smoke to finish
        yield return new WaitForSeconds(smokeParticles.main.duration);

        //delete self
        Destroy(this.gameObject);
    }
}
