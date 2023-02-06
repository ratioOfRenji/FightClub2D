using UnityEngine;
using Photon.Pun;
using TMPro;
public class RecieveData : MonoBehaviour
{
    public int opponentHp;
    public TMP_Text opponentAttackstext;
    public TMP_Text opponentProtectedtext;

    public IntArray opponentsAttacks;
    public BoolArray opponentsProtectedParts;
    public BoolVariable opponentsBool;


    [PunRPC]
    public void ReceiveHPAndProtectionData(int[] receivedAttacks, bool[] receivedProtectedParts, bool readyToStartFight)
    {
        opponentsAttacks.value = receivedAttacks;
        opponentsProtectedParts.value = receivedProtectedParts;
        opponentsBool.value = readyToStartFight;
    }
}
