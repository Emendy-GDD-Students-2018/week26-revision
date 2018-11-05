using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Example for Obi
/// We have a set of sprites and when the player reaches a health threshold, we change the image
/// 
/// We do this by getting a Normalised (0.0 to 1.0) quotient of current over max health
/// 
///
/// </summary>
public class HealthUI : MonoBehaviour
{
	public Image healthImage;

	public Sprite[] healthSprites;

	public int maxHealth, currentHealth;


	//private void Start()
	//{
	//	maxHealth = 5;
	//	currentHealth = 5;
	//	UpdateHealthImage();
	//}

	/// <summary>
	///  We take that normalised value and multiply it by the number of sprites, then round off that number to get an index (offset it by 1 as well)
	///  
	/// Set the Image component sprite to the sprite at the calculated index.
	/// 
	/// Prevent Out of Range exceptions by checking that the index doesn't fall below 0
	/// </summary>
	public void UpdateHealthImage()
	{
		float normalisedHealth = (float)currentHealth / (float)maxHealth;

		int spriteIndex = Mathf.RoundToInt(normalisedHealth * (float)healthSprites.Length) - 1;
		if (spriteIndex >= 0)
		{
			healthImage.sprite = healthSprites[spriteIndex];
		}
		else
		{
			Debug.LogFormat("<color=#c0ffee>You Can't Die More than this</color>");
		}
	}

	//private void Update()
	//{
	//	if (Input.GetKeyDown(KeyCode.Space) && currentHealth > 0)
	//	{
	//		currentHealth--;
	//		UpdateHealthImage();
	//	}
	//}

}
