using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float leftEdge = -12f;
    public float speed = 5f;

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
    }
}
