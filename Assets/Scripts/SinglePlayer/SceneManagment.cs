using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneManagment : MonoBehaviour
{
    public Hp PlayerHp;
    public Hp OponentHp;
    public GameObject drawUi;
    public GameObject winUi;
    public GameObject loseUi;
    public GameObject timertext;
    public void LoadMenuScene()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }
    public void LoadBattleSceneMultyplayer()
    {
        OponentHp.value = 10;
        PlayerHp.value = 10;
        SceneManager.LoadScene(3);
    }
    public void LoadBattleScene()
    {
        OponentHp.value = 10;
        PlayerHp.value = 10;
        SceneManager.LoadScene(2);
    }
    public void ReloadBattleSceneMultyplayer()
    {
        if(PlayerHp.value >0 &&OponentHp.value > 0)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            timertext.SetActive(false);
            if (PlayerHp.value <= 0 && OponentHp.value <=0)
            {
                drawUi.SetActive(true);
                return;
            }
            if(PlayerHp.value<= 0)
            {
                loseUi.SetActive(true);
                return;
            }
            if(OponentHp.value <= 0)
            {
                winUi.SetActive(true);
                return;
            }
        }
        
    }
    public void ReloadBattleScene()
    {
        if (PlayerHp.value > 0 && OponentHp.value > 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            timertext.SetActive(false);
            if (PlayerHp.value <= 0 && OponentHp.value <= 0)
            {
                drawUi.SetActive(true);
                return;
            }
            if (PlayerHp.value <= 0)
            {
                loseUi.SetActive(true);
                return;
            }
            if (OponentHp.value <= 0)
            {
                winUi.SetActive(true);
                return;
            }
        }

    }
}
