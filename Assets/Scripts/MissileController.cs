using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float lifeTime = 8f;
    public int damage = 10;
    public float speed = 30f;
    public float trackingSpeed = 20f; // how quickly the missile can change direction
    public float maxRotationSpeed = 180f;

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
            // update target position to follow the player
            Vector2 targetPosition = transform.position;
            targetPosition = Vector2.MoveTowards(
                targetPosition,
                playerGameObject.transform.position,
                trackingSpeed * Time.deltaTime
            );

            // move the missile towards the target position
            Vector2 direction = targetPosition - (Vector2)transform.position;
            transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;

            // rotate the missile towards its velocity vector
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Quaternion currentRotation = transform.rotation;
            float maxDeltaAngle = maxRotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(
                currentRotation,
                targetRotation,
                maxDeltaAngle
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("collision of missile");
        if (!(collision.collider.CompareTag("Enemy"))){
            Destroy(gameObject);
            Debug.Log(collision.collider.name);
        }
        
    }
}
