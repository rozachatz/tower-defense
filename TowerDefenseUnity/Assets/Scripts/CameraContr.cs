
using UnityEngine;

public class CameraContr : MonoBehaviour
{
    public float panSpeed = 30f;
    // Update is called once per frame
    private bool doMovement = true;
    public float panBoarderThickness = 10f;
    public float scrollspeed = 5f;

    public float minY = 5f;
    public float maxY = 20; //limits
    void Update()
    {
        if (GameOver.gameover)
        {
            this.enabled = false;
            return;
        }


        if (Input.GetKey("z")) doMovement = !doMovement; //hit escape for enabling/disabling camera movement
        if (!doMovement) return; //false, do not move camera

        //move camera
        if (Input.GetKey("up") ) //within 10 pixels of top of screen
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //new Vector(0f,0f,1)*panSpeed, ignore rotation of camera
        }
        if (Input.GetKey("down")) //within 10 pixels (starting from below)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); //new Vector(0f,0f,1)*panSpeed, ignore rotation of camera
        }
        //move right
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); //new Vector(0f,0f,1)*panSpeed, ignore rotation of camera
        }
        //move left
        if (Input.GetKey("left") )
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); //new Vector(0f,0f,1)*panSpeed, ignore rotation of camera
        }

        //zoom in/out
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;//cur pos
        pos.y -= scroll * 100 * scrollspeed * Time.deltaTime;//multiply by a scaling factor
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos; //update pos
    }
}
