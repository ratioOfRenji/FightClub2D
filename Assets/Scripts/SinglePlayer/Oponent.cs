using UnityEngine;

public class Oponent : MonoBehaviour
{
    [SerializeField]
    private int attacksRemained = 4;

    [SerializeField]
    private int opponentsHealth = 10;

    public int AttacksRemained { get { return attacksRemained; } }
    public int OpponentsHealth { get { return opponentsHealth; } set { opponentsHealth = value; } }

    public int[] zonesToAttack;
    public bool[] zonesToDefence;
    private void Start()
    {
        zonesToAttack = new int[8];
        zonesToDefence = GenerateRandomArray();
    }

    public void MakeAttack(int index)
    {
        if (attacksRemained > 0)
        {
            zonesToAttack[index] ++;
            attacksRemained--;
        }
    }
    public void CancelAttack(int index)
    {
        zonesToAttack[index]--;
        attacksRemained++;
    }
    public bool[] GenerateRandomArray()
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
}
