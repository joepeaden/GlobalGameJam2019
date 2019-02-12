using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionUI : MonoBehaviour
{
	public GameObject[] connectionUIArray = new GameObject[5]; 
	public bool[] connectionFullArray = new bool[5];

	public Sprite fullConnection;
	public Sprite emptyConnection;
	public Sprite fullExcessConnection;
	public Sprite emptyExcessConnection;

	public GameObject[] endSprites = new GameObject[5];

	public void UpdateConnectionUI(int n, ConnectionChoice cc)
	{
		Sprite newSprite = cc.connection.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

		//if(n < 3)
		connectionUIArray[n].GetComponent<SpriteRenderer>().sprite = newSprite;//connectionfull ui;
		//e
		//	connectionUIArray[n].GetComponent<SpriteRenderer>().sprite = fullExcessConnection;//connectionfull ui;			
		
		endSprites[n].GetComponent<Image>().sprite = newSprite;
		endSprites[n].transform.GetChild(0).GetComponent<Text>().text = cc.name;

		connectionFullArray[n] = true;
	}

	public bool IsSlotEmpty(int n)
	{
		if(connectionFullArray[n])
			return false;
		return true;

	}

}
