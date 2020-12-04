using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class QuestBool : MonoBehaviour
{
	[SerializeField]
	private string message = "";
	[SerializeField]
	Flowchart flowchart;

	private bool chackBool = false;
	private bool isTarking = false;

	private void OnTriggerEnter(Collider triger)
	{
		Debug.Log("当たったよ2");
		if (triger.gameObject.CompareTag("Player"))
		{
			Debug.Log("始まるよ2");
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
