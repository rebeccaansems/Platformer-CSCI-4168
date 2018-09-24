using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PlayerController : MonoBehaviour
{
    public FireStarter fireStart;

    private PostProcessingBehaviour postProcessing;

    private void Start()
    {
        //set vignette to hidden
        var postProcessingSettings = this.GetComponentsInChildren<PostProcessingBehaviour>()[0].profile.vignette.settings;
        postProcessingSettings.intensity = 0;
        this.GetComponentsInChildren<PostProcessingBehaviour>()[0].profile.vignette.settings = postProcessingSettings;
    }

    private void OnCollisionEnter(Collision collide)
    {
        //if player collides with a powerpack, gain the pack and destroy it's game object
        if (collide.gameObject.tag == "Powerpack")
        {
            this.GetComponent<PlayerCharacter>().PowerpackGained();
            Destroy(collide.gameObject);
        }
    }

    private void Update()
    {
        FireDistanceChanges();
    }

    private void FireDistanceChanges()
    {
        //get distance to closest fire, default = 6
        float minDistance = Mathf.Min(6, fireStart.fireBushes.Where(x => x.gameObject != null).Min(x => Vector3.Distance(x.transform.position, this.transform.position)));

        //update vigenette according to how close the player is to fire
        var postProcessingSettings = this.GetComponentsInChildren<PostProcessingBehaviour>()[0].profile.vignette.settings;
        postProcessingSettings.intensity = 1 - (minDistance / 6);
        this.GetComponentsInChildren<PostProcessingBehaviour>()[0].profile.vignette.settings = postProcessingSettings;

        //kill player if too close to fire
        if (minDistance < 4)
        {
            this.GetComponent<PlayerCharacter>().KillPlayer();
        }
    }
}
