using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public float spawnRate = 5.0f;
    public int spawnAmt = 2;
    public float spawnDist = 25.0f;
    public float trajectoryVariance = 15.0f;

    public Meteor meteorPrefab;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn() {
        for (int i = 0; i < this.spawnAmt; i++) {
            Vector3 spawnDir = Random.insideUnitCircle.normalized * spawnDist;
            Vector3 spawnPoint = transform.position + spawnDir;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Meteor meteor = Instantiate(this.meteorPrefab, spawnPoint, rotation);
            meteor.size = Random.Range(meteor.minSize, meteor.maxSize);
            meteor.SetTrajectory(rotation * -spawnDir);
        }
    }    
}
