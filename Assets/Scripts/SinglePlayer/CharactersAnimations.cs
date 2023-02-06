using UnityEngine;
using DG.Tweening;

public class CharactersAnimations : MonoBehaviour
{
    public Sprite[] playersSprites; //0-idle, 1-attack, 2-hit;
    public Sprite[] opponentsSprites;//0-idle, 1-attack, 2-hit;
    public Transform player;
    public Transform opponent;
    public SpriteRenderer playersRenderer;
    public SpriteRenderer opponentsRenderer;
    public Vector3 enemyInitPos = new Vector3(0, 1.42f, 0);
    public Vector3 enemyAttackPos = new Vector3(4.6f, 1.68f,0);
    public Vector3 playerInitPos = new Vector3(0, 1.42f, 0);
    public Vector3 playerAttackPos = new Vector3(4.6f, 1.68f, 0);

    public void PLayAnimations()
    {
        EnemyAnimation();
    }





    private void EnemyAnimation()
    {
        opponentsRenderer.sortingOrder += 4;
        opponentsRenderer.sprite = opponentsSprites[1];
        opponent.transform.DOMove(enemyAttackPos, .7f).OnComplete(() =>
        {
            playersRenderer.sprite = playersSprites[2];
            opponent.transform.DOMove(enemyInitPos, .7f).OnComplete(() => 
            { 
                opponentsRenderer.sprite = opponentsSprites[0];
                opponentsRenderer.sortingOrder -= 4;
                PlayersAnimation();
            });

        });
    }
    private void PlayersAnimation()
    {
        playersRenderer.sortingOrder += 4;
        playersRenderer.sprite = playersSprites[1];
        player.transform.DOMove(playerAttackPos, .7f).OnComplete(() =>
        {
            opponentsRenderer.sprite = opponentsSprites[2];
            player.transform.DOMove(playerInitPos, .7f).OnComplete(() =>
            {
                opponentsRenderer.sprite = opponentsSprites[0];
                playersRenderer.sprite = playersSprites[0];
                playersRenderer.sortingOrder -= 4;
            });

        });
    }
}
