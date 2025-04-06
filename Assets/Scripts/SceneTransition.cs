using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    [Header("Configuración del Fade")]
    public Image fadeImage;      // La imagen que cubre la pantalla.
    public float fadeSpeed = 0.1f; // Velocidad de transición.

    private void Start()
    {
        // Al iniciar, realizamos un fade in para mostrar la escena.
        StartCoroutine(FadeIn());
    }

    // Método público para iniciar la transición a otra escena.
    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    // Coroutine para hacer fade out, cargar la escena y luego fade in.
    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        // Fade out: aumentar alfa de 0 a 1.
        while (fadeImage.color.a < 1f)
        {
            Color tempColor = fadeImage.color;
            tempColor.a += Time.deltaTime * fadeSpeed;
            fadeImage.color = tempColor;
            yield return null;
        }

        // Cargar la nueva escena.
        SceneManager.LoadScene(sceneName);

        // Esperamos un frame para asegurarnos de que la escena se haya cargado.
        yield return null;

        // Realizamos fade in en la nueva escena.
        yield return StartCoroutine(FadeIn());
    }

    // Coroutine para hacer fade in (disminuir alfa de 1 a 0).
    private IEnumerator FadeIn()
    {
        while (fadeImage.color.a > 0f)
        {
            Color tempColor = fadeImage.color;
            tempColor.a -= Time.deltaTime * fadeSpeed;
            fadeImage.color = tempColor;
            yield return null;
        }
    }
}

