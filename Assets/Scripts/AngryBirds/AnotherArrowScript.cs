using UnityEngine;

public class AnotherArrowScript : MonoBehaviour
{
    [SerializeField]
    private Transform rotAnchor;
    void Start()
    {
        
    }

    void Update()
    {
        float dy = -Input.GetAxis("Vertical");
        float angle = this.transform.eulerAngles.z - 180;

        if (angle > 180)
        {
            angle -= 360;
        }

        if (-60 < angle + dy && angle + dy < 15)
        {
            this.transform.RotateAround(rotAnchor.position, Vector3.forward, dy);
        }
    }
}
