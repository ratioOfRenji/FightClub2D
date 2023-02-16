using UnityEngine;
using Photon.Pun;
using TMPro;
public class RecieveData : MonoBehaviour
{
    [SerializeField]
    private IntArray opponentsAttacks;
    [SerializeField]
    private BoolArray opponentsProtectedParts;
    [SerializeField]
    private BoolVariable opponentsBool;


    [PunRPC]
    public void ReceiveHPAndProtectionData(int[] receivedAttacks, bool[] receivedProtectedParts, bool readyToStartFight)
    {
        opponentsAttacks.value = receivedAttacks;
        opponentsProtectedParts.value = receivedProtectedParts;
        opponentsBool.value = readyToStartFight;
    }
}
