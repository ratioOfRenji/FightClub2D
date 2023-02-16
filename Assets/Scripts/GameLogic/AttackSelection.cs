using TMPro;
using UnityEngine;

public class AttackSelection : SelectionTab
{
    private OpponentSelector opponent;
    private SpriteRenderer spriteRenderer;
    private int count = 0;
    [SerializeField]
    private TMP_Text counter;
    [SerializeField]
    private IntVariable attackScore;

    private void Start()
    {
        opponent = GetComponentInParent<OpponentSelector>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        MakeSelection();
    }
    private void Update()
    {
        CancelSelection();
    }
    public override void MakeSelection()
    {
        if (attackScore.value > 0)
        {
            Color color = new Color32(0, 166, 29, 255);
            spriteRenderer.color = color;
            counter.gameObject.SetActive(true);
            count++;
            counter.text = count.ToString();
            int index = int.Parse(gameObject.name);
            opponent.SelectPart(index);
        }
    }

    public override void CancelSelection()
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
                    opponent.UnSelectPart(index);
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
