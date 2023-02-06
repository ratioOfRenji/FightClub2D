using UnityEngine;
using TMPro;

public class SetTextMultyplayer : MonoBehaviour
{
    public PlayerOnline player;
    public OpponentOnline opponent;

    public TMP_Text defenceScore;
    public TMP_Text atttackScore;

    void Update()
    {
        defenceScore.text = player.MaxProtected.ToString();
        atttackScore.text = opponent.AttacksRemained.ToString();
    }
}
