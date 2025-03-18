using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour {

    [SerializeField] private Image vidaBarra;

    public void BarraVida(int vida, int vidaMaxima) {
        vidaBarra.fillAmount = (float)vida / vidaMaxima;
    }
}
