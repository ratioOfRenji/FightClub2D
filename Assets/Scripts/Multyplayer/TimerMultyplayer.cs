using System.Collections;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TimerMultyplayer : MonoBehaviour
{
    int tiner = 15;
    public TMP_Text timerText;
    public SceneManagment sceneManagment;
    public CalculateDamageOnline calculateDamage;
    public SendData sendData;
    public GameObject waitingUi;
    bool readyToStart = false;
    public BoolVariable playersBool;
    public BoolVariable opponentsBool;
    public GameObject startBattleButton;

    public PlayerOnline player;
    public OpponentOnline opponent;
    public CharactersAnimations animations;
    public GameObject[] objectsToHide;

    private void Update()
    {
        if (playersBool.value && opponentsBool.value)
        {
            playersBool.value = false;
            opponentsBool.value = false;
            StopAllCoroutines();
            StartCoroutine(calculate());
            startBattleButton.SetActive(false);
        }

        if (player.MaxProtected == 0 && opponent.AttacksRemained == 0)
        {
            startBattleButton.SetActive(true);
        }
        else
        {
            startBattleButton.SetActive(false);
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && !readyToStart)
        {
            waitingUi.SetActive(false);
            StartCoroutine(countdown());
            readyToStart = true;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
        }
        
    }
    public void HideUi()
    {
        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(false);
        }
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(1);
        tiner--;
        if(tiner >=10)
        timerText.text = "00:" + tiner.ToString();
        if(tiner<10)
        timerText.text = "00:0" + tiner.ToString();
        if (tiner == 0)
        {
            sendData.SendHPAndProtectionData();
            StartCoroutine(calculate());
        }
        else
        {
            StartCoroutine(countdown());
        }
        
    }
    IEnumerator calculate()
    {
        HideUi();
        timerText.text = "расчет урона...";
        yield return new WaitForSeconds(1);
        animations.PLayAnimations();
        yield return new WaitForSeconds(2.8f);
        calculateDamage.Calclate();
        sceneManagment.ReloadBattleSceneMultyplayer();
    }
}
