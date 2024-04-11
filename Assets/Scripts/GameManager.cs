using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 5 * 60f;

    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 450, 600 };

    [Header("# GameObject")]
    //public WeaponData weaponData;
    //public PlayerData playerData;
    //public MonsterData monsterData;
    public PoolManager pool;
    public PlayerController controller;
    

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

    public void GetExp()
    {
        exp++;

        if(exp == nextExp[level])
        {
            level++;
            exp = 0;

        }
    }
}
