using UnityEngine;

public class BALOS : MonoBehaviour {

    [SerializeField] Transform esquerdoLimite, direitoLimite;
    public bool podeRotacionar, estaFugindo;

    void Start() {
        podeRotacionar = true;
        estaFugindo = false;
    }

    void Update() {
        if (podeRotacionar) {
            if (transform.position.x >= direitoLimite.transform.position.x) {
                rotacionar();
            }
            if(transform.position.x <= esquerdoLimite.transform.position.x) {
                rotacionar();
            }
        }

        transform.Translate(new Vector2(3 * Time.deltaTime, 0), Space.Self);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 10) {
            podeRotacionar = false;
            estaFugindo = true;
            rotacionar();
        }
    }

    void rotacionar() {
        transform.Rotate(new Vector2(0, 180), Space.Self);
    }
}
