using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RewardManager : MonoBehaviour
{
    [SerializeField] private Image[] rewardImage;
    [SerializeField] private RewardPanel[] rewardPanel;
    [SerializeField] private SpriteArr[] rewardSprit;
    void Start()
    {
        Check();
        StartCoroutine(CheckCor());
    }
    public IEnumerator CheckCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Check();
        }
    }
    public void Check()
    {
        for(int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (!rewardPanel[i].isEarth)
                {
                    if (rewardPanel[i].checkReward[j])
                    {
                        rewardImage[i].sprite = rewardSprit[i].sprites[j];
                    }
                }
                else
                {
                    if (rewardPanel[i].checkReward[0])
                    {
                        rewardImage[i].sprite = rewardSprit[i].sprites[0];
                    }
                }
            }
        }
    }
}
