using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickUp : MonoBehaviour {

	public int CoinsToAdd;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<PlatformerInput> () == null)
		
			return;
		
		CoinsManager.AddCoins (CoinsToAdd);
		Destroy (gameObject);


}
}
