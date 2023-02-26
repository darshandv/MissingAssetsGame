using UnityEngine;
using System.Collections;

public class TimeBombController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionForce = 1000f;
    public float explosionRadius = 5f;
    public ParticleSystem explosionParticles;

    private bool hasExploded = false;

    void Start()
    {
        explosionParticles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Check if the player is in range of the explosion
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (
            player != null
            && Vector2.Distance(transform.position, player.transform.position) < explosionRadius
        )
        {
            // Trigger the explosion
            Explode();
        }
    }

    void Explode()
    {
        if (hasExploded)
        {
            return;
        }
        hasExploded = true;

        // Wait for a short delay before starting the particle system
        StartCoroutine(StartExplosion());

        // Get all the colliders in the explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            // Check if the collider has a rigidbody
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Calculate the direction of the explosion and apply a force to the rigidbody
                Vector2 direction = rb.transform.position - transform.position;
                float distance = direction.magnitude;
                float explosionPower = 1 - (distance / explosionRadius);
                rb.AddForce(
                    direction.normalized * explosionPower * explosionForce,
                    ForceMode2D.Impulse
                );
            }
        }

        // Destroy the time bomb object
        Destroy(gameObject);
    }

    IEnumerator StartExplosion()
    {
        // Wait for a short delay before starting the particle system
        yield return new WaitForSeconds(0.1f);

        // Spawn the explosion particle system
        GameObject explosion = Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity
        );

        // Get the particle system component
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();

        // Wait for the particle system to finish playing
        while (ps.IsAlive())
        {
            yield return null;
        }

        // Destroy the explosion object
        Destroy(explosion);
    }
}
