using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{
    public Pot pot;
    public PotInteraction potInteraction;
    public ButtonInteraction inductionButton;
    public GameStateLoad saveload;

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
    [SerializeField] private Message sub_tutorial4; // ���� �� �޾�
    [SerializeField] private Message sub_tutorial5; // �� Ʋ��
    [SerializeField] private Message sub_tutorial6; // �� ��á�� �Ӹ�
    [SerializeField] private Message sub_tutorial7; // �� ������ �Ӹ�
    [SerializeField] private Message sub_tutorial8; // ������ ����
    [Space(10.0f)]
    public float LimitTime;
    public float minTime;
    public float maxTime;
    public float ftime;

    public bool ingredients = false; //�����
    private bool finsh = false;
    private bool table = false;

    int level = 0;

    bool water_check = false;

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
        sub_tutorial4.gameObject.SetActive(false);
        sub_tutorial5.gameObject.SetActive(false);
        sub_tutorial6.gameObject.SetActive(false);
        sub_tutorial7.gameObject.SetActive(false);
        sub_tutorial8.gameObject.SetActive(false);
    }

    public int GetLevel()
    {
        return level;
    }

    public void LevelStart(int lv)
    {
        level = lv;
        switch (lv)
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
            case 4: //������ ������
                OffSubtitles();
                sub_tutorial3.gameObject.SetActive(true);
                break;
            case 5: //�� �޾�
                OffSubtitles();
                sub_tutorial4.gameObject.SetActive(true);
                break;
            case 6: //�� Ʋ��
                OffSubtitles();
                sub_tutorial5.gameObject.SetActive(true);
                break;
            case 7: //�� ��á�� �Ӹ�
                OffSubtitles();
                sub_tutorial6.gameObject.SetActive(true);
                break;
            case 8: //�� ������ �Ӹ�
                OffSubtitles();
                sub_tutorial7.gameObject.SetActive(true);
                break;
            case 9: //���߰� ��� �־� �Ӹ�
                OffSubtitles();
                audio_good.Play();
                sub_tutorial8.gameObject.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!water_check)
        {
            if (pot.GetWaterAmount() > 0.8f)
            {
                LevelStart(7);
                water_check = true;
            }
        }
    }
}
