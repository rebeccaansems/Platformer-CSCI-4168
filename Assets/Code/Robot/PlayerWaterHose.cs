using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterHose : MonoBehaviour
{
    public Camera playerCamera;
    public ParticleFollowPath[] allParticlePaths;

    private bool canBeStopped;

    private void Awake()
    {
        foreach (iTweenPath path in GetComponentsInChildren<iTweenPath>())
        {
            path.pathName = path.gameObject.name;
        }
    }

    private void Start()
    {
        allParticlePaths = GetComponentsInChildren<ParticleFollowPath>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (allParticlePaths[0].isPlaying == false)
            {
                StartCoroutine(PlayParticleSystem(2f));
            }
        }
        else if (allParticlePaths[0].isPlaying && canBeStopped)
        {
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
            particlePath.transform.position = this.transform.position;
            particlePath.Play(particlePath.transform.parent.gameObject.name, time);
            yield return new WaitForSeconds(time / allParticlePaths.Length);
        }
        canBeStopped = true;
    }
}
