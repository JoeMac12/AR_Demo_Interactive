using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HideUI : MonoBehaviour
{
	public TextMeshProUGUI uiText;

	private void Update()
	{
		GameObject bear = GameObject.FindWithTag("Bear");

		if (bear != null)
		{
			if (uiText != null)
			{
				uiText.gameObject.SetActive(false);
			}
		}
		else
		{
			if (uiText != null)
			{
				uiText.gameObject.SetActive(true);
			}
		}
	}
}
