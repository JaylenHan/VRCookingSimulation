using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{
    public Pot pot;
    public PotInteraction potInteraction;
    public ButtonInteraction inductionButton;

    [Header("�ڸ�")]
    [SerializeField] private Message sub_start;
    [SerializeField] private Message sub_materials;
    [SerializeField] private Message sub_fire;
    [SerializeField] private Message sub_end;
    [SerializeField] private Message sub_retry;
    [SerializeField] private Message sub_good;
    [Header("����")]
    [SerializeField] private AudioSource audio_start;
    [SerializeField] private AudioSource audio_materials;
    [SerializeField] private AudioSource audio_fire;
    [SerializeField] private AudioSource audio_end;
    [SerializeField] private AudioSource audio_retry;
    [SerializeField] private AudioSource audio_good;
    [Header("Ʃ�丮�� �ڸ�")]
    [SerializeField] private Message sub_tutorial1; // ����
    [SerializeField] private Message sub_tutorial2; // ���
    [SerializeField] private Message sub_tutorial3; // ������ ����

    [Space(10.0f)]
    public float LimitTime;
    public float minTime;
    public float maxTime;
    public float ftime;

    public bool ingredients = false; //�����
    private bool finsh = false;
    private bool table = false;

    void Start()
    {
        Invoke(nameof(GameStart), 1.0f); //1�ʵ� ù ����
    }

    public void GameStart()
    {
        sub_start.gameObject.SetActive(true);
        audio_start.Play();

        StartCoroutine(LevelStartDelay(1, 5.0f));
    }

    IEnumerator LevelStartDelay(int lv, float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelStart(lv);
    }

    public void OffSubtitles()
    {
        sub_tutorial1.gameObject.SetActive(false);
        sub_tutorial2.gameObject.SetActive(false);
        sub_tutorial3.gameObject.SetActive(false);
    }

    public void LevelStart(int lv)
    {
        switch(lv)
        {
            case 0:
                GameStart();
                break;
            case 1:
                sub_tutorial1.gameObject.SetActive(true);
                StartCoroutine(LevelStartDelay(2, 9.0f));
                break;
            case 2:
                sub_materials.gameObject.SetActive(true);
                audio_materials.Play();
                StartCoroutine(LevelStartDelay(3, 3.0f));
                break;
            case 3:
                sub_tutorial2.gameObject.SetActive(true);
                break;
            case 4:
                OffSubtitles();
                sub_tutorial3.gameObject.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inductionButton.isButtonPressed && potInteraction.isPotOnInduction)
        {
            if (pot != true)
            {
                //�ٽ� UI ��ư���� GameStateLoad1 ��ũ��Ʈ �Ҵ��ϱ�
                sub_retry.gameObject.SetActive(true);
            }
            else if (pot.GetWaterAmount() > 0.9f)
            {
                if (ingredients == true) //���� �ְ� ��Ḧ �־��°�?
                {
                    LimitTime -= Time.deltaTime;
                    Debug.Log(LimitTime); // �ð� UI
                    if (LimitTime >= minTime && LimitTime <= maxTime && (potInteraction.isPotOnInduction == false || inductionButton.isButtonPressed == false) && finsh == false) 
                    {
                        finsh = true;
                        sub_good.gameObject.SetActive(true);
                        //�ϼ� �˾Ƽ� ���ۺ��� �� �� �ϼ�
                    }
                    else if ((LimitTime > maxTime || LimitTime < minTime) && (potInteraction.isPotOnInduction == false || inductionButton.isButtonPressed == false))
                    {
                        //no ������ ���;����� ui�� ��� �� ����� UI ��ư���� GameStateLoad2 ��ũ��Ʈ �Ҵ��ϱ�
                        LimitTime = 10f;
                        sub_fire.gameObject.SetActive(true);
                        sub_retry.gameObject.SetActive(true);
                    }
                }
            }
        }     

        if (table == true)
        {
            sub_end.gameObject.SetActive(true);
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
