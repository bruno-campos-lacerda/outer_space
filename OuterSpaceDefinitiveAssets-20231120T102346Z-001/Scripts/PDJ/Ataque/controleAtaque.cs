using System.Collections;
using TMPro;
using UnityEngine;

public class controleAtaque : MonoBehaviour {
    [SerializeField]
    private bool podeAtaque, tomelhe;
    [SerializeField]
    float Timer;
    Animator anim;
    public controleMovimento controle;
    public int muni�ao;

    public TextMeshProUGUI count;

    [SerializeField]
    AudioSource tiro;

    void Start() {
        anim = GetComponent<Animator>();
        muni�ao = 2;
        podeAtaque = true;
        tomelhe = false;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.M) && podeAtaque && controle.estaNoChao()) {
            controle.velocidadeHorizontal = 0;
            controle.for�aPulo = 0;
            podeAtaque = false;
            tomelhe = true;
            Timer = .92f;
            anim.SetTrigger("Attack");
        }else if (tomelhe) {
            Combo();
        }
        if (Input.GetKeyDown(KeyCode.P) && podeAtaque && controle.estaNoChao() && muni�ao > 0) {
            muni�ao--;
            podeAtaque = false;
            controle.velocidadeHorizontal = 0;
            controle.for�aPulo = 0;
            anim.SetTrigger("Tiro");
            StartCoroutine(Tiro());
            tiro.Play();
        }
        count.text = muni�ao.ToString();
    }

    IEnumerator Tiro() {
        yield return new WaitForSeconds(1);
        podeAtaque = true;
        anim.SetTrigger("Orit");
        controle.velocidadeHorizontal = 10;
        controle.for�aPulo = 15;
    }

    private void Combo() {
        Timer -= Time.deltaTime;
        if(Timer <= .64f && Timer > 0) {
            podeAtaque = true;
        }
        if(Timer <= 0) {
            anim.SetTrigger("retornar");
            tomelhe = false;
            controle.velocidadeHorizontal = 10;
            controle.for�aPulo = 15;
            Timer = 0;
        }
    }
}
