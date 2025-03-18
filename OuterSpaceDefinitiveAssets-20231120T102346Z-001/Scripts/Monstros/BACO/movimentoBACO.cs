using System.Collections;
using UnityEngine;

public class movimentoBACO : MonoBehaviour {
    public Transform limiteEsquerdo, limiteDireito;
    public float distanciaEsquerda, distanciaDireita;
    float velocidadeHorizontal = 2.5f;

    Rigidbody2D rig;

    public Transform Protagonista;
    [SerializeField] bool estaAVista = false;
    [SerializeField] bool podeAtacar;
    public float distanciaHorizontal;

    private void Awake() {
        podeAtacar = true;
    }

    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update() {
        //Movimentação
        if(transform.position.x >= limiteDireito.position.x || transform.position.x <= limiteEsquerdo.position.x) {
            transform.Rotate(new Vector2(0, 180), Space.Self);
        }

        distanciaEsquerda = Vector2.Distance(limiteEsquerdo.position, transform.position );
        distanciaDireita = Vector2.Distance(limiteDireito.position, transform.position );

        transform.Translate(new Vector2(velocidadeHorizontal * Time.deltaTime, rig.velocity.y), Space.Self);

        //Ataque
        distanciaHorizontal = Mathf.Abs(Protagonista.position.x - transform.position.x);
        if (distanciaHorizontal <= 3.5f && distanciaHorizontal >= 1 && estaAVista && podeAtacar) {
            GetComponent<Animator>().SetTrigger("Ataque");
            StartCoroutine(estaRecuperando());
        }
        if (distanciaHorizontal <= 7 && distanciaHorizontal >= 5 && estaAVista && podeAtacar) {
            GetComponent<Animator>().SetTrigger("Investida");
            StartCoroutine(Dash());
        }
    }

    IEnumerator estaRecuperando() {
        yield return new WaitForSeconds(.1f);
        velocidadeHorizontal = 0;
        yield return new WaitForSeconds(.6f);
        podeAtacar = false;
        velocidadeHorizontal = 2.5f;
        yield return new WaitForSeconds(.4f);
        podeAtacar = true;
    }

    IEnumerator Dash() {
        yield return new WaitForSeconds(.1f);
        velocidadeHorizontal = 0;
        yield return new WaitForSeconds(.2f);
        podeAtacar = false;
        velocidadeHorizontal = 20;
        yield return new WaitForSeconds(.5f);
        velocidadeHorizontal = 2.5f;
        podeAtacar = true;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.layer == 10) {
            estaAVista = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.layer == 10) {
            estaAVista = false;
        }
    }
}
