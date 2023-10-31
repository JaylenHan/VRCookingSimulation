using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{

    private ButtonInteraction inductionButton;
    public PotInteraction pot;
    public Water water;

    public GameObject fire;
    public GameObject end;
    public GameObject retry;
    public GameObject good;

    public float LimitTime;
    public float minTime;
    public float maxTime;
    public float ftime;

    public bool ingredients = false; //�����
    private bool finsh = false;
    private bool table = false;

    void Start()
    {
        inductionButton = GameObject.Find("inductionButton").GetComponent<ButtonInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inductionButton.isButtonPressed && pot.isPotOnInduction)
        {
            if (water.water != true)
            {
                //�ٽ� UI ��ư���� GameStateLoad1 ��ũ��Ʈ �Ҵ��ϱ�
                retry.SetActive(true);
            }
            else if (water.water == true)
            {
                if (ingredients == true) //���� �ְ� ��Ḧ �־��°�?
                {
                    LimitTime -= Time.deltaTime;
                    Debug.Log(LimitTime); // �ð� UI
                    if (LimitTime >= minTime && LimitTime <= maxTime && (pot.isPotOnInduction == false || inductionButton.isButtonPressed == false) && finsh == false) 
                    {
                        finsh = true;
                        good.SetActive(true);
                        //�ϼ� �˾Ƽ� ���ۺ��� �� �� �ϼ�
                    }
                    else if ((LimitTime > maxTime || LimitTime < minTime) && (pot.isPotOnInduction == false || inductionButton.isButtonPressed == false))
                    {
                        //no ������ ���;����� ui�� ��� �� ����� UI ��ư���� GameStateLoad2 ��ũ��Ʈ �Ҵ��ϱ�
                        LimitTime = 10f;
                        fire.SetActive(true);
                        retry.SetActive(true);
                    }
                }
            }
        }     

        if (table == true)
        {
            Debug.Log("����"); // ���� UI ���� ��
            end.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen") && collision.gameObject.CompareTag("egg"))
        {
            ingredients = true;
        }

        if (collision.gameObject.CompareTag("Table")) 
        {
            table = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen") && collision.gameObject.CompareTag("egg"))
        {
            ingredients = false;
        }
    }
}
