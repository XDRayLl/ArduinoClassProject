using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class emission : MonoBehaviour
{
    public Transform target; // 目標位置
    public float duration = 5f; // 移動時間（秒）

    private Vector3 startPosition; // 起始位置
    public float timeElapsed = 0f; // 已經過的時間

    public bool Isshot;
    private void Start()
    {
        target = GameObject.Find("player_Cube").GetComponent<Transform>();
        startPosition = transform.position;
    }
    void Update()
    {
        // 計算已過時間
        timeElapsed += Time.deltaTime;

        // 計算插值的進度
        float t = timeElapsed / duration;

        // 使用 Lerp 插值從起始位置到目標位置
        transform.position = Vector3.Lerp(startPosition, target.position, t);

        // 當達到或超過設定的時間，停止移動
        if (timeElapsed >= duration)
        {
            // 確保物體在時間結束時正好到達目標位置
            transform.position = target.position;
            Isshot = true;
        }

    }
}
