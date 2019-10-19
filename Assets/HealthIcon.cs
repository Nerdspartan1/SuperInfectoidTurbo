using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIcon : MonoBehaviour
{
	public Sprite[] healthSprites;
	public Image _image;

	void Start()
	{
		_image = GetComponent<Image>();
	}

	public void UpdateIcon(int health)
	{
		_image.sprite = healthSprites[5-health];
	}
}
