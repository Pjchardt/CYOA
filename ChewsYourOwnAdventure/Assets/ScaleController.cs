using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class ScaleController : MonoBehaviour
{
    public static ScaleController Instance;

    string port = "COM3";
    SerialPort sp;

    public float Weight;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        sp = new SerialPort(port, 9600);
        try
        {
            sp.Open();
            sp.ReadTimeout = 1;
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    
    void Update()
    {
        if (sp.IsOpen)
        {
            Weight = float.Parse(sp.ReadLine());
        }
        else
        {
            Debug.Log("Serial Port not open!");
            Weight = 0f;
        }
    }
}
