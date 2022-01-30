using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    Image image = null;
    Coroutine currentFlashRoutine = null;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForFlash, float maxAlpha) {
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);
        if(currentFlashRoutine != null) {
            StopCoroutine(currentFlashRoutine);
        }
        currentFlashRoutine = StartCoroutine(Flash(secondsForFlash, maxAlpha));
    }

    IEnumerator Flash(float secondsForFlash, float maxAlpha) {
        float flashInDuration = (secondsForFlash / 4) * 3;
        for (float t = 0; t <= flashInDuration; t += Time.deltaTime) {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t/flashInDuration);
            image.color = colorThisFrame;
            //wait until next frame
            yield return null;
        }

        float flashOutDuration = (secondsForFlash / 4);
        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime) {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t/flashOutDuration);
            image.color = colorThisFrame;
            yield return null;
        }
        Color clearFlash = image.color;
        clearFlash.a = 0;
        image.color = clearFlash;
    }
}
