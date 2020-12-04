using UnityEngine;
using UnityEngine.SceneManagement;

public class Comyunication : MonoBehaviour
{
	private void OnTriggerStay(UnityEngine.Collider other)
	{
		Debug.Log("入ったよ");
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene("会話シーン");
		}
	}
}
