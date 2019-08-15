using UnityEngine;

public class Paddle : MonoBehaviour {

	[SerializeField] private float screenWidthInUnits = 16f;
	

	// Update is called once per frame
	private void Update () {

		float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits; 

		Vector2 paddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
		transform.position = paddlePosition;


	}
}
