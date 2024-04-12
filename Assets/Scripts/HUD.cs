using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, HpSlider, HpText }
    public InfoType type;

    Text playerText;
    Slider playerSlider;

    float curExp;
    float maxExp;
    float curHp;
    float maxHp;
    float remainTime;

    private void Awake()
    {
        playerText = GetComponent<Text>();
        playerSlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                curExp = GameManager.Instance.exp;
                maxExp = GameManager.Instance.nextExp[Mathf.Min(GameManager.Instance.level, GameManager.Instance.nextExp.Length - 1)];
                playerSlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                playerText.text = string.Format("Lv.{0:F0}", GameManager.Instance.level);
                break;
            case InfoType.Kill:
                playerText.text = string.Format("Kill:{0:F0}", GameManager.Instance.kill);
                break;
            case InfoType.Time:
                remainTime = GameManager.Instance.maxGameTime - GameManager.Instance.gameTime;
                int minute = Mathf.FloorToInt(remainTime / 60);
                int second = Mathf.FloorToInt(remainTime % 60);
                playerText.text = string.Format("{0:D2}:{1:D2}", minute, second);
                break;
            case InfoType.HpSlider:
                curHp = GameManager.Instance.curHp;
                maxHp = GameManager.Instance.maxHp;
                playerSlider.value = curHp / maxHp;
                break;
            case InfoType.HpText:
                curHp = GameManager.Instance.curHp;
                maxHp = GameManager.Instance.maxHp;
                playerText.text = string.Format("{0}/{1}", curHp, maxHp);
                break;
        }
    }
}
