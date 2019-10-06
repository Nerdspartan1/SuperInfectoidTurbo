using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Sprite[] figures;

	public Image[] images;

	public void UpdateScore(int score)
    {
		for (int i=0; i<images.Length; i++ )
		{
			float pow10 = Mathf.Pow(10, i);
			int f = (int)((float)score / pow10) % 10;
			images[i].sprite = figures[f];
		}
    }
}
