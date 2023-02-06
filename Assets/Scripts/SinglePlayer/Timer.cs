using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    int tiner = 15;
    public TMP_Text timerText;
    public SceneManagment sceneManagment;
    public CalculateDamage calculateDamage;
    public GameObject waitingUi;
    public GameObject startBattleButton;

    public Player player;
    public Oponent opponent;
    public CharactersAnimations animations;
    public GameObject[] objectsToHide;
    private void Start()
    {
        StartCoroutine(countdown());
    }
    public void Calculate()
    {
        StopAllCoroutines();
        StartCoroutine(calculate());
    }
    private void Update()
    {
        if (player.MaxProtected == 0 && opponent.AttacksRemained == 0)
        {
            startBattleButton.SetActive(true);
        }
        else
        {
            startBattleButton.SetActive(false);
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
        if (tiner >= 10)
            timerText.text = "00:" + tiner.ToString();
        if (tiner < 10)
            timerText.text = "00:0" + tiner.ToString();
        if (tiner == 0)
        {
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
        calculateDamage.CalculatePlayersDamage();
        calculateDamage.CalculateOpponentDamage();
        sceneManagment.ReloadBattleScene();
    }
}
