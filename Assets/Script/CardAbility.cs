using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityStat {
    public string abilityName;
    public float abilityNum;
}

public class CardAbility : MonoBehaviour
{
    [SerializeField]
    private abilityStat[] abilities;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Apply() {
        foreach (abilityStat ability in abilities) {
            ApplySingle(ability);
        }
    }

    void ApplySingle(abilityStat ability) {
        string abilityName = ability.abilityName;
        switch (abilityName) {
            case "ChangeEnergy" :
                modifyEnergy((int)ability.abilityNum);
                break;
            case "DoubleJump" :
                CharacterSystem.instance.characterController.doubleJump();
                break;
            case "Horizontal Dash" :
                CharacterSystem.instance.characterController.dash();
                break;
            case "MeleeAtk" :
                CharacterSystem.instance.melee();
                break;
            case "RangeAtk" :
                CharacterSystem.instance.shuriken();
                break;
            case "ChangeHealth" :
                modifyHealth((int)ability.abilityNum);
                break;
            case "ChangeRandomCardEnergy" :
                break;
        }

    }

    void modifyEnergy(int modifyEnergy) {
        if (CharacterSystem.instance.playerEnergy + modifyEnergy < 0) {
            CharacterSystem.instance.playerEnergy = 0;
        } else if (CharacterSystem.instance.playerEnergy + modifyEnergy > CharacterSystem.instance.maxPlayerEnergy) {
            CharacterSystem.instance.playerEnergy = CharacterSystem.instance.maxPlayerEnergy;
        } else {
            CharacterSystem.instance.playerEnergy += modifyEnergy;
        }
    }

    void modifyHealth(int modifyHealth) {
        if (CharacterSystem.instance.playerHP + modifyHealth < 0) {
            CharacterSystem.instance.playerHP = 0;
            //gameover
        } else if (CharacterSystem.instance.playerHP + modifyHealth > CharacterSystem.instance.maxPlayerHP) {
            CharacterSystem.instance.playerHP = CharacterSystem.instance.maxPlayerHP;
        } else {
            CharacterSystem.instance.playerHP += modifyHealth;
        }
    }




    
}
