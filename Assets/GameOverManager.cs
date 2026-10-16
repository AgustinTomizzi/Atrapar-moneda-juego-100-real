
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CambiarEscena());
    }

    private IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("SampleScene");
    }
}
