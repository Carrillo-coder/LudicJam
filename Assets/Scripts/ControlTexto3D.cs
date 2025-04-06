using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ControlTexto3D : MonoBehaviour
{
    [Header("Textos en orden")]
    public List<GameObject> textos; // Asigna en el Inspector los textos en orden

    [Header("Configuración")]
    public float duracionFade = 0.3f;

    private int indiceActual = 0;
    private bool enTransicion = false;
    private bool movimientoValido = false;

    void Start()
    {
        // Solo activa el primero
        for (int i = 0; i < textos.Count; i++)
            textos[i].SetActive(i == 0);
    }

    void Update()
    {
        float movimientoY = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(movimientoY) > 0f)
            movimientoValido = true;

        if (Input.GetKeyDown(KeyCode.C) && movimientoValido && !enTransicion)
        {
            movimientoValido = false;

            if (indiceActual < textos.Count - 1)
            {
                StartCoroutine(CambiarTexto(indiceActual, indiceActual + 1));
                indiceActual++;
            }
            else
            {
                StartCoroutine(FadeOutTexto(textos[indiceActual]));
                Debug.Log("Fin de los textos. Aquí podrías avisar a la animación.");
            }
        }
    }

    IEnumerator CambiarTexto(int actual, int siguiente)
    {
        enTransicion = true;

        yield return StartCoroutine(FadeOutTexto(textos[actual]));
        textos[siguiente].SetActive(true);

        enTransicion = false;
    }

    IEnumerator FadeOutTexto(GameObject textoObj)
    {
        TextMeshPro tmp = textoObj.GetComponent<TextMeshPro>();
        float t = 0f;
        Color colorInicial = tmp.color;

        while (t < duracionFade)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / duracionFade);
            tmp.color = new Color(colorInicial.r, colorInicial.g, colorInicial.b, alpha);
            yield return null;
        }

        textoObj.SetActive(false);
        // Restablece el alpha para el futuro (por si lo necesitas reiniciar)
        tmp.color = colorInicial;
    }
}
