using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCcomyu : MonoBehaviour
{
	private void OnTriggerEnter(UnityEngine.Collider other)
	{
		Debug.Log("当たったよ");
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene("会話シーン");
		}
	}
}
