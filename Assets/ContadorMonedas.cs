
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    private int coinCount = 0;

    public int coinsNeeded = 5;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        ActualizarTexto();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            ActualizarTexto();

            Destroy(other.gameObject);
        }
    }

    private void ActualizarTexto()
    {
        if (coinText != null)
        {
            coinText.text = "Monedas: "
                + coinCount + "/" + coinsNeeded;
        }
    }
}
