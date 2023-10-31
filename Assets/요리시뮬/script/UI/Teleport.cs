using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float followSpeed = 5.0f; // ���󰡱� �ӵ�
    public Transform targetCamera;

    void Update()
    {
        if (targetCamera != null)
        {
            transform.rotation = Quaternion.Euler(0, targetCamera.localEulerAngles.y, 0);
            // ī�޶��� ��ġ�� ���󰡵��� ����
            transform.position = Vector3.Lerp(transform.position, targetCamera.position, followSpeed * Time.deltaTime);
        }
    }
}
