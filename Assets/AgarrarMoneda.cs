
using UnityEngine;

public class AgarrarMoneda : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Inventario inventario = other.GetComponent<Inventario>();

        if (inventario != null)
        {
            inventario.RecogerMoneda();
            gameObject.SetActive(false);
        }
    }
}
