using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{
    private ButtonInteraction inductionButton;
    private PotInteraction pot;
    public Water water;
    public GameObject fire;
    public GameObject potObject;
    public float LimitTime;
    public float ftime;

    public bool ingredients = false; //�����
    private bool finsh = false;

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
            if (water.water != true)
            {
                //�ٽ� UI ��ư���� GameStateLoad1 ��ũ��Ʈ �Ҵ��ϱ�
            }
            else if (water.water == true)
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
                        //no ������ ���;����� ui�� ��� �� ����� UI ��ư���� GameStateLoad2 ��ũ��Ʈ �Ҵ��ϱ�
                        LimitTime = 10f;
                        Debug.Log("�ٽ�");
                    }
                }
            }
        }
        //5�� ���(ui�� �δ��� ����� �޽��� ����)
        if (finsh == true) 
        {
            ftime -= Time.deltaTime;
            //Debug.Log(ftime);
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
                //UI ��ư���� GameStateLoad3 ��ũ��Ʈ �Ҵ��ϱ�
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen"))
        {
            ingredients = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenonion") && collision.gameObject.CompareTag("Lamen"))
        {
            ingredients = false;
        }
    }
}
