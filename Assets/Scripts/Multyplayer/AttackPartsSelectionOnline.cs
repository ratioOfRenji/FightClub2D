using UnityEngine;
using TMPro;

public class AttackPartsSelectionOnline : MonoBehaviour
{
    private OpponentOnline opponent;
    private SpriteRenderer spriteRenderer;
    private int count = 0;
    [SerializeField]
    private TMP_Text counter;

    private void Start()
    {
        opponent = GetComponentInParent<OpponentOnline>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (opponent.AttacksRemained > 0)
        {
            Color color = new Color32(0, 166, 29, 255);
            spriteRenderer.color = color;
            counter.gameObject.SetActive(true);
            count++;
            counter.text = count.ToString();
            int index = int.Parse(gameObject.name);
            opponent.MakeAttack(index);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject == gameObject)
            {
                if (count > 0)
                {
                    count--;
                    counter.text = count.ToString();
                    int index = int.Parse(gameObject.name);
                    opponent.CancelAttack(index);
                    if (count == 0)
                    {
                        Color color = new Color32(0, 255, 43, 134);
                        spriteRenderer.color = color;
                        counter.gameObject.SetActive(false);
                    }
                }

            }
        }
    }
}


