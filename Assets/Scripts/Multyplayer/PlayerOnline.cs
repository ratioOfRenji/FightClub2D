using UnityEngine;
using Photon.Pun;

public class PlayerOnline : MonoBehaviourPun
{
    [SerializeField]
    private int maxProtected = 4;

    [SerializeField]
    private int playerHealth = 10;

    public int MaxProtected { get { return maxProtected; } }
    public int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }

    public BoolArray playerProtectedParts;

    private void Start()
    {
        playerProtectedParts.value = new bool[8];
    }

    public void ProtectBodyPart(int index)
    {
        if (!playerProtectedParts.value[index] && maxProtected > 0)
        {
            playerProtectedParts.value[index] = true;
            maxProtected--;
        }
        else if (playerProtectedParts.value[index])
        {
            playerProtectedParts.value[index] = false;
            maxProtected++;
        }

    }
}
