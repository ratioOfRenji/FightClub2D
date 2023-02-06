using System.Collections;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class TestPlayer : MonoBehaviour
{
    public TMP_Text playersAttacksText;
    public TMP_Text playersProtectedText;


    public IntArray playersAttacks;
    public BoolArray playersProtectedParts;

    public void SendHPAndProtectionData()
    {
        PhotonView photonView = GetComponent<PhotonView>();
        photonView.RPC("ReceiveHPAndProtectionData", RpcTarget.Others, playersAttacks.value, playersProtectedParts.value);
    }

    private void Start()
    {
        playersProtectedParts.value = GenerateRandomBoolArray();
        playersAttacks.value = GenerateRandomIntArray();
        string arrayAsString = string.Join(", ", playersAttacks.value);
        playersAttacksText.text = arrayAsString;
        string arrayAsaString = string.Join(", ", playersProtectedParts.value);
        playersProtectedText.text = arrayAsaString;
        StartCoroutine(sendData());
    }
    IEnumerator sendData()
    {
        yield return new WaitForSeconds(5);
        SendHPAndProtectionData();
        StartCoroutine(sendData());
    }
    private void Update()
    {
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log("Number of players in the room: " + playerCount);
    }
    public bool[] GenerateRandomBoolArray()
    {
        bool[] array = new bool[8];
        int points = 4;
        int randomIndex;

        while (points > 0)
        {
            randomIndex = UnityEngine.Random.Range(0, 8);
            if (!array[randomIndex])
            {
                array[randomIndex] = true;
                points--;
            }
        }

        return array;
    }


    public int[] GenerateRandomIntArray()
    {
        int[] array = new int[8];
        int points = 4;
        int randomIndex;

        while (points > 0)
        {
            randomIndex = UnityEngine.Random.Range(0, 8);
           
                array[randomIndex]++;
                points--;
        }

        return array;
    }
}
