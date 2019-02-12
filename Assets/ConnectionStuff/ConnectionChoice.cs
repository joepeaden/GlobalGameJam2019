using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionChoice : MonoBehaviour
{
	public GameObject connection;
	public GameObject connectionDialog;

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			// change player input mode for interaction
			GMScript.interactionMode = GMScript.InteractionMode.Connection;
			connectionDialog.SetActive(true);
			Destroy(GetComponent<Collider2D>());
			GMScript.activeConnectionChoice = this;
			Time.timeScale = 0;
		}
	}
}