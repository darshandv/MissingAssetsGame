// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Player : MonoBehaviour
// {
//     // Start is called before the first frame update
    
 

//     // string getEnergyText() {
//     //     if (energy > 0) return "Energy: " + energy.ToString();
//     //     else return "Ded in the space";
//     // }
    
//     // string getHealthText() {
//     //     if(health > 0) return "Health: " + health.ToString();
//     //     else return "Health: Ded";
//     // }

//     private void OnCollisionEnter2D(Collision2D collision) 
//     {
//         reduceHealth();
//         if(health == 0) Destroy(gameObject);
//     }

//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.UpArrow)) {
//             rotateSpeed +=20;
//             reduceEnergy();
//         }
//         else if (Input.GetKeyDown(KeyCode.DownArrow)) {
//             rotateSpeed -=20;
//         }

//         if(isDead) rotateSpeed = 0;
//         // textElement.text = getEnergyText() + "\n" + getHealthText();
//         // Debug.Log(textElement.text);
//         Vector3 point = customPivot.position;
//         Vector3 axis = new Vector3(0, 0, 1);
        

        
//         transform.RotateAround(point, axis, Time.deltaTime * rotateSpeed);

//         Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
//         float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//         Quaternion rotation= Quaternion.AngleAxis(angle - 90, Vector3.forward);
//         transform.rotation = rotation;

//         // transform.RotateAround(customPivot.position, Vector3.up, 1 * Time.deltaTime);
//     }
// }
