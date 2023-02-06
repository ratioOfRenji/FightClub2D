using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxProtected = 4;

    [SerializeField]
    private int playerHealth = 10;

    public int MaxProtected { get { return maxProtected; } }
    public int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }

    public bool[] protectedParts;
    public int[] playerHitsArray;
    private void Start()
    {
        protectedParts = new bool[8];
        playerHitsArray = GenerateRandomArray();
    }

    public void ProtectBodyPart(int index)
    {
        if (!protectedParts[index] && maxProtected > 0)
        {
            protectedParts[index] = true;
            maxProtected--;
        }
        else if (protectedParts[index])
        {
            protectedParts[index] = false;
            maxProtected++;
        }
    }

    public int[] GenerateRandomArray()
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
