using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscenaAlTriggerear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("GameOver");
    }
}
