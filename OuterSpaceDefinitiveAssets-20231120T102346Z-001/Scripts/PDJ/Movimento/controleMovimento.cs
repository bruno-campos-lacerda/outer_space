using System.Collections;
using UnityEngine;

public class controleMovimento : MonoBehaviour {
    public float velocidadeHorizontal = 10f;
    public float forçaPulo = 15f;

    private BoxCollider2D caixaColisao;
    [SerializeField]private LayerMask layerChao;

    private Rigidbody2D rig;
    private Animator anim;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        caixaColisao = GetComponent<BoxCollider2D>();
    }

    void Update() {
        float H = Input.GetAxis("Horizontal") * velocidadeHorizontal * Time.deltaTime;
        if (H != 0 && estaNoChao()) {
            anim.SetBool("Correndo", true);
            anim.SetBool("Parado", false);
        } else if(H == 0 && estaNoChao()) {
            anim.SetBool("Correndo", false);
            anim.SetBool("Parado", true);
        }else if (!estaNoChao()) {
            anim.SetBool("Correndo", false);
            anim.SetBool("Parado", false);
        }
        if (H > 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (H < 0) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        float V = Input.GetAxisRaw("Jump") * forçaPulo * Time.deltaTime;
        if(V > 0 && !estaNoChao()) {
            anim.SetBool("estaPulando", true);
        } else if(V == 0 && !estaNoChao()) {
            anim.SetBool("estaCaindo", true);
        }
        if (!estaNoChao()) {
            StartCoroutine(WaitForFall());
        } else {
            StartCoroutine(WaitForJump());
            anim.SetBool("estaPulando", false);
            anim.SetBool("estaCaindo", false);
        }
        transform.Translate(new Vector2(H, V), Space.Self);
    }



    public bool estaNoChao() {
        RaycastHit2D chao = Physics2D.BoxCast(caixaColisao.bounds.center, caixaColisao.bounds.size, 0, Vector2.down, 0.1f, layerChao);
        return chao.collider != null;
    }

    IEnumerator WaitForFall() {
        yield return new WaitForSeconds(.35f);
        forçaPulo = 0f;
    }

    IEnumerator WaitForJump() {
        yield return new WaitUntil(estaNoChao);
        forçaPulo = 15f;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 6) {
            forçaPulo = 0;
        }
        if (collision.gameObject.layer == 7) {
            print("Chegou mensagem para você");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.layer == 6) {
            forçaPulo = 0;
        }
    }
}
