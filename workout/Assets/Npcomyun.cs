using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]

public class Npcomyun : MonoBehaviour
{
	[SerializeField]
	private string message = "";
	[SerializeField]
	Flowchart flowchart;

	private bool isTarking = false;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("当たったよ");
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("始まるよ");
			StartCoroutine(Talk());
		}
	}

	IEnumerator Talk()
	{
		if (isTarking)
		{
			yield break;
		}

		isTarking = true;
		flowchart.SendFungusMessage(message);
		yield return new WaitUntil(() => flowchart.GetExecutingBlocks().Count == 0);

		isTarking = false;
	}
}
