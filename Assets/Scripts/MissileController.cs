using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float lifeTime = 5f;
    public int damage = 10;
    public float speed = 5f;
    public float trackingSpeed = 1f; // how quickly the missile can change direction

    private PlayerMovement pm;
    private Vector2 targetPosition;

    void Start()
    {
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        if (playerGameObject != null)
        {
            pm = playerGameObject.GetComponent<PlayerMovement>();
            targetPosition = pm.transform.position;
        }
        else
        {
            Debug.LogError("Cannot find player game object.");
        }

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (pm != null)
        {
            // calculate the new target position based on the player's current position
            targetPosition = Vector2.MoveTowards(
                targetPosition,
                pm.transform.position,
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
        if (pm != null)
        {
            pm.reduceHealth(damage);
            Destroy(gameObject);
        }
    }
}
