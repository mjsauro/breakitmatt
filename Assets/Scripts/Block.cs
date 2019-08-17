using UnityEngine;



public class Block : MonoBehaviour
{

    [SerializeField] private AudioClip breakSound;

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
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(this.gameObject);
        _level.BlockDestroyed();
    }
}
