using UnityEngine;

public class Ball : MonoBehaviour
{
    // configuration parameters
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.3f;

    // state
    private Vector2 _paddleToBallVector;
    private bool _hasStarted = false;

    //cached component references
    private AudioSource _myAudioSource;
    private Rigidbody2D _myRigidbody2D;

    // Use this for initialization

    private void Start()
    {
        _paddleToBallVector = transform.position - paddle1.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LaunchBallOnMouseClick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _hasStarted = true;
           _myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        var paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (_hasStarted)
        {
            PlayBallSounds();
            RicochetBall();
        }
    }

    private void PlayBallSounds()
    {
        if (ballSounds != null)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
        }

    }

    private void RicochetBall()
    {
        var velocityTweak = new Vector2
        (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));
        _myRigidbody2D.velocity += velocityTweak;
    }


}
