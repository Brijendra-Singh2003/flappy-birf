using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    private Material material;

    private void Awake() {
        material = GetComponent<MeshRenderer>().material;
    }

    private void Update() {
        material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
