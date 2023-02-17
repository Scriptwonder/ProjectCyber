using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;
    public int energyCost;
    public CardAbility ability;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayCard() {
        if (energyCost > CharacterSystem.instance.playerEnergy) {
            Debug.Log("Not enough mana for " + cardName);
            return;
        }
        CharacterSystem.instance.playerEnergy -= energyCost;

        if (ability != null) {
            ability.Apply();
        }
    }

    
}
