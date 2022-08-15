using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private Text PlayerHP;
    [SerializeField] private Text PlayerLevel;
    [SerializeField] private Text PlayerTotalExp;
    [SerializeField] private Text PlayerNowExp;
    [SerializeField] private Text PlayerAtk;
    [SerializeField] private Text PlayerCoin;
    [SerializeField] private Text PlayerAtkUG;

    [SerializeField] private Text UG_DMG;
    [SerializeField] private Text UG_CT;
    [SerializeField] private Text UG_NeedCoin;

    [SerializeField] private Text Cal_DMG;


    public BtnManager btnManager;
    private int playerLevel;
    private int atkUG;

    private int totalCoin;

    [Header("Player_HP")]
    public int Player_HP_TotalHP;
    [Space(10f)]
    public int PlayerHP_BasicDef;
    public int PlayerHP_BasicPlus;
    [Space(10f)]
    public int PlayerHP_EditDef;
    public int PlayerHP_EditPlus;
    [Space(10f)]
    public int PlayerHP_BasicCor;
    public int PlayerHP_EditCor;
    [Space(10f)]
    public int Player_HP_Max;

    [Header("Player_Exp")]
    public int Player_Exp_TotalExp;
    public int Player_Exp_nowExp;
    [Space(10f)]
    public int PlayerExp_BasicDef;
    public int PlayerExp_BasicPlus;
    [Space(10f)]
    public int PlayerExp_EditDef;
    public int PlayerExp_EditPlus;
    [Space(10f)]
    public int PlayerExp_BasicCor;
    public int PlayerExp_EditCor;
    [Space(10f)]
    public int Player_Exp_Max;

    [Header("Player_Atk")]
    public int Player_Atk_TotalAtk;
    public int Player_Atk_nowAtk;
    [Space(10f)]
    public int PlayerAtk_BasicDef;
    public int PlayerAtk_BasicPlus;
    [Space(10f)]
    public int PlayerAtk_EditDef;
    public int PlayerAtk_EditPlus;
    [Space(10f)]
    public int PlayerAtk_BasicCor;
    public int PlayerAtk_EditCor;
    [Space(10f)]
    public int Player_Atk_Max;
    
    [Header("UG_DMG")]
    public float UG_DMG_Total;

    [Space(10f)]
    public float UG_DMG_BasicDef;
    public float UG_DMG_BasicPlus;
    [Space(10f)]
    public float UG_DMG_EditDef;
    public float UG_DMG_EditPlus;
    [Space(10f)]
    public int UG_DMG_BasicCor;
    public int UG_DMG_EditCor;
    [Space(10f)]
    public float UG_DMG_Max;

    [Header("UG_CT")]
    public float UG_CT_Total;

    [Space(10f)]
    public float UG_CT_BasicDef;
    public float UG_CT_BasicPlus;
    [Space(10f)]
    public float UG_CT_EditDef;
    public float UG_CT_EditPlus;
    [Space(10f)]
    public int UG_CT_BasicCor;
    public int UG_CT_EditCor;
    [Space(10f)]
    public float UG_CT_Max;

    [Header("UG_needCoin")]
    public int UG_needCoin_Total;

    [Space(10f)]
    public int UG_needCoin_BasicDef;
    public int UG_needCoin_BasicPlus;
    [Space(10f)]
    public int UG_needCoin_EditDef;
    public int UG_needCoin_EditPlus;
    [Space(10f)]
    public int UG_needCoin_BasicCor;
    public int UG_needCoin_EditCor;
    [Space(10f)]
    public int UG_needCoin_Max;

    // Start is called before the first frame update
    void Start()
    {
        playerLevel = ScoreManager.GetPlayerLevel();
        
        Player_Exp_nowExp = ScoreManager.GetExp();
        atkUG = ScoreManager.GetAtkUG();

        Player_HP_TotalHP = PlayerHP_BasicDef;
        Player_Exp_TotalExp = PlayerExp_BasicDef;
        Player_Atk_TotalAtk = PlayerAtk_BasicDef;        

        UG_needCoin_Total = UG_needCoin_BasicDef;
        UG_DMG_Total = UG_DMG_BasicDef;
        UG_CT_Total = UG_CT_BasicDef;

        totalNeedCoinCal();
        totalExpCal();
        totalAtkCal();
        totalUGDMGCal();
        totalUGCTCal();
    }

    // Update is called once per frame
    void Update()
    {
        totalCoin = ScoreManager.GetCoin();

        PlayerHP.text = Player_HP_TotalHP.ToString();
        PlayerLevel.text = playerLevel.ToString();
        PlayerTotalExp.text = Player_Exp_TotalExp.ToString();
        PlayerNowExp.text = Player_Exp_nowExp.ToString();
        PlayerCoin.text = totalCoin.ToString();
        PlayerAtk.text = Player_Atk_TotalAtk.ToString();

        PlayerAtkUG.text = atkUG.ToString();
        UG_DMG.text = (UG_DMG_Total*100 + "%").ToString();
        UG_CT.text = UG_CT_Total.ToString();
        UG_NeedCoin.text = UG_needCoin_Total.ToString();

        Cal_DMG.text = (Player_Atk_TotalAtk * UG_DMG_Total).ToString();

        levelEdit();
        
    }

    
    void levelEdit()
    {
        Player_Exp_nowExp = ScoreManager.GetExp();

        if(Player_Exp_nowExp < Player_Exp_TotalExp)
            return;

        // 획득 경험치가 토탈 경험치보다 높을 시 실행
        if (Player_Exp_nowExp >= Player_Exp_TotalExp)
        {
            ScoreManager.SetPlayerLevel(playerLevel+1);
            Player_Exp_nowExp -= Player_Exp_TotalExp;
            ScoreManager.SetExp(Player_Exp_nowExp);

            // 토탈 경험치를 빼주어도 0보다 클 시 재귀
            if (Player_Exp_nowExp > 0)
            {
                totalExpCal();
                levelEdit();
            }

            // 0보다 작아질 시 0으로 초기화
            else if (Player_Exp_nowExp <= 0)
            {
                Player_Exp_nowExp = 0;
                ScoreManager.SetExp(Player_Exp_nowExp);
                totalExpCal();
            }
            
            totalHPCal();
            totalAtkCal();   
        }
    }
    

    void totalHPCal()
    {
        playerLevel = ScoreManager.GetPlayerLevel();

        if(playerLevel == 1)
            return;

        Player_HP_TotalHP = PlayerHP_BasicDef +
        ScoreManager.totalIntFormula(playerLevel-1, PlayerHP_BasicPlus, PlayerHP_BasicCor, PlayerHP_EditDef, PlayerHP_EditPlus, PlayerHP_EditCor);

        if(Player_HP_TotalHP >= Player_HP_Max)
            Player_HP_TotalHP = Player_HP_Max;
    }


    void totalExpCal()
    {
        playerLevel = ScoreManager.GetPlayerLevel();

        if(playerLevel == 1)
            return;

        Player_Exp_TotalExp = PlayerExp_BasicDef +
        ScoreManager.totalIntFormula(playerLevel-1, PlayerExp_BasicPlus, PlayerExp_BasicCor, PlayerExp_EditDef, PlayerExp_EditPlus, PlayerExp_EditCor);

        if(Player_Exp_TotalExp >= Player_Exp_Max)
            Player_Exp_TotalExp = Player_Exp_Max;
    }

    void totalAtkCal()
    {
        playerLevel = ScoreManager.GetPlayerLevel();

        if(playerLevel == 1)
            return;

        Player_Atk_TotalAtk = PlayerAtk_BasicDef +
        ScoreManager.totalIntFormula(playerLevel-1, PlayerAtk_BasicPlus, PlayerAtk_BasicCor, PlayerAtk_EditDef, PlayerAtk_EditPlus, PlayerAtk_EditCor);

        if(Player_Atk_TotalAtk >= Player_Atk_Max)
            Player_Atk_TotalAtk = Player_Atk_Max;
    }

    public void atkUGPlus()
    {
        atkUG = ScoreManager.GetAtkUG();
        if(atkUG >= 40)
            return;


        if(totalCoin >= UG_needCoin_Total)
        {
            Debug.Log("Upgrade");
            atkUG++;
            totalCoin -= UG_needCoin_Total;
            ScoreManager.SetCoin(totalCoin);
            ScoreManager.SetAtkUG(atkUG);

            totalNeedCoinCal();
            totalUGDMGCal();
            totalUGCTCal();

            atkUG = ScoreManager.GetAtkUG();
        }
    }

    void totalNeedCoinCal()
    {
        atkUG = ScoreManager.GetAtkUG();

        if(atkUG == 1)
            return;

        UG_needCoin_Total = UG_needCoin_BasicDef +
        ScoreManager.totalIntFormula(atkUG-1, UG_needCoin_BasicPlus, UG_needCoin_BasicCor, UG_needCoin_EditDef, UG_needCoin_EditPlus, UG_needCoin_EditCor);

        if(UG_needCoin_Total >= UG_needCoin_Max)
            UG_needCoin_Total = UG_needCoin_Max;
    }


    void totalUGDMGCal()
    {
        atkUG = ScoreManager.GetAtkUG();

        if(atkUG == 1)
            return;

        UG_DMG_Total = UG_DMG_BasicDef +
        ScoreManager.totalFloatFormula(atkUG-1, UG_DMG_BasicPlus, UG_DMG_BasicCor, UG_DMG_EditDef, UG_DMG_EditPlus, UG_DMG_EditCor);

        if(UG_DMG_Total >= UG_DMG_Max)
            UG_DMG_Total = UG_DMG_Max;
    }

    void totalUGCTCal()
    {
        atkUG = ScoreManager.GetAtkUG();

        if(atkUG == 1)
            return;

        UG_CT_Total = UG_CT_BasicDef +
        ScoreManager.totalFloatFormula(atkUG, UG_CT_BasicPlus, UG_CT_BasicCor, UG_CT_EditDef, UG_CT_EditPlus, UG_CT_EditCor);

        if(UG_CT_Total <= UG_CT_Max)
            UG_CT_Total = UG_CT_Max;
    }

}
