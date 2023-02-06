using UnityEngine;
using UnityEngine.SceneManagement;

public class RefreshSo : MonoBehaviour
{
    public Hp playersHp;
    public Hp OpponentHp;
    public BoolVariable playersBool;
    public BoolVariable opponentsBool;
    public BoolArray playerProtectedParts;
    public BoolArray opponentsProtectedParts;
    public IntArray playersAttacks;
    public IntArray opponentsAttacks;

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "MultiplayerScene")
        {
            playersHp.value = 10;
            OpponentHp.value = 10;
        }
        playersBool.value = false;
        opponentsBool.value = false;
        playerProtectedParts.value = new bool[8];
        opponentsProtectedParts.value = new bool[8];
        playersAttacks.value = new int[8];
        opponentsAttacks.value = new int[8];

    }
}
