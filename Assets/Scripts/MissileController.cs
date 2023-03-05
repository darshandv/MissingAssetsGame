using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float lifeTime = 10f;
    public int damage = 10;
    public float speed = 5f;
    public float trackingSpeed = 2f; // how quickly the missile can change direction

    private Vector2 targetPosition;
    private GameObject playerGameObject;

    void Start()
    {
        playerGameObject = GameObject.FindWithTag("Player");
        if (playerGameObject != null)
        {
            targetPosition = playerGameObject.transform.position;
        }
        else
        {
            Debug.LogError("Cannot find player game object.");
        }

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (playerGameObject != null)
        {
            // calculate the new target position based on the player's current position
            targetPosition = Vector2.MoveTowards(
                targetPosition,
                playerGameObject.transform.position,
                trackingSpeed * Time.deltaTime
            );

            // move the missile towards the target position
            Vector2 direction = targetPosition - (Vector2)transform.position;
            transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;

            // rotate the missile to face the direction it is moving in
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
