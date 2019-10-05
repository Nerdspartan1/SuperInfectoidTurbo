using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    private Vector2 _parallax;
    private Vector3 _initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _parallax = -GameManager.instance.camera.transform.position * Mathf.Pow(transform.position.z, 3) / GameManager.instance.parallaxFactor;
        transform.position = _initialPosition + new Vector3(_parallax.x, _parallax.y, 0);
    }
}
