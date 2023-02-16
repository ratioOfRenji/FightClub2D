using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneManagment : MonoBehaviour
{
    [SerializeField]
    private IntVariable PlayerHp;
    [SerializeField]
    private IntVariable OponentHp;
    [SerializeField]
    private IntVariable PlayersInRoom;
    [SerializeField]
    private GameObject drawUi;
    [SerializeField]
    private GameObject winUi;
    [SerializeField]
    private GameObject loseUi;
    [SerializeField]
    private GameObject timertext;
    bool readyToStart = false;

    void Start()
    {
        FightState.OnNextFightLoop += ReloadBattleSceneMultyplayer;
    }

    private void OnDisable()
    {
        FightState.OnNextFightLoop -= ReloadBattleSceneMultyplayer;
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MultiplayerScene")
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && !readyToStart)
            {
                //waitingUi.SetActive(false);
                //StartCoroutine(countdown());
                readyToStart = true;
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
            }
            PlayersInRoom.value = PhotonNetwork.CurrentRoom.PlayerCount;
        }
        if(PlayerHp.value<=0 || OponentHp.value <= 0)
        {
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
            timertext.SetActive(false);
        }
    }
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
            timertext.SetActive(false);
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
