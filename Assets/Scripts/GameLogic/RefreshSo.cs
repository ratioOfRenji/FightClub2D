using UnityEngine;
using UnityEngine.SceneManagement;

public class RefreshSo : MonoBehaviour
{
    [SerializeField]
    private IntVariable PlayersInRoom;
    [SerializeField]
    private IntVariable protectScore;
    [SerializeField]
    private IntVariable attackScore;
    [SerializeField]
    private IntVariable playersHp;
    [SerializeField]
    private IntVariable OpponentHp;
    [SerializeField]
    private IntVariable timer;
    [SerializeField]
    private BoolVariable playersBool;
    [SerializeField]
    private BoolVariable opponentsBool;
    [SerializeField]
    private BoolVariable animationPlayed;
    [SerializeField]
    private BoolArray playerProtectedParts;
    [SerializeField]
    private BoolArray opponentsProtectedParts;
    [SerializeField]
    private IntArray playersAttacks;
    [SerializeField]
    private IntArray opponentsAttacks;
    

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "MultiplayerScene")
        {
            playersHp.value = 10;
            OpponentHp.value = 10;
        }
        timer.value = 15;
        protectScore.value = 4;
        attackScore.value = 4;
        PlayersInRoom.value = 0;
        playersBool.value = false;
        opponentsBool.value = false;
        animationPlayed.value = false;
        playerProtectedParts.value = new bool[8];
        opponentsProtectedParts.value = new bool[8];
        playersAttacks.value = new int[8];
        opponentsAttacks.value = new int[8];

    }
}
