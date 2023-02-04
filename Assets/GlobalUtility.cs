using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUtility : MonoBehaviour
{

    public const int size = 2;
    protected float[] forceVals = new float[size];
    protected float G = 1;
    protected Transform[] planets = new Transform[size];
    protected Vector3[] forceDirection = new Vector3[size];
    protected int[] rotate = new int[size];

    public float getForceVals(int indx)
    {
        return forceVals[indx];
    }
    public float getG()
    {
        return G;
    }

    public Transform[] getPlanets()
    {
        return planets;
    }
    public Vector3 getForceDirection(int indx)
    {
        return forceDirection[indx];
    }
    public void putForceVals(int indx, float val)
    {
        forceVals[indx] = val;
    }
    public void putForceDirection(int indx, Vector3 val)
    {
        forceDirection[indx] = val;
    }
    public int getRotate(int indx)
    {
        return rotate[indx];
    }
    public void putRotate(int indx, int val)
    {
        rotate[indx] = val;
    }


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < size; i++)
        {
            planets[i] = GameObject.FindGameObjectWithTag("planet" + i).transform;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
