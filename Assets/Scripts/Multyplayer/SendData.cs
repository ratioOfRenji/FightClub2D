using UnityEngine;
using Photon.Pun;

public class SendData : MonoBehaviour
{

    public IntArray playersAttacks;
    public BoolArray playersProtectedParts;
    public BoolVariable playersBool;
    public void SendHPAndProtectionData()
    {
        playersBool.value = true;
        PhotonView photonView = GetComponent<PhotonView>();
        photonView.RPC("ReceiveHPAndProtectionData", RpcTarget.Others, playersAttacks.value, playersProtectedParts.value, playersBool.value);
    }
}
