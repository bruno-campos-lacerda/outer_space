using System.Collections;
using UnityEngine;

public class vida : MonoBehaviour {

    public int hp;
    public int maxHp;
    int for�a;
    bool podeApanhar;
    [SerializeField]
    private Camera Camera;

    [SerializeField]
    private AudioSource hit1, hit2, hit3, highHit;

    void Start() {
        hp = maxHp;
        podeApanhar = true;
    }

    void Update() {
        if (hp <= 0) {
            if(Camera != null) {
                Camera.BACOmorreu = true;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 11 && podeApanhar) {//fraco
            for�a = 1;
            Dano(for�a);
            StartCoroutine(invencivel());
        }
        if (collision.gameObject.layer == 12 && podeApanhar) {//m�dio
            for�a = 2;
            Dano(for�a);
            StartCoroutine(invencivel());
        }
        if (collision.gameObject.layer == 13 && podeApanhar) {//forte
            for�a = 3;
            Dano(for�a);
            StartCoroutine(invencivel());
            hit1.Play();
        }
        if (collision.gameObject.layer == 14 && podeApanhar) {//severo
            for�a = 4;
            Dano(for�a);
            StartCoroutine(invencivel());
            hit2.Play();
        }
        if (collision.gameObject.layer == 15 && podeApanhar) {//colossau
            for�a = 5;
            Dano(for�a);
            StartCoroutine(invencivel());
            hit3.Play();
        }
        if (collision.gameObject.layer == 16 && podeApanhar) {//mortal
            for�a = maxHp;
            Dano(for�a);
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
