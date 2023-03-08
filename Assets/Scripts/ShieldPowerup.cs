using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    public PowerupBehavior powerupBehavior;

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.name == "Player") {
            gameObject.GetComponent<Renderer>().enabled = false;
            transform.position = new Vector2(999, 999);
            StartCoroutine(ExecuteEffect(collider2D));
        }
    }

    private IEnumerator ExecuteEffect(Collider2D collider2D) {
        powerupBehavior.Apply(collider2D.gameObject);
        yield return new WaitForSeconds(7f);
        powerupBehavior.Remove(collider2D.gameObject);
        Destroy(gameObject);
    }
}
