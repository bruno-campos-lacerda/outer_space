using UnityEngine;

public class Collisor : MonoBehaviour
{

    [SerializeField]
    private gravidadeControle gravidade;
    [SerializeField]
    private controleAtaque controll;
    bool podeTransitar;

    void Start()
    {
        podeTransitar = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 3) {
            podeTransitar = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 6 && podeTransitar) {
            gravidade.podeGravitar = true;
            podeTransitar = false;
        }
        if(collision.gameObject.layer == 7) {
            controll.muniçao += 2;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.layer == 6 && podeTransitar) {
            gravidade.podeGravitar = false;
            podeTransitar = false;
        }
    }
}
