using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Grrr scary bear sound

public class RandomSoundPlayer : MonoBehaviour
{
	public AudioSource audioSource;

	public float minInterval = 8f;
	public float maxInterval = 16f;

	private void Start()
	{
		StartCoroutine(PlaySoundAtRandomIntervals());
	}

	private IEnumerator PlaySoundAtRandomIntervals()
	{
		while (true)
		{
			float waitTime = Random.Range(minInterval, maxInterval);
			yield return new WaitForSeconds(waitTime);

			if (audioSource != null && audioSource.clip != null)
			{
				audioSource.Play();
			}
		}
	}
}
