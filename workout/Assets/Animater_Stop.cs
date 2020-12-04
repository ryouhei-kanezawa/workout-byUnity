using UnityEngine;

public class Animater_Stop : MonoBehaviour
{
	GameObject unitychan;
	UnityChanAnimationTest script;

	private void Start()
	{
		unitychan = GameObject.Find("SD_unitychan_humanoid");
		script = unitychan.GetComponent<UnityChanAnimationTest>();
	}

	private void OnTriggerStay(Collider other)
	{
		//Debug.Log("入ってるよ");
		script.animater_switch = false;
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("出たよ");
		script.animater_switch = true;
	}
}
