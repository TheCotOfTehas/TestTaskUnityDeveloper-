using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public CardManeger CardManeger;
    public GameObject[] CardSlots;

    private void Start()
    {
        DisplayCards();
    }
    private void DisplayCards()
    {
        for (int i = 0; i < CardManeger.cards.Count; i++)
        {
            CardSlots[i].transform.GetChild(2)
                .transform.GetChild(0)
                .GetComponent<Text>().text = CardManeger.cards[i].cardName;

            CardSlots[i].transform.GetChild(3)
                .transform.GetChild(0)
                .GetComponent<Text>().text = CardManeger.cards[i].cardDes;

            //CardSlots[i].transform.GetChild(4)
            //    .transform.GetChild(0)
            //    .GetComponent<Text>().text = CardManeger.cards[i].atack.ToString();

            //CardSlots[i].transform.GetChild(5)
            //    .transform.GetChild(0)
            //    .GetComponent<Text>().text = CardManeger.cards[i].mana.ToString();

            //CardSlots[i].transform.GetChild(6)
            //    .transform.GetChild(0)
            //    .GetComponent<Text>().text = CardManeger.cards[i].Health.ToString();
        }
    }
}
