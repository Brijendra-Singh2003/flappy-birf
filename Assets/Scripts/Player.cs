using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity = 19.62f;
    public float jumpStrength = 7f;
    private float velocity;
    public float terminalVelocity = -7f;

    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Animate), 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            velocity = jumpStrength;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                velocity = jumpStrength;
        }

        if(velocity > terminalVelocity) {
            velocity -= gravity * Time.deltaTime;
        }
        transform.position += Vector3.up * velocity * Time.deltaTime;
    }

    private void Animate()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(GameManager.instance == null) return;
        string tagname = collider.gameObject.tag;
        Debug.Log(tagname);
        if(tagname == "hit") GameManager.instance.GameOver();
        else if(tagname == "score") GameManager.instance.PlayerScores();
    }
}
