using UnityEngine;
using System.Collections;

public class FadeOutIntro : MonoBehaviour
{
    public CanvasGroup canvasIntro;
    public GameObject fantasyRawImage;
    public float duracionFade = 2f;

    public void IniciarFade() // Este lo llamas cuando el último texto termina
    {
        StartCoroutine(FadeDespuésDeIntro());
    }

    IEnumerator FadeDespuésDeIntro()
    {
        float t = 0;
        while (t < duracionFade)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / duracionFade);
            canvasIntro.alpha = alpha;
            yield return null;
        }

        canvasIntro.gameObject.SetActive(false);

        if (fantasyRawImage != null)
            fantasyRawImage.SetActive(true);
    }
}
