using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int collectables = 0;

    [SerializeField] private Text collectablesText;
    [SerializeField] private TextMeshProUGUI randomNumbersText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            int randX;
            int randY;
            do {
            randX = Random.Range(1,9);
            randY = Random.Range(1,10);
            } while (randX + randY > 9);
            randomNumbersText.text = randX + " + " + randY + " =";
            Debug.Log("X = " + randX + ", Y = " + randY);
            Destroy(collision.gameObject);
            collectables++;
            Debug.Log("Items: " + collectables);
            collectablesText.text = "Items: " + collectables;
        }
	
	
    }
}