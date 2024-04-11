using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController controller;
    //public WeaponData weaponData;
    //public PlayerData playerData;
    //public MonsterData monsterData;
    public PoolManager pool;

    public float gameTime;
    public float maxGameTime = 5 * 60f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if(gameTime> maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
