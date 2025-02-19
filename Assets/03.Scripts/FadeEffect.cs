using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private float fadeTime;

    [SerializeField] private AnimationCurve fadeCurve;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartFade(float startAlpha, float endAlpha)
    {
        StartCoroutine(Fade(startAlpha, endAlpha));
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;

            yield return null;
        }
        transform.root.gameObject.SetActive(false);
    }
}
