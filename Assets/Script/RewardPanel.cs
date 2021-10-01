using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class RewardPanel : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private Text objectText;
    [SerializeField] private Text goalPointText;
    [SerializeField] private string goalTitle;
    [SerializeField] private Slider slider;
    [SerializeField] private int goalIndex;
    [SerializeField] private int[] goalPoint;
    public bool[] checkReward;
    public bool isEarth;
    int i = 0;
    private void Start()
    {
        if (!isEarth)
        {
            for (int i = 0; i < 5; i++)
            {
                Check();
            }
        }
        else
        {
            CheckEarth();
        }
    }
    private void OnEnable()
    {
        StartCoroutine(CheckCor());
    }
    private IEnumerator CheckCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!isEarth)
            {
                Check();
            }
            else
            {
                CheckEarth();
            }
        }
    }
    public void Check()
    {
        levelText.text = string.Format("{0}/5",i);
        objectText.text = string.Format("목표 : {0}", goalTitle);
        goalPointText.text = string.Format("{0} 이상",goalPoint[i]);
        if (goalIndex == 0 && i < 5)//총 클릭수
        {
            slider.value = (float)GameManager.Instance.CurrentUser.totalClick / goalPoint[i];
            if (GameManager.Instance.CurrentUser.totalClick > goalPoint[i])
            {
                checkReward[i] = true;
                i++;
            }
        }
        if (goalIndex == 1 && i < 5)//총 얻은수
        {
            slider.value = (float)GameManager.Instance.CurrentUser.totalGetElectric / goalPoint[i];
            if (GameManager.Instance.CurrentUser.totalGetElectric > goalPoint[i])
            {
                checkReward[i] = true;
                i++;
            }
        }
        if (goalIndex == 2 && i < 5)//총 터진 자동차수
        {
            slider.value = (float)GameManager.Instance.CurrentUser.totalCarClick / goalPoint[i];
            if (GameManager.Instance.CurrentUser.totalCarClick > goalPoint[i])
            {
                checkReward[i] = true;
                i++;
            }
        }
        if (goalIndex == 3 && i < 5)//총 자동차로 얻은 수
        {
            slider.value = (float)GameManager.Instance.CurrentUser.totalStilElectric / goalPoint[i];
            if (GameManager.Instance.CurrentUser.totalStilElectric > goalPoint[i])
            {
                checkReward[i] = true;
                i++;
            }
        }
    }
    public void CheckEarth()
    {
        if(goalIndex == 0)
        {
            if(GameManager.Instance.CurrentUser.earthLevel > 5)
            {
                checkReward[0] = true;
                objectText.gameObject.SetActive(true);
            }
        }
        if(goalIndex == 1)
        {
            if (GameManager.Instance.CurrentUser.earthLevel > 11)
            {
                checkReward[0] = true;
                objectText.gameObject.SetActive(true);
            }
        }
    }
}