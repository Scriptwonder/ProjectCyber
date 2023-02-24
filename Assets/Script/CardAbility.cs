using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AbilityStat
{
    public string aName;
    public float aNum;
}

public class CardAbility : MonoBehaviour
{
    [SerializeField]
    private List<AbilityStat> abilities;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Apply()
    {
        foreach (AbilityStat ability in abilities)
        {
            ApplySingle(ability);
        }
    }

    void ApplySingle(AbilityStat ability)
    {
        string abilityName = ability.aName;
        switch (abilityName)
        {
            case "ChangeEnergy":
                modifyEnergy((int)ability.aNum);
                break;
            case "DoubleJump":
                CharacterSystem.instance.characterController.doubleJump();
                break;
            case "Horizontal Dash":
                CharacterSystem.instance.characterController.dash();
                break;
            case "MeleeAtk":
                CharacterSystem.instance.melee();
                break;
            case "RangeAtk":
                CharacterSystem.instance.shuriken();
                break;
            case "ChangeHealth":
                modifyHealth((int)ability.aNum);
                break;
            case "ChangeRandomCardEnergy":
                break;
        }

    }

    void modifyEnergy(int modifyEnergy)
    {
        if (CharacterSystem.instance.playerEnergy + modifyEnergy < 0)
        {
            CharacterSystem.instance.playerEnergy = 0;
        }
        else if (CharacterSystem.instance.playerEnergy + modifyEnergy > CharacterSystem.instance.maxPlayerEnergy)
        {
            CharacterSystem.instance.playerEnergy = CharacterSystem.instance.maxPlayerEnergy;
        }
        else
        {
            CharacterSystem.instance.playerEnergy += modifyEnergy;
        }
    }

    void modifyHealth(int modifyHealth)
    {
        if (CharacterSystem.instance.playerHP + modifyHealth < 0)
        {
            CharacterSystem.instance.playerHP = 0;
            //gameover
        }
        else if (CharacterSystem.instance.playerHP + modifyHealth > CharacterSystem.instance.maxPlayerHP)
        {
            CharacterSystem.instance.playerHP = CharacterSystem.instance.maxPlayerHP;
        }
        else
        {
            CharacterSystem.instance.playerHP += modifyHealth;
        }
    }





}
