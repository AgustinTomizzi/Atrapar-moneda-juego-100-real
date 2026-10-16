
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private int monedasRecogidas = 0;

    public int monedasNecesarias = 5;
    public Text textoMonedas;

    private void Start()
    {
        ActualizarTextoMonedas();
    }

    public void RecogerMoneda()
    {
        monedasRecogidas++;

        ActualizarTextoMonedas();

        if (monedasRecogidas >= monedasNecesarias)
        {
            CambiarEscena();
        }
    }

    private void ActualizarTextoMonedas()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "Monedas: "
                + monedasRecogidas + "/"
                + monedasNecesarias;
        }
    }

    private void CambiarEscena()
    {
        SceneManager.LoadScene("Plano");
    }
}
