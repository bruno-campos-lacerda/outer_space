using System.Collections;
using UnityEngine;

public class Vida : MonoBehaviour {

    int vidaMaxima = 20;
    public int vida;
    int força;
    bool podeMachucar;

    [SerializeField]private BarraDeVida barraDeVida;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject protagonista;

    [SerializeField]
    private AudioSource dashHit, playerHit1, playerHit2, playerHit3;

    void Awake() {
        vida = vidaMaxima;
        podeMachucar = true;
    }

    private void Start() {
        barraDeVida.BarraVida(vida, vidaMaxima);
    }

    void Update() {
        if (vida <= 0) {
            gameOver.SetActive(true);
            protagonista.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 11 && podeMachucar) {
            força = 1;
            Dano(força);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
        if (collision.gameObject.layer == 12 && podeMachucar) {
            força = 2;
            Dano(força);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
        if (collision.gameObject.layer == 13 && podeMachucar) {
            força = 3;
            Dano(força);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
        if (collision.gameObject.layer == 14 && podeMachucar) {
            força = 4;
            Dano(força);
            StartCoroutine(invencibilidade());
            playerHit1.Play();
        }
        if(collision.gameObject.layer == 15 && podeMachucar) {
            força = 5;
            Dano(força);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
        if (collision.gameObject.layer == 16 && podeMachucar) {
            força = vidaMaxima;
            Dano(força);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
    }

    void Dano(int dano) {
        vida -= força;
        barraDeVida.BarraVida(vida, vidaMaxima);
    }

    IEnumerator invencibilidade() {
        podeMachucar = false;
        yield return new WaitForSeconds(1);
        podeMachucar = true;
    }
}
