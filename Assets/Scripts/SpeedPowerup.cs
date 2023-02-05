using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public PowerupBehavior powerupBehavior;

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.GetComponent<playerScript>().isInvulnerable) return;
        gameObject.GetComponent<Renderer>().enabled = false;
        transform.position = new Vector2(999, 999);
        StartCoroutine(ExecuteEffect(collider2D));
    }
 
    private IEnumerator ExecuteEffect(Collider2D collider2D) {
        powerupBehavior.Apply(collider2D.gameObject);
        yield return new WaitForSeconds(5f);
        powerupBehavior.Remove(collider2D.gameObject);
        Destroy(gameObject);
    }
}
