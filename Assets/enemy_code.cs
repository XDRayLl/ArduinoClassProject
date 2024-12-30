using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_code : MonoBehaviour
{
    public float timer;
    public Transform target;
    public GameObject bullet_M;
    private GameObject InScenebullet;//確定場景內沒有子彈
    private AudioSource audioSource;
    public AudioClip soundEffects;  // 存儲多個音效
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffects;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >=5 && InScenebullet == null )
        {
            audioSource.Play();
            Instantiate(bullet_M, target.position, Quaternion.identity);
            timer = 0;
        }
    }
}
