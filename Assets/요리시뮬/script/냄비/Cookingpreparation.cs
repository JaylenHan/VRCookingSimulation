using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingpreparation : MonoBehaviour
{
    public Pot pot;
    public Cook cook;
    public PotInteraction potInteraction;
    public ButtonInteraction inductionButton;
    public GameStateLoad saveload;
    public MeshRenderer waterrender;

    [Header("�ڸ�")]
    [SerializeField] private Message sub_start;
    [SerializeField] private Message sub_materials;
    [SerializeField] private Message sub_fire;
    [SerializeField] private Message sub_end;
    [SerializeField] private Message sub_retry;
    [SerializeField] private Message sub_good;
    [SerializeField] private Message sub_timer;
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
    [SerializeField] private Message sub_tutorial9; // ��� ��
    [SerializeField] private Message sub_tutorial10; // ��Ḧ �� ���� ��
    [SerializeField] private Message sub_tutorial11; // ���� ��ư ����, 
    [SerializeField] private Message sub_tutorial12; // Ÿ�̸� �ȳ�
    [SerializeField] private Message sub_tutorial13; // ����� Ž
    [SerializeField] private Message sub_tutorial14; // ����� �� ����
    [SerializeField] private Message sub_tutorial15; // ��� �� ����
    [SerializeField] private Message sub_tutorial16; // ��� ��
    [Space(10.0f)]
    public float LimitTime = 30;
    public float minTime = 15;
    public float maxTime = 22;

    float timer = 30.0f;

    private bool finsh = false;
    private bool table = false;

    int level = 0;

    bool water_check = false;
    bool all_ok = false;
    bool start_timer = false;
    bool end = false;

    void Start()
    {
        timer = LimitTime;
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
        sub_tutorial9.gameObject.SetActive(false);
        sub_tutorial10.gameObject.SetActive(false);
        sub_tutorial11.gameObject.SetActive(false);
        sub_tutorial12.gameObject.SetActive(false);
        sub_tutorial13.gameObject.SetActive(false);
        sub_tutorial14.gameObject.SetActive(false);
        sub_tutorial15.gameObject.SetActive(false);
        sub_tutorial16.gameObject.SetActive(false);
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
                audio_fire.Play();
                sub_tutorial8.gameObject.SetActive(true);
                break;
            case 10: //��� �μ��� ��
                OffSubtitles();
                sub_tutorial9.gameObject.SetActive(true);
                level = 11;
                break;
            case 11: //��Ḧ �� ���� �� - pot-watercollider���� ȣ��
                OffSubtitles();
                sub_tutorial10.gameObject.SetActive(true);
                break;
            case 12: //���� ��ư ����
                OffSubtitles();
                sub_tutorial11.gameObject.SetActive(true);
                break;
            case 13: //Ÿ�̸� �ȳ�, ���� �κ�
                OffSubtitles();
                sub_tutorial12.gameObject.SetActive(true);
                StartCoroutine(LevelStartDelay(14, 5.0f));
                //saveload.SaveGame();
                break;
            case 14://���� ���� �ܰ�
                OffSubtitles();
                sub_timer.gameObject.SetActive(true);
                waterrender.material.color = new Color(1, 0.45f, 0, 0.745f);
                start_timer = true;
                break;
            case 15: //����
                OffSubtitles();
                sub_tutorial13.gameObject.SetActive(true);
                sub_timer.gameObject.SetActive(false);
                //saveload.LoadGame();
                LevelStart(13);
                break;
            case 16: //������
                OffSubtitles();
                sub_tutorial14.gameObject.SetActive(true);
                sub_timer.gameObject.SetActive(false);
                //saveload.LoadGame();
                LevelStart(13);
                break;
            case 17: //����� ����!
                OffSubtitles();
                sub_timer.gameObject.SetActive(false);
                audio_good.Play();
                sub_tutorial15.gameObject.SetActive(true);
                StartCoroutine(LevelStartDelay(18, 5.0f));
                break;
            case 18:
                OffSubtitles();
                sub_tutorial16.gameObject.SetActive(true);
                StartCoroutine(nameof(Rate));
                
                break;
        }
    }

    IEnumerator Rate()
    {
        foreach (var rate in cook.GetRating())
        {
            sub_tutorial16.textpro.text = rate;
            yield return new WaitForSeconds(3.0f);
        }
        yield return null;
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
        if (!all_ok)
        {
            if (inductionButton.IsPress() && level >= 11 && potInteraction.isPotOnInduction)
            {
                all_ok = true;
                LevelStart(13);
            }
        }
        if(start_timer)
        {
            sub_timer.textpro.text = timer.ToString();
            if (!inductionButton.IsPress())
            {
                start_timer = false;
                timer = maxTime;
                end = true;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        if (end)
        {
            if (timer <= minTime)
            {
                LevelStart(15);
            }
            else if (timer > minTime && timer <= maxTime)
            {
                LevelStart(17);
            }
            else
            {
                LevelStart(16);
            }
        }
    }
}
