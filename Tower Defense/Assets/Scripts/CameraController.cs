using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;

	public float scrollSpeed = 5f;
	public float minY = 10f;
	public float maxY = 80f;
	public float minx = 10f;
	public float maxx = 80f;
public float minz = 10f;
	public float maxz = 80f;


	// Update is called once per frame
	void Update () {

		if (GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}
		if(Input.GetMouseButton(0))
	{
		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
		{
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}
		}
		Vector3 pos = transform.position;
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		 pos.z = Mathf.Clamp(pos.z, minz, maxz);
		pos.x = Mathf.Clamp(pos.x, minx, maxx);
		
		

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		
		transform.position = pos;
		
	}
}
