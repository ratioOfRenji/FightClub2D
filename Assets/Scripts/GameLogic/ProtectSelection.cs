using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectSelection : SelectionTab
{
    private PlayerSelector player;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject checkMark;
    [SerializeField]
    private IntVariable protectedScore;
    [SerializeField]
    private bool picked;
    private void Start()
    {
        player = GetComponentInParent<PlayerSelector>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (!picked)
        {
            MakeSelection();
        }
        else
        {
            CancelSelection();
        }
    }

    public override void MakeSelection()
    {
        if (protectedScore.value > 0)
        {
            picked = true;
            Color color = new Color32(0, 166, 29, 255);
            spriteRenderer.color = color;
            checkMark.SetActive(true);
            int index = int.Parse(gameObject.name);
            player.SelectPart(index);
        }
    }

    public override void CancelSelection()
    {
        picked = false;
        Color color = new Color32(0, 255, 43, 134);
        spriteRenderer.color = color;
        checkMark.SetActive(false);
        int index = int.Parse(gameObject.name);
        player.UnSelectPart(index);
    }
}
