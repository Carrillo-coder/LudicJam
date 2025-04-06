using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEventHandler : MonoBehaviour
{
    // Esta función se llamará desde el Animation Event
    public void OnAnimationEnd()
    {
        Debug.Log("La animación ha finalizado. Iniciando transición de escena...");
        // Aquí puedes llamar a tu método de transición
        // Por ejemplo, si usas un TransitionController global:
        TransitionController.nextScene = "Etapa1_2";
        SceneManager.LoadScene("TransitionScene");
        
        // O bien, llamar directamente a SceneManager.LoadScene("NombreDeLaEscenaDestino")
        // según la lógica de tu proyecto.
    }
}
