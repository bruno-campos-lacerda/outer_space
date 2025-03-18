using UnityEngine;

public class gravidadeAlternativa : MonoBehaviour {
    public Transform planeta /*Planeta*/;

    public float forçaGravidade;

    public float distanciaGravidade;

    float angulo;

    void Update() {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        float distancia = Vector3.Distance(gameObject.transform.position, planeta.transform.position);
        Vector3 velocidade = planeta.transform.position - transform.position;
        angulo = 90 + Mathf.Atan2(velocidade.y, velocidade.x) * Mathf.Rad2Deg;

        rig.AddForce(velocidade.normalized * (1.0f - distancia / distanciaGravidade) * forçaGravidade);
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);

        /*float Distancia = Vector3.Distance(gameObject.transform.position, Planeta.transform.position);
        Vector3 Velocidade = Planeta.transform.position - transform.position;
        angulo = 90 + Mathf.Atan2(Velocidade.y, Velocidade.x) * Mathf.Rad2Deg;

        rig.AddForce(Velocidade.normalized * (1.0f - Distancia / distanciaGravidade) * forçaGravidade);
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);*/
    }
}
