using UnityEngine;

public class InputAnimationController : MonoBehaviour
{
    public Animator animator;
    public float inputCooldown = 0.2f; // Tiempo que se mantiene activo tras detectar movimiento
    private float inputTimer = 0f;  // Asigna el Animator desde el Inspector

    void Update()
    {
	
	// Detecta cualquier movimiento horizontal del mouse
        float mouseX = Mathf.Abs(Input.GetAxis("Mouse Y"));

        if (mouseX > 0.1f)
        {
            inputTimer = inputCooldown; // Reinicia el temporizador si hay movimiento
        }
        else
        {
            inputTimer -= Time.deltaTime; // Decrementa el tiempo si no hay movimiento
        }

	// Activa la animación si hay movimiento horizontal
        bool mouseInput = inputTimer >= 0.000000000000000000001f;

        // Detecta si se presiona el botón izquierdo del mouse
        //bool mouseInput = Input.GetMouseButton(0);

        // Detecta input del joystick (por ejemplo, eje horizontal y vertical)
        bool joystickInput = Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f ;

        // Combina ambos inputs
        bool inputActive = mouseInput || joystickInput;

        // Actualiza el parámetro del Animator
        animator.SetBool("isInputActive", inputActive);
    }
}

