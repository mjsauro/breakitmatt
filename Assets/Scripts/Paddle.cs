using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Paddle : MonoBehaviour
{

    // configuration parameters
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float screenWidthInUnits = 16f;

    // cached references
    private GameSession _gameSession;
    private Ball _ball;

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
    }
    
    private void Update()
    {
        if (_ball != null)
        {
            Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y)
            {
                x = Mathf.Clamp(GetXPos(), minX, maxX)
            };

            transform.position = paddlePosition;
        }
    }

    private float GetXPos()
    {
        if (_gameSession.IsAutoPlayEnabled())
        {
            return _ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
