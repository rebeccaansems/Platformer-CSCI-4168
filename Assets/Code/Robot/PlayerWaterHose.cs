using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterHose : MonoBehaviour
{
    public PlayerCharacter player;
    public Camera playerCamera;
    public ParticleFollowPath[] allParticlePaths;
    public GameObject waterhoseElement;

    public bool isPlaying, canMove;
    private IEnumerator fireToBePutOut;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isPlaying)
        {
            transform.DetachChildren();
            isPlaying = false;
        }
    }

    IEnumerator StartWaterhose(Vector3 endLocation)
    {
        while ((player.GetPowerpackLevel() > 0 || player.GetNumberPowerpacks() > 0) && isPlaying)
        {
            GameObject waterElement = Instantiate(waterhoseElement, this.transform, false);
            waterElement.GetComponent<ParticleFollowPath>().StartPathFollow(endLocation);
            yield return new WaitForEndOfFrame();
        }
    }

    public void StartPuttingoutFire(FireController fire)
    {
        if (player.GetPowerpackLevel() > 0 && fire != null)
        {
            canMove = false;
            isPlaying = true;
            fireToBePutOut = PutOutFire(fire);
            StartCoroutine(fireToBePutOut);
            StartCoroutine(StartWaterhose(fire.gameObject.transform.position + (Vector3.up / 2)));
        }
    }

    IEnumerator PutOutFire(FireController fire)
    {
        while (isPlaying)
        {
            if (player.GetPowerpackLevel() > 0 || player.GetNumberPowerpacks() > 0)
            {
                if (fire != null)
                {
                    fire.waterRequiredToExtinguish -= 0.05f;
                }
                player.UsePowerpack();
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
