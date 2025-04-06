using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        // Almacena el nombre de la escena destino
        TransitionController.nextScene = sceneName;
        // Carga la escena de transición
        SceneManager.LoadScene("TransitionScene");
    }
}

