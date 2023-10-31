using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingUI : MonoBehaviour
{
    [Header("�÷��̾���� �Ÿ�")]
    public float distance = 2.0f;
    [Header("�÷��̾� ī�޶�")]
    public Transform player_cam;
    [Header("������� �ӵ�")]
    public float max_speed = 3.0f;
    private void Start()
    {
        
    }
    void Update()
    {
        Vector3 goal = player_cam.position + player_cam.forward * distance;
        float goal_dis = (goal - transform.position).magnitude;

        transform.rotation = Quaternion.Slerp(transform.rotation, player_cam.transform.rotation, goal_dis * max_speed * Time.deltaTime);
        //transform.position += goal * max_speed * Time.deltaTime; //2��° ���
        transform.position = Vector3.Slerp(transform.position, goal, goal_dis * max_speed * Time.deltaTime);
    }
}
