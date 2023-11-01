using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    public Cookingpreparation manager;

    int onion_cnt = 0;
    int egg_cnt = 0;
    int ice_cnt = 0;
    int white_egg_cnt = 0;
    int lamen_cnt = 0;
    
    bool send_msg = false;

    void Start()
    {
        
    }

    public List<string> GetRating()
    {
        List<string> result = new();
        if(lamen_cnt < 1)
        {
            result.Add("��鿡 ���� ���ݾ�????");
            return result;
        }
        if (ice_cnt > 0)
        {
            result.Add("����� �߰ſ� �����̴� ������ ��︮�� �ʾ�..");
        }
        if(egg_cnt > 0)
        {
            result.Add("�ް��� ���� �ް��� ���� �� �ƴ϶�� ���� �־����!!");
        }
        if(onion_cnt < 7)
        {
            result.Add("�ĸ� ���� �߰� ��� �� ���ھ�.");
        }
        if(white_egg_cnt < 1)
        {
            result.Add("�ް��� ���������� ������ ���ִٱ�?");
        }
        if (result.Count == 0)
            result.Add("�Ϻ��մϴ�!!!!");
        return result;
    }

    void Update()
    {
        if(!send_msg)
        {
            if (lamen_cnt > 0)
            {
                Debug.Log("okkk");
                manager.LevelStart(11);
                send_msg = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.name.Contains("��"))
        {
            onion_cnt++;
            Debug.Log("��");
        }
        if (obj.name.Contains("egg"))
        {
            egg_cnt++;
            Debug.Log("egg");
        }
        if (obj.name.Contains("ice"))
        {
            ice_cnt++;
            Debug.Log("ice");
        }
        if (obj.name.Contains("white_egg"))
        {
            white_egg_cnt++;
            Debug.Log("white_egg");
        }
        if (obj.name.Contains("���"))
        {
            lamen_cnt++;
            Debug.Log("���");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.name.Contains("��"))
        {
            onion_cnt--;
        }
        if (obj.name.Contains("egg"))
        {
            egg_cnt--;
        }
        if (obj.name.Contains("ice"))
        {
            ice_cnt--;
        }
        if (obj.name.Contains("white_egg"))
        {
            white_egg_cnt--;
        }
        if (obj.name.Contains("���"))
        {
            lamen_cnt--;
        }
    }
}
