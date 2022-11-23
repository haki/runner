using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    public float xSpeed;
    public float limitX;
    private float _touchXDelta = 0;
    private float _newX = 0;

    private void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            _touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            _touchXDelta = Input.GetAxis("Mouse X");
        }
        else
        {
            _touchXDelta = 0;
        }

        _newX = transform.position.x + xSpeed * _touchXDelta * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -limitX, limitX);
        
        Vector3 newPosition = new Vector3(_newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
