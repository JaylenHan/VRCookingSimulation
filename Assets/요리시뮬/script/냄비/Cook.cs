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
            result.Add("라면에 면이 없잖아????");
            return result;
        }
        if (ice_cnt > 0)
        {
            result.Add("라면은 뜨거운 음식이니 얼음은 어울리지 않아..");
        }
        if(egg_cnt > 0)
        {
            result.Add("달걀은 삶은 달걀을 만들 게 아니라면 깨서 넣어야해!!");
        }
        if(onion_cnt < 7)
        {
            result.Add("파를 좀더 잘게 써는 게 좋겠어.");
        }
        if(white_egg_cnt < 1)
        {
            result.Add("달걀은 취향이지만 넣으면 맛있다구?");
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
        if(obj.name.Contains("파"))
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
        else if (obj.name.Contains("라면"))
        {
            lamen_cnt++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.name.Contains("파"))
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
        else if (obj.name.Contains("라면"))
        {
            lamen_cnt--;
        }
    }
}
