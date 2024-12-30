using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class emission : MonoBehaviour
{
    public Transform target; // �ؼЦ�m
    public float duration = 5f; // ���ʮɶ��]��^

    private Vector3 startPosition; // �_�l��m
    public float timeElapsed = 0f; // �w�g�L���ɶ�

    public bool Isshot;
    private void Start()
    {
        target = GameObject.Find("player_Cube").GetComponent<Transform>();
        startPosition = transform.position;
    }
    void Update()
    {
        // �p��w�L�ɶ�
        timeElapsed += Time.deltaTime;

        // �p�ⴡ�Ȫ��i��
        float t = timeElapsed / duration;

        // �ϥ� Lerp ���ȱq�_�l��m��ؼЦ�m
        transform.position = Vector3.Lerp(startPosition, target.position, t);

        // ��F��ζW�L�]�w���ɶ��A�����
        if (timeElapsed >= duration)
        {
            // �T�O����b�ɶ������ɥ��n��F�ؼЦ�m
            transform.position = target.position;
            Isshot = true;
        }

    }
}
