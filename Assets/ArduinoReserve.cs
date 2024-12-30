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

    [Header("遊戲判斷區")]
    private float timer;//冷卻時間
    public float cd_timer;
    public float wave_times;
    public GameObject bullets;
    public bool IsWave;
    public Health HP;
    // Start is called before the first frame update


    // Update is called once per frame
   

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

    void Update()
    {

        bullets = GameObject.FindWithTag("bullet");
        if (IsWave)
        {
            if (wave_times <= 0)
            {
                return;
            }
            else
            {
                game_check();
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > cd_timer)
            {
                wave_times = 1;
                timer = 0;
            }
        }
        if (bullets != null)
        {
            if (bullets.GetComponent<emission>().Isshot)
            {
                game_check();
            }
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
                    IsWave = true;
                }
                else 
                {
                    IsWave = false;
                }

            }
            Thread.Sleep(10); // 控制讀取頻率，避免過度占用CPU
        }
    }
    void game_check() 
    {
        //0.72~0.84
        if (bullets != null) 
        {
            float correct_time = bullets.GetComponent<emission>().duration;
            float now_time = bullets.GetComponent<emission>().timeElapsed;
            if ((now_time >= (correct_time * 0.72) && now_time <= (correct_time * 0.84)))
            {
                Destroy(bullets);
                Debug.Log("You Win!");
            }
            else 
            {
                Debug.Log("You Die!");
                if (bullets.GetComponent<emission>().Isshot) 
                {
                    HP.Hp--;
                    Destroy(bullets);
                }
            }
        }
        wave_times--;
    }
}
