using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterHose : MonoBehaviour
{
    public PlayerCharacter player;
    public Camera playerCamera;
    public ParticleFollowPath[] allParticlePaths;

    private bool canBeStopped;
    private IEnumerator fireToBePutOut;

    private void Awake()
    {
        foreach (iTweenPath path in GetComponentsInChildren<iTweenPath>())
        {
            path.pathName = path.gameObject.name;
        }
    }

    private void Start()
    {
        player = GetComponent<PlayerCharacter>();
        allParticlePaths = GetComponentsInChildren<ParticleFollowPath>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && player.GetPowerpackLevel() > 0)
        {
            if (allParticlePaths[0].isPlaying == false)
            {
                StartCoroutine(PlayParticleSystem(2f));
            }
        }
        else if (allParticlePaths[0].isPlaying && canBeStopped)
        {
            StopCoroutine(fireToBePutOut);

            foreach (ParticleFollowPath particlePath in allParticlePaths)
            {
                particlePath.Stop(particlePath.transform.parent.gameObject.name);
            }
        }
    }

    public void SetFinalPoint(Vector3 point)
    {
        foreach (ParticleFollowPath particlePath in allParticlePaths)
        {
            Vector3 midPoint = (this.transform.position + point) / 2;
            midPoint.y += Vector3.Distance(this.transform.position, point) / 5;
            midPoint.z += Vector3.Distance(this.transform.position, point) / 10;

            particlePath.GetComponentInParent<iTweenPath>().nodes[0] = this.transform.position + Vector3.up;
            particlePath.GetComponentInParent<iTweenPath>().nodes[1] = midPoint;
            particlePath.GetComponentInParent<iTweenPath>().nodes[2] = point;
        }
    }

    IEnumerator PlayParticleSystem(float time)
    {
        canBeStopped = false;
        foreach (ParticleFollowPath particlePath in allParticlePaths)
        {
            particlePath.transform.position = this.transform.position + Vector3.up;
            particlePath.Play(particlePath.transform.parent.gameObject.name, time);
            yield return new WaitForSeconds(time / allParticlePaths.Length);
        }
        canBeStopped = true;
    }

    public void StartPuttingoutFire(FireController fire)
    {
        if (player.GetPowerpackLevel() > 0)
        {
            fireToBePutOut = PutOutFire(fire);
            StartCoroutine(fireToBePutOut);
        }
    }

    IEnumerator PutOutFire(FireController fire)
    {
        while (true)
        {
            if (player.GetPowerpackLevel() > 0 || player.GetNumberPowerpacks() > 0)
            {
                if (fire != null)
                {
                    fire.waterRequiredToExtinguish -= 0.05f;
                }
                player.UsePowerpack();
                player.UsePowerpack();
                player.UsePowerpack();
                player.UsePowerpack();
                player.UsePowerpack();
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
