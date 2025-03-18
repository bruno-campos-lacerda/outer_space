using System.Collections;
using UnityEngine;

public class Vida : MonoBehaviour {

    int vidaMaxima = 20;
    public int vida;
    int for�a;
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
            for�a = 1;
            Dano(for�a);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
        if (collision.gameObject.layer == 12 && podeMachucar) {
            for�a = 2;
            Dano(for�a);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
        if (collision.gameObject.layer == 13 && podeMachucar) {
            for�a = 3;
            Dano(for�a);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
        if (collision.gameObject.layer == 14 && podeMachucar) {
            for�a = 4;
            Dano(for�a);
            StartCoroutine(invencibilidade());
            playerHit1.Play();
        }
        if(collision.gameObject.layer == 15 && podeMachucar) {
            for�a = 5;
            Dano(for�a);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
        if (collision.gameObject.layer == 16 && podeMachucar) {
            for�a = vidaMaxima;
            Dano(for�a);
            StartCoroutine(invencibilidade());
            dashHit.Play();
        }
    }

    void Dano(int dano) {
        vida -= for�a;
        barraDeVida.BarraVida(vida, vidaMaxima);
    }

    IEnumerator invencibilidade() {
        podeMachucar = false;
        yield return new WaitForSeconds(1);
        podeMachucar = true;
    }
}
