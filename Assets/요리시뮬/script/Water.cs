using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Pot pot;
    public bool water = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (pot.water_amount > 0.9f)
        {
            Debug.Log("���� ����á���ϴ�. ���� ��װ� ��Ḧ �־��ּ���.");
            water = true;
        }
    }
}
