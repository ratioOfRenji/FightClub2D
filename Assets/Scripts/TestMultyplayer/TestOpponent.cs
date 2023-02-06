using UnityEngine;
using Photon.Pun;
using TMPro;
public class TestOpponent : MonoBehaviour
{
    public int opponentHp;
    public TMP_Text opponentAttackstext;
    public TMP_Text opponentProtectedtext;

    public IntArray opponentsAttacks;
    public BoolArray opponentsProtectedParts;

    [PunRPC]
    public void ReceiveHPAndProtectionData(int[] receivedAttacks, bool[] receivedProtectedParts)
    {
        opponentsAttacks.value = receivedAttacks;
        opponentsProtectedParts.value = receivedProtectedParts;
        string arrayAsString = string.Join(", ", opponentsAttacks.value);
        opponentAttackstext.text = arrayAsString.ToString();
        string arrayAsaString = string.Join(", ", opponentsProtectedParts.value);
        opponentProtectedtext.text = arrayAsaString.ToString();
    }
}
