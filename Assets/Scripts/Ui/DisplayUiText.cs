using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayUiText : MonoBehaviour
{
    [SerializeField]
    private IntVariable playersInRoom;
    [SerializeField]
    private IntVariable timer;
    [SerializeField]
    private IntVariable playerHp;
    [SerializeField]
    private IntVariable opponentHp;
    [SerializeField]
    private IntVariable protectScore;
    [SerializeField]
    private IntVariable attackScore;

    [SerializeField]
    private GameObject waitingPanel;
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private TMP_Text playerHpText;
    [SerializeField]
    private TMP_Text opponentHpText;
    [SerializeField]
    private TMP_Text protectScoreText;
    [SerializeField]
    private TMP_Text attackScoreText;

    void Update()
    {
        if(playersInRoom.value == 2)
        {
            waitingPanel.SetActive(false);
        }
        else
        {
            waitingPanel.SetActive(true);
        }
        if (timer.value >= 10)
            timerText.text = "00:" + timer.value.ToString();
        if (timer.value < 10)
            timerText.text = "00:0" + timer.value.ToString();
        playerHpText.text = playerHp.value.ToString();
        opponentHpText.text = opponentHp.value.ToString();
        protectScoreText.text = protectScore.value.ToString();
        attackScoreText.text = attackScore.value.ToString();
    }
}
