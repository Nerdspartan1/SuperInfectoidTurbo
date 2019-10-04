using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public Camera camera;

    private Vector2 _parallax;
    private Vector3 _previousCameraPosition;
    private Vector3 _initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        _previousCameraPosition = camera.transform.position;
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            _parallax = -camera.transform.position * (transform.position.z) / GameManager.instance.parallaxFactor;
            transform.position = _initialPosition + new Vector3(_parallax.x, _parallax.y, 0);
    }
}
