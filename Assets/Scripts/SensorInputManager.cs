using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class SensorInputManager : MonoBehaviour
{
    public struct SensorData
    {
        public float xValue;
        public float yValue;
        public int buttonState;
        public float distance;
    }

    private static Queue<SensorData> sensorValues = new Queue<SensorData>();
    private static readonly object queueLock = new object();
    private const int queueSize = 5;
    private Thread receiveThread;
    private UdpClient client;
    private int port = 5005;

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
                byte[] data = client.Receive(ref anyIP);
                string text = System.Text.Encoding.UTF8.GetString(data);
                string[] parts = text.Split(',');
                if (parts.Length == 4)
                {
                    SensorData sensorData = new SensorData
                    {
                        xValue = float.Parse(parts[0]),
                        yValue = float.Parse(parts[1]),
                        buttonState = int.Parse(parts[2]),
                        distance = float.Parse(parts[3])
                    };

                    // lock (queueLock)
                    {
                        if (sensorValues.Count >= queueSize)
                        {
                            sensorValues.Dequeue();
                        }
                        sensorValues.Enqueue(sensorData);
                    }
                }
            }
            catch (Exception err)
            {
                Debug.LogError(err.ToString());
            }
        }
    }

    void OnDisable()
    {
        if (receiveThread != null) receiveThread.Abort();
        if (client != null) client.Close();
    }

    // Separate methods for accessing individual sensor values
    public static float GetLatestDistance()
    {
        // lock (queueLock)
        {
            return sensorValues.Count > 0 ? sensorValues.Last().distance : float.MaxValue;
        }
    }

    public static float GetLatestXValue()
    {
        // lock (queueLock)
        {
            return sensorValues.Count > 0 ? sensorValues.Last().xValue : 0f;
        }
    }

    public static float GetLatestYValue()
    {
        // lock (queueLock)
        {
            return sensorValues.Count > 0 ? sensorValues.Last().yValue : 0f;
        }
    }

    public static int GetLatestButtonState()
    {
        // lock (queueLock)
        {
            return sensorValues.Count > 0 ? sensorValues.Last().buttonState : 1;  // Assuming 0 is the default (unpressed) state
        }
    }
}
