using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.IO.Ports;

public class ArduinoReserve : MonoBehaviour
{
    public SerialPort sp = new SerialPort("com9", 38400);//com7
    //public SerialPort sp4 = new SerialPort("com4", 38400);
    private Thread serialThread;
    public int WaveVector;
    public float Vectory;
    public string wavedate;
    public string confirm;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
        try
        {
            sp.Open();
            //sp4.Open();
            serialThread = new Thread(ReadSerialData);
            serialThread.Start();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open Serial Port: " + e.Message);
        }

    }



    void FixedUpdate()
    {
        
    }

    private void ReadSerialData()
    {
        while (true)
        {
            if (sp.IsOpen)
            {
                confirm = sp.ReadLine();
                wavedate = sp.ReadLine();
                if (wavedate == "T")
                {
                    Debug.Log("拔刀!");
                }
                
            }
            Thread.Sleep(10); // 控制讀取頻率，避免過度占用CPU
        }
    }

}
