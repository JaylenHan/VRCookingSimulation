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
        return result;
    }

    void Update()
    {
        if(!send_msg)
        {
            if(lamen_cnt > 0)
            {
                manager.LevelStart(11);
                send_msg = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.name.Contains("��"))
        {
            onion_cnt++;
        }
        else if(obj.name.Contains("egg"))
        {
            egg_cnt++;
        }
        else if (obj.name.Contains("ice"))
        {
            ice_cnt++;
        }
        else if (obj.name.Contains("white_egg"))
        {
            white_egg_cnt++;
        }
        else if (obj.name.Contains("���"))
        {
            lamen_cnt++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.name.Contains("��"))
        {
            onion_cnt--;
        }
        else if (obj.name.Contains("egg"))
        {
            egg_cnt--;
        }
        else if (obj.name.Contains("ice"))
        {
            ice_cnt--;
        }
        else if (obj.name.Contains("white_egg"))
        {
            white_egg_cnt--;
        }
        else if (obj.name.Contains("���"))
        {
            lamen_cnt--;
        }
    }
}
