using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float lifeTime = 5f; //range
    public int damage = 10;
    
    private PlayerMovement pm;

    void Start()
    {
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        if (playerGameObject != null)
        {
            pm = playerGameObject.GetComponent<PlayerMovement>();
        }
        else
        {
            Debug.LogError("Cannot find player game object.");
        }

        Destroy(gameObject, lifeTime);
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
