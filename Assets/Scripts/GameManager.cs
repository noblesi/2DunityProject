using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("# Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime = 5 * 60f;

    [Header("# Player Info")]
    public int curHp;
    public int maxHp;
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
    public LevelUp uiLevelUp;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        curHp = maxHp;

        uiLevelUp.Select(0);
    }

    private void Update()
    {
        if (!isLive) return;

        gameTime += Time.deltaTime;

        if(gameTime> maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;

        if(exp == nextExp[Mathf.Min(level, nextExp.Length-1)])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
