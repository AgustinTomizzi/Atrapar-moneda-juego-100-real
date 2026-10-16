using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioDeEscenaConTimeout : MonoBehaviour
{
    private float tiempoTranscurrido = 0f;
    public float tiempoLimite = 10f; // Tiempo límite en segundos

    public Text temporizadorText; // Referencia al objeto Text en la interfaz de usuario

    void Start()
    {
        // Asegurarse de que la referencia al Text esté configurada en el inspector
        if (temporizadorText == null)
        {
            Debug.LogError("Error: Asigna el objeto Text en el inspector.");
        }
    }

    void Update()
    {
        // Incrementar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Actualizar el texto del temporizador en la interfaz de usuario
        ActualizarTemporizadorText();

        // Verificar si el tiempo límite ha sido alcanzado
        if (tiempoTranscurrido >= tiempoLimite)
        {
            // Cambiar a la escena deseada
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
        // Acá indicás el nombre de la escena a la que deseas cambiar
        string nombreDeLaEscena = "SampleScene";
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    void ActualizarTemporizadorText()
    {
        // Formatear el tiempo restante y actualizar el texto del temporizador
        float tiempoRestante = Mathf.Max(0f, tiempoLimite - tiempoTranscurrido);
        temporizadorText.text = "Tiempo: " + tiempoRestante.ToString("F1"); // Muestra un decimal
    }
}