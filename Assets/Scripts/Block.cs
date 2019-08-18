using UnityEngine;



public class Block : MonoBehaviour
{

    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparkleVFX;

    //cached reference
    private Level _level;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(this.gameObject);
        _level.BlockDestroyed();
        TriggerSparklesVFX();

    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
