using UnityEngine;

public class Spawner : MonoBehaviour {

    public BALOS balos;

    public GameObject BLO;
    public float Spaw;
    public int nascimentos = 4;

    private float proximoSpaw;

    void Update() {
        if (balos != null && balos.estaFugindo == true && Time.time > proximoSpaw && nascimentos > 0) {
            nascimentos--;
            proximoSpaw = Time.time + Spaw;
            Instantiate(BLO, transform.position, BLO.transform.rotation);
        }
    }
}
