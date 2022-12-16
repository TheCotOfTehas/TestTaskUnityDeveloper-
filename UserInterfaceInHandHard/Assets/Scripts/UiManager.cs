using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public CardManeger CardManeger;
    public GameObject[] CardSlots;

    private void DisplayCards()
    {
        for (int i = 0; i < CardManeger.cards.Count; i++)
        {
            CardSlots[i].transform.GetChild(3)
                .transform.GetChild(0)
                .GetComponent<Text>().text = CardManeger.cards[i].cardName;
        }
    }
}
