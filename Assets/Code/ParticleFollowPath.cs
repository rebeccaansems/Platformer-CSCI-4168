using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollowPath : MonoBehaviour
{
    public bool isPlaying;

    private IEnumerator particleCorountine;

    private void Start()
    {
        this.GetComponent<ParticleSystem>().Stop();
    }

    public void Play(string pathName, float time)
    {
        this.GetComponent<ParticleSystem>().Play();
        isPlaying = true;
        particleCorountine = PlayParticleSystem(pathName, time);
        StartCoroutine(particleCorountine);
    }

    public void PlayOnce(string pathName, float time)
    {
        this.GetComponent<ParticleSystem>().Play();
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "easetype", iTween.EaseType.easeOutQuint, "time", time));
        this.GetComponent<ParticleSystem>().Stop();
    }

    public void Stop()
    {
        //this.GetComponent<ParticleSystem>().Stop();
        //isPlaying = false;
    }

    IEnumerator PlayParticleSystem(string pathName, float time)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "easetype", iTween.EaseType.easeOutSine, "time", time, "looptype", iTween.LoopType.loop));
        yield return new WaitForSeconds(0.1f);
    }
}
