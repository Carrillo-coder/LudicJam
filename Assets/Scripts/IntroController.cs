using System.Collections;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public GameObject fantasyRawImage;

    public GameObject introCanvas;
    public CanvasGroup[] textos;

    private int indiceActual = 0;
    private bool enTransicion = false;

    void Start()
    {
        introCanvas.SetActive(true);
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].gameObject.SetActive(i == 0);
            textos[i].alpha = (i == 0) ? 1 : 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !enTransicion)
        {
            if (indiceActual < textos.Length - 1)
            {
                StartCoroutine(CambiarTexto(textos[indiceActual], textos[indiceActual + 1]));
                indiceActual++;
            }
            else
            {
                StartCoroutine(FadeOut(textos[indiceActual], () => {
                introCanvas.SetActive(false); // Fin de la intro
                if (fantasyRawImage != null)
                    fantasyRawImage.SetActive(true); // Activa la vista de fantasía
    }));
}

        }
    }

    IEnumerator CambiarTexto(CanvasGroup actual, CanvasGroup siguiente)
    {
        enTransicion = true;
        yield return FadeOut(actual);
        yield return new WaitForSeconds(0.2f);
        yield return FadeIn(siguiente);
        enTransicion = false;
    }

    IEnumerator FadeIn(CanvasGroup cg, float duracion = 1f)
    {
        cg.alpha = 0;
        cg.gameObject.SetActive(true);
        float t = 0f;
        while (t < duracion)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(0, 1, t / duracion);
            yield return null;
        }
        cg.alpha = 1;
    }

    IEnumerator FadeOut(CanvasGroup cg, System.Action onComplete = null, float duracion = 1f)
    {
        float t = 0f;
        while (t < duracion)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(1, 0, t / duracion);
            yield return null;
        }
        cg.alpha = 0;
        cg.gameObject.SetActive(false);
        onComplete?.Invoke();
    }
}
