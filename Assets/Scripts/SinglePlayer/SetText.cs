using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    public Player player;
    public Oponent opponent;

    public TMP_Text defenceScore;
    public TMP_Text atttackScore;

    void Update()
    {
        defenceScore.text = player.MaxProtected.ToString();
        atttackScore.text = opponent.AttacksRemained.ToString();
    }
}
