using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollowPath : MonoBehaviour
{
    public void StartPathFollow(Vector3 endLocation)
    {
        this.GetComponent<ParticleSystem>().Play();
        StartCoroutine(FollowPath(endLocation));
    }

    private IEnumerator FollowPath(Vector3 endLocation)
    {
        while (Vector3.Distance(this.transform.position, endLocation) > 0.1f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, endLocation, 0.1f);
            yield return new WaitForEndOfFrame();
        }
        Destroy(this.gameObject);
    }
}
