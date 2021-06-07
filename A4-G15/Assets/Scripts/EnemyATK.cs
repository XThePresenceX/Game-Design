using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATK : MonoBehaviour
{
    public void ATK(int dmg)
    {
        SoundManager.PlaySound("Nani");
        PlayerManager.PHealth -= dmg;
    }
}
