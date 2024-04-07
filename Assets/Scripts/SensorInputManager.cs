using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class SensorInputManager : MonoBehaviour
{
    public static Queue<float> sensorValues = new Queue<float>();
    private static readonly object queueLock = new object();
    private const int queueSize = 5;
    Thread receiveThread;
    UdpClient client;
    int port = 5005;  // Port should match the one used by the Python server

    // Use this for initialization
    void Start()
    {
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // Data receiving method
    private void ReceiveData()
    {
        client = new UdpClient(port);
        // print the details of the client
        
        Debug.Log("SensorInputManager is listening on port " + port);
        IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
        Debug.Log("Client IP: " + anyIP.Address + ", Port: " + anyIP.Port);
        while (true)
        {
            try
            {
                // IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                // Debug.Log("Received data");
                string text = System.Text.Encoding.UTF8.GetString(data);
                // float distance = float.Parse(text);
                if (float.TryParse(text, out float distance))
                {
                    lock (queueLock)
                    {
                        if (sensorValues.Count >= queueSize)
                        {
                            sensorValues.Dequeue();  // Remove the oldest value
                        }
                        sensorValues.Enqueue(distance);  // Add the new value
                    }
                }

                // Here, you can call any method to handle the distance data,
                // such as applying thrust if distance < 100 cm.
                Debug.Log("Received distance: " + distance);
                
                if (distance < 100)
                {
                    // Apply thrust
                    // Note: Make sure to call Unity functions from the main thread.
                }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    private void Update()
    {

    }

    void OnDisable()
    {
        if (receiveThread != null) receiveThread.Abort();
        client.Close();
    }

    public static float GetLatestSensorValue()
    {
        lock (queueLock)
        {
            if (sensorValues.Count > 0)
            {
                // Access the last element in the queue
                return sensorValues.ElementAt(sensorValues.Count - 1);
            }
            else
            {
                return float.MaxValue; // Or any other default indicating no value
            }
        }
    }
}
