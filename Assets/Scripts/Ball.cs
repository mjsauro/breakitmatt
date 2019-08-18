using UnityEngine;

public class Ball : MonoBehaviour
{
    // configuration parameters
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;

    // state
    private Vector2 _paddleToBallVector;
    private bool _hasStarted = false;

    //cached component references
    private AudioSource _myAudioSource;

    // Use this for initialization

    void Start()
    {
        _paddleToBallVector = transform.position - paddle1.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasStarted) return;
        LockBallToPaddle();
        LaunchBallOnMouseClick();
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
        }
    }
}
