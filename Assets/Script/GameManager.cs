using System;
using UnityEngine;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        [Header("食物最大值")] public int maxFood;
        [Header("当前食物值")] public int currentFood;
        [Header("每位玩家的食物消耗")] public int foodCostPerPlayer;
        [Header("玩家数量")] public int playerCount = 2;

        [Header("玩家一属性")] public PlayerState playerOne;
        [Header("玩家二属性")] public PlayerState playerTwo;

        /// <summary>
        /// 是否允许在主界面进行任何交互
        /// </summary>
        public static bool AbleToInput { get; }

        public static GameManager Instance => _instance;
        private static GameManager _instance;


        private void Awake()
        {
            InitAndSingleton();
        }

        private void InitAndSingleton()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            playerOne.health = playerOne.maxHealth;
            playerTwo.health = playerTwo.maxHealth;
        }

        public void ReduceFood()
        {
            int cost = foodCostPerPlayer * playerCount;
            if (currentFood > cost)
                currentFood -= foodCostPerPlayer * playerCount;
            else
                EventHandler.CallDoNotHaveEnoughFood();
        }

        /// <summary>
        /// 某个玩家受伤
        /// </summary>
        /// <param name="playerState"></param>
        public void ReducePlayerHealth(PlayerState playerState)
        {
            if (playerState.health >= 2)
            {
                playerState.health -= 1;
            }
            else if (playerState.health == 1)
            {
                playerState.health -= 1;
                playerCount -= 1;
                PlayerCountCheck();
                Destroy(playerState.playerModule);
            }

            EventHandler.CallAfterPlayerHealthChange();
        }

        /// <summary>
        /// 两个玩家受伤
        /// </summary>
        public void ReducePlayerHealth()
        {
            ReducePlayerHealth(playerOne);
            ReducePlayerHealth(playerTwo);
        }

        public void PlayerOneGiveHealth()
        {
            //玩家生命不足
            if(playerOne.health <= 1) return;

            playerOne.health -= 1;
            EventHandler.CallAfterPlayerHealthChange();
        }

        public void PlayerTwoGiveHealth()
        {
            //玩家生命不足
            if(playerTwo.health <= 1) return;

            playerTwo.health -= 1;
            EventHandler.CallAfterPlayerHealthChange();
        }

        private void PlayerCountCheck()
        {
            if (playerCount == 0)
            {
                //TODO: GameOver
            }
        }
    }
}

[System.Serializable]
public class PlayerState
{
    [Header("玩家当前血量")] public int health = 0;
    [Header("玩家血量上限")] public int maxHealth = 4;
    [Header("玩家模型")] public GameObject playerModule;
}
