using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{
    private ButtonInteraction inductionButton;
    private PotInteraction pot;
    public GameObject fire;
    public float LimitTime;

    private bool water = false;
    private bool ingredients = false;  //�����

    void Start()
    {
        inductionButton = GameObject.Find("inductionButton").GetComponent<ButtonInteraction>();
        pot = GetComponent<PotInteraction>();
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
                LimitTime -= Time.deltaTime;
                Debug.Log(LimitTime);
                if (LimitTime >= 4 && LimitTime <= 6) //�� �ð� �ȿ� Ŭ���� �ߴ°�?
                {
                    if (ingredients == true) //yes ��Ḧ �ִ´�
                    {
                        //�ϼ� �˾Ƽ� ���ۺ��� �� �� �ϼ�
                        //5�� ���(ui�� �δ��� ����� �޽��� ����)
                        if (inductionButton.isButtonPressed == false)
                        {
                            //��� �ű��� �̵�
                        }
                        else if (inductionButton.isButtonPressed == true)
                        {
                            //�ҳ�
                            fire.SetActive(true);
                        }
                    }
                }
                else
                {
                    //no ������ ���;����� ui�� ��� �� �����
                    LimitTime = 10f;
                }



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
