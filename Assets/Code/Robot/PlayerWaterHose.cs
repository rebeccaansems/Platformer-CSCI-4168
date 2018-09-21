using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterHose : MonoBehaviour
{
    ParticleFollowPath[] allParticlePaths;

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
        if (Input.GetMouseButtonDown(0) && allParticlePaths[0].isPlaying == false)
        {
            StartCoroutine(PlayParticleSystem(2f));
        }
    }

    IEnumerator PlayParticleSystem(float time)
    {
        foreach (ParticleFollowPath particlePath in allParticlePaths)
        {
            particlePath.Play(particlePath.transform.parent.gameObject.name, time);
            yield return new WaitForSeconds(time / allParticlePaths.Length);
        }
    }
}
