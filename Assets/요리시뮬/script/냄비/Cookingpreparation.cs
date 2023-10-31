using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{
    private ButtonInteraction inductionButton;
    private PotInteraction pot;
    public GameObject fire;
    public GameObject potObject;
    public float LimitTime;
    public float ftime;

    private bool water = true;
    private bool ingredients = true; //�����
    private bool finsh = true;

    void Start()
    {
        inductionButton = GameObject.Find("inductionButton").GetComponent<ButtonInteraction>();
        pot = potObject.GetComponent<PotInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inductionButton.isButtonPressed && pot.isPotOnInduction)
        {
            if (water != true)
            {
                if (inductionButton.isButtonPressed == true)
                {
                    //�ٽ�
                }
            }
            else if (water == true)
            {
                if (ingredients == true) //�� �ð� �ȿ� Ŭ���� �ߴ°�?
                {
                    LimitTime -= Time.deltaTime;
                    Debug.Log(LimitTime);
                    if (LimitTime >= 4 && LimitTime <= 6 && Input.GetKeyDown(KeyCode.K) && finsh == false) //yes ��Ḧ �ִ´�
                    {
                        finsh = true;
                        //�ϼ� �˾Ƽ� ���ۺ��� �� �� �ϼ�
                        Debug.Log("�ϼ�");
                    }
                    else if (LimitTime < 0)
                    {
                        //no ������ ���;����� ui�� ��� �� �����
                        LimitTime = 10f;
                        Debug.Log("�ٽ�");
                        water = false;
                        ingredients = false;
                        finsh = false;
                        pot.isPotOnInduction = false;
                        inductionButton.isButtonPressed = false;
                    }
                }
            }
        }
        //5�� ���(ui�� �δ��� ����� �޽��� ����)
        if (finsh == true) 
        {
            ftime -= Time.deltaTime;
            Debug.Log(ftime);
            if (ftime > 0 && inductionButton.isButtonPressed == false) // ���ѽð� ���� �߰� ��ư�� �����ִ� ���°� �Ǹ�
            {
                //��� �ű��� �̵�
                Debug.Log("����");
                finsh = false;
            }
            else if (ftime < 0 && inductionButton.isButtonPressed == true) // ���ѽð� �ѱ�� ��ư�� �����ִ� ���°� �Ǹ�
            {
                //�ҳ�
                fire.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen"))
        {
            ingredients = true;
        }
        if (collision.gameObject.CompareTag("water"))
        {
            water = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen"))
        {
            ingredients = false;
        }
        if (collision.gameObject.CompareTag("water"))
        {
            water = false;
        }
    }
}
