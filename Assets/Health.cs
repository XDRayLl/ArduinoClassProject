using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] healthimages;
    public int Hp;
    private float last_hp;
    // Start is called before the first frame update
    void Start()
    {
        last_hp = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp >= 0) 
        {
            if (Hp != last_hp)
            {
                healthimages[Hp].enabled = false;
                last_hp = Hp;
            }
        }
    }
}
