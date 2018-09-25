using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadableUI {
    
    //fade screen in to total black (end: alpha = 1)
    public IEnumerator FadeIn(CanvasGroup canvas)
    {
        while (canvas.alpha != 1)
        {
            canvas.alpha += 0.03f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    //fade screen out from total black (end: alpha = 0)
    public IEnumerator FadeOut(CanvasGroup canvas)
    {
        while (canvas.alpha != 0)
        {
            canvas.alpha -= 0.03f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
