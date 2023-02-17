using UnityEngine;

public class Meteor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D meteorBody;

    public float size = 3.0f;
    public float minSize = 2.0f;
    public float maxSize = 4.0f;
    public float speed = 5.0f;
    private float lifetime = 30.0f;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        meteorBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {   
        if (collision.gameObject.name.Contains("EnemyBullet")) {
            Destroy(collision.gameObject);
        } else if (collision.gameObject.name.Contains("Bullet")) {
            Destroy(this.gameObject);
        }
    }

    public void SetTrajectory(Vector2 direction) {
        meteorBody.AddForce(direction * speed);
        Destroy(gameObject, lifetime);
    }
}
