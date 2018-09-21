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
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "easetype", iTween.EaseType.easeOutSine, "time", time, "looptype", iTween.LoopType.loop));
    }

    public void Stop(string pathName)
    {
        iTween.Stop();
        iTween.MoveFrom(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", 0));
        this.GetComponent<ParticleSystem>().Stop();
        isPlaying = false;
    }
}
