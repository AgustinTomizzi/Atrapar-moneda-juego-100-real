using UnityEngine;

public class FirstPersonController_DobleSalto_Correr_CaminarLento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 5f;
    public float velocidadCarrera = 10f;
    public float velocidadCaminarLento = 2f;

    [Header("Salto")]
    public float alturaSalto = 3f;
    public int cantidadSaltos = 2;

    [Header("Mouse")]
    public float sensibilidadMouse = 2f;
    public Transform camara;

    [Header("Gravedad")]
    public float gravedad = -9.81f;

    private CharacterController characterController;

    private float velocidadVertical = 0f;
    private int saltosRestantes;

    private float rotacionVertical = 0f;

    private void Start()
    {
        // Obtener el CharacterController
        characterController = GetComponent<CharacterController>();

        // Comprobar que existe la cámara
        if (camara == null)
        {
            Debug.LogError("No has asignado la cámara en el Inspector.");
        }

        // Inicializar los saltos
        saltosRestantes = cantidadSaltos;

        // Bloquear y ocultar el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // =========================================================
        // MOUSE
        // =========================================================

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        // Girar el jugador izquierda / derecha
        transform.Rotate(Vector3.up * mouseX);

        // Girar la cámara arriba / abajo
        rotacionVertical -= mouseY;

        // Limitar la cámara para que no dé una vuelta completa
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90f, 90f);

        if (camara != null)
        {
            camara.localRotation = Quaternion.Euler(
                rotacionVertical,
                0f,
                0f
            );
        }

        // =========================================================
        // MOVIMIENTO
        // =========================================================

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Determinar velocidad
        float velocidadActual;

        if (Input.GetKey(KeyCode.LeftControl) &&
            characterController.isGrounded)
        {
            // Caminar lento
            velocidadActual = velocidadCaminarLento;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            // Correr
            velocidadActual = velocidadCarrera;
        }
        else
        {
            // Caminar normal
            velocidadActual = velocidadMovimiento;
        }

        // Crear dirección de movimiento
        Vector3 movimiento =
            transform.right * movimientoHorizontal +
            transform.forward * movimientoVertical;

        // Evitar que la velocidad diagonal sea mayor
        movimiento = Vector3.ClampMagnitude(movimiento, 1f);

        // Aplicar velocidad
        movimiento *= velocidadActual;

        // =========================================================
        // GRAVEDAD
        // =========================================================

        if (characterController.isGrounded)
        {
            // Mantener al jugador pegado al suelo
            if (velocidadVertical < 0)
            {
                velocidadVertical = -2f;
            }

            // Restaurar los saltos
            saltosRestantes = cantidadSaltos;
        }
        else
        {
            // Aplicar gravedad
            velocidadVertical += gravedad * Time.deltaTime;
        }

        // =========================================================
        // SALTO / DOBLE SALTO
        // =========================================================

        if (Input.GetButtonDown("Jump") && saltosRestantes > 0)
        {
            velocidadVertical = Mathf.Sqrt(
                alturaSalto * -2f * gravedad
            );

            saltosRestantes--;
        }

        // Aplicar velocidad vertical
        movimiento.y = velocidadVertical;

        // Mover al jugador
        characterController.Move(
            movimiento * Time.deltaTime
        );
    }
}
