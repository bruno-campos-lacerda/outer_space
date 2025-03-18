using System.Collections;
using UnityEngine;

public class PreesS : MonoBehaviour
{
    public float movement;
    public float time;

    private void Awake() {
        StartCoroutine (UpDown());
    }

    IEnumerator UpDown() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, movement);
        yield return new WaitForSeconds(time);
        movement *= -1;
        StartCoroutine(UpDown());
    }
}
