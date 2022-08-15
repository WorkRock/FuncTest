using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private Text PlayerHP;

    private int playerLevel;

    [Header("Player_HP")]
    public int Player_HP_TotalHP;
    public int PlayerHP_BasicDef;
    public int PlayerHP_BasicPlus;
    public int PlayerHP_EditDef;
    public int PlayerHP_EditPlus;
    public int PlayerHP_BasicCor;
    public int PlayerHP_EditCor;
    public int Player_HP_Max;

    


    // Start is called before the first frame update
    void Start()
    {
        playerLevel = ScoreManager.GetPlayerLevel();
        Debug.Log("PlayerLevel : " + playerLevel);
        Player_HP_TotalHP = PlayerHP_BasicDef;

        Debug.Log("PlayerEditCor : " + PlayerHP_EditCor);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP.text = Player_HP_TotalHP.ToString();
    }

    /*
    void levelEdit()
    {
        // 획득 경험치가 토탈 경험치보다 높을 시 실행
        if (curExp >= totalExp)
        {
            playerLevel++;
            curExp -= totalExp;


            // 토탈 경험치를 빼주어도 0보다 클 시 재귀
            if (curExp > 0)
            {
                totalExpCal(playerLevel);
                levelEdit();
            }

            // 0보다 작아질 시 0으로 초기화
            else if (curExp <= 0)
            {
                curExp = 0;
                totalExpCal(playerLevel);
            }
            
            totalHpCal();
            totalPlayer_AtkCal();
            Player_PlusUGAtk = Player_TotalAtk * upgrade.totalUGDMG;
            upgrade.isBtnClicked = false;
        }
        markExp();

        // Lobby Test를 위한 추가
        
        // totalPlayer_AtkCal();

        if(upgrade.isBtnClicked)
        {
            Debug.Log("BtnClicked");
            totalPlayer_AtkCal();
            Player_PlusUGAtk = Player_TotalAtk * upgrade.totalUGDMG;
            
            Debug.Log("Player_TotalAtk : " + Player_TotalAtk);
            upgrade.isBtnClicked = false;
        }
    }
    */

    void totalHPCal()
    {
        playerLevel = ScoreManager.GetPlayerLevel();

        if(playerLevel == 1)
            return;

        int cor = PlayerHP_EditCor;

        Player_HP_TotalHP = PlayerHP_BasicDef +
        ScoreManager.totalIntFormula(playerLevel-1, PlayerHP_BasicPlus, PlayerHP_BasicCor, PlayerHP_EditDef, PlayerHP_EditPlus, PlayerHP_EditCor);

        if(Player_HP_TotalHP >= Player_HP_Max)
            Player_HP_TotalHP = Player_HP_Max;
    }

    public void LevelPlus()
    {
        int playerLevel = ScoreManager.GetPlayerLevel();
        playerLevel++;
        Debug.Log("PlayerLevel : " + playerLevel);
        ScoreManager.SetPlayerLevel(playerLevel);
        
        totalHPCal();
    }
}
