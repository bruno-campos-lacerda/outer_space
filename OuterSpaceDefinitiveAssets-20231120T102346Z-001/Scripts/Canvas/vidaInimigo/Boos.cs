using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boos : MonoBehaviour {

    public int hp;
    public int maxHp;
    int força;
    bool podeApanhar;
    [SerializeField]
    Camera Camera;

    [SerializeField]
    private AudioSource hit1, hit2, hit3, highHit;

    void Start() {
        hp = maxHp;
        podeApanhar = true;
    }

    void Update() {
        if (hp <= 0) {
            if (Camera != null) {
                Camera.BACOmorreu = true;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 11 && podeApanhar) {//fraco
            força = 1;
            Dano(força);
            StartCoroutine(invencivel());
        }
        if (collision.gameObject.layer == 12 && podeApanhar) {//médio
            força = 2;
            Dano(força);
            StartCoroutine(invencivel());
        }
        if (collision.gameObject.layer == 13 && podeApanhar) {//forte
            força = 3;
            Dano(força);
            StartCoroutine(invencivel());
            hit1.Play();
        }
        if (collision.gameObject.layer == 14 && podeApanhar) {//severo
            força = 4;
            Dano(força);
            StartCoroutine(invencivel());
            hit2.Play();
        }
        if (collision.gameObject.layer == 15 && podeApanhar) {//colossau
            força = 5;
            Dano(força);
            StartCoroutine(invencivel());
            hit3.Play();
        }
        if (collision.gameObject.layer == 16 && podeApanhar) {//mortal
            força = maxHp;
            Dano(força);
            StartCoroutine(invencivel());
            hit3.Play();
        }
    }

    void Dano(int dano) {
        hp -= dano;
    }

    IEnumerator invencivel() {
        podeApanhar = false;
        yield return new WaitForSeconds(.1f);
        podeApanhar = true;
    }
}
