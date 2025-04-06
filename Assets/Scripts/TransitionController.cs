using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TransitionController : MonoBehaviour
{
    [Header("Configuración del Fade")]
    public Image fadeImage;       // Asigna la Image del Canvas
    public float fadeSpeed = 0.5f;    // Velocidad de la transición

     public string SigEscena = "";

    // Variable estática para almacenar el nombre de la escena a cargar
    public static string nextScene = "Etapa1_2";

    void Start()
    {
        // Comienza la secuencia de transición
        StartCoroutine(TransitionSequence());
    }

    IEnumerator TransitionSequence()
    {
        // 1. Fade Out: de transparente (0) a opaco (1)
        while (fadeImage.color.a < 1f)
        {
            Color tempColor = fadeImage.color;
            tempColor.a += Time.deltaTime * fadeSpeed;
            fadeImage.color = tempColor;
            yield return null;
        }

        // 2. Cargar la siguiente escena de forma asíncrona
        if (!string.IsNullOrEmpty(SigEscena))
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SigEscena);
            // Espera a que la escena se cargue
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        else
        {
            Debug.LogWarning("No se especificó una escena a cargar en TransitionController.");
        }

        // 3. Fade In: de opaco (1) a transparente (0)
        while (fadeImage.color.a > 0f)
        {
            Color tempColor = fadeImage.color;
            tempColor.a -= Time.deltaTime * fadeSpeed;
            fadeImage.color = tempColor;
            yield return null;
        }
    }
}
