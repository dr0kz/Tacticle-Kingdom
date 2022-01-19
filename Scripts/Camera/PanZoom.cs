using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanZoom : MonoBehaviour
{
    [SerializeField] Transform CameraLeftLimit;
    [SerializeField] Transform CameraRightLimit;
    private float cameraSpeed = 23f;
    [SerializeField] Transform RectPosUp;
    public Texture image;
    public Rect notouchable_area;
    private Camera cam;
    //Vector3 touchStart;
    //private float yAxis;
    /*
    void Start()
    {
    yAxis = transform.position.y; //the Y-Axis of the Main Camera
    }

void Update() //Pan move ( with touch and mouse )
{
        if (Input.GetMouseButtonDown(0)) // When we touch the screen
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        if (Input.GetMouseButton(0)) // While we touch the screen
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.y = yAxis; //We dont want to move the camera by Y-Axis 
            if ((transform.position.x > CameraLeftLimit.position.x || direction.x > 0) && (transform.position.x < CameraRightLimit.position.x || direction.x < 0))
            {
                Camera.main.transform.position += direction;
            }
        }
}
*/
    void Start()
    {
        cam = GetComponent<Camera>();
        //Vector3 screenPos = cam.WorldToScreenPoint(RectPosUp.position);
        // notouchable_area = new Rect(0,0, Screen.width, Screen.height- screenPos.y);
        //notouchable_area = new Rect(RectPos.position.x, RectPos.position.y, Screen.width, RectPosUp.position.y-RectPos.position.y);
    }
    
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)&& transform.position.x > CameraLeftLimit.position.x)
        {
            transform.Translate(Vector2.left * cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow)&& transform.position.x < CameraRightLimit.position.x)
        {
            transform.Translate(Vector2.right * cameraSpeed * Time.deltaTime);
        }
    }
    /*
    void Update() //Movement Left,Right with touch
    {
        Vector3 screenPos = cam.WorldToScreenPoint(RectPosUp.position);
        notouchable_area = new Rect(0, 0, Screen.width, Screen.height - screenPos.y);
        if (GameManager.GameOver == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (!notouchable_area.Contains(new Vector2(touch.position.x, Screen.height - touch.position.y)))
                {
                    if (touch.position.x >= Screen.width / 2 && transform.position.x < CameraRightLimit.position.x)
                    {
                        transform.Translate(Vector2.right * cameraSpeed * Time.deltaTime);
                    }
                    else if (touch.position.x < Screen.width / 2 && transform.position.x > CameraLeftLimit.position.x)
                    {
                        transform.Translate(Vector2.left * cameraSpeed * Time.deltaTime);
                    }
                }
            }
        }
    }

    */



    /*
void OnGUI()
{
    GUI.Box(notouchable_area, image);
}
*/
}
