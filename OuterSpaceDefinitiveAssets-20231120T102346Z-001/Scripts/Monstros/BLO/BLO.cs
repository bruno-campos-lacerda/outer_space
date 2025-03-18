using System.Collections;
using UnityEngine;

public class BLO : MonoBehaviour {

    [SerializeField]
    GameObject jogador;

    Rigidbody2D rig;
    Animator anim;

    float distancia;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(IntervaloAtaque());
        jogador = GameObject.Find("Protagonista");
    }

    void Update() {
        distancia = Vector2.Distance(transform.position, jogador.transform.position);
        Vector3 direçao = (jogador.transform.position - transform.position).normalized ;
        if (distancia <= 12) {
            rig.velocity = direçao * 5;
        }
    }
    IEnumerator IntervaloAtaque() {
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("Ataque");
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Voou");
        StartCoroutine(IntervaloAtaque());
    }
}
