using UnityEngine;

public class BodyPartSelectionOnline : MonoBehaviour
{
    private PlayerOnline player;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject checkMark;
    public bool picked;
    private void Start()
    {
        player = GetComponentInParent<PlayerOnline>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (!picked)
        {
           
            if (player.MaxProtected > 0)
            {
                picked = true;
                Color color = new Color32(0, 166, 29, 255);
                spriteRenderer.color = color;
                checkMark.SetActive(true);
                int index = int.Parse(gameObject.name);
                player.ProtectBodyPart(index);
            }
            
        }
        else
        {
            picked = false;
            Color color = new Color32(0, 255, 43, 134);
            spriteRenderer.color = color;
            checkMark.SetActive(false);
            int index = int.Parse(gameObject.name);
            player.ProtectBodyPart(index);
        }
        


    }
}
