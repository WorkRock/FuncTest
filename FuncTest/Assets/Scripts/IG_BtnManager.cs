using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IG_BtnManager : MonoBehaviour
{
    [Header ("Player")]
    public Text Player_TotalHP_Text;
    public Text Player_NowHP_Text;
    public Text Player_HPBonus_Text;
    public Text Player_ATK_Text;
    public Text Player_ShieldCT_Text;
    public Text Player_Level_Text;

    [Space(5f)]
    public int Player_TotalHP;
    public int Player_NowHP;
    public int Player_HPBonus;
    public float Player_ATK;
    public float Player_ShieldCT;
    public int Player_Level;

    [Space(10f)]
    [Header ("Player_HP")]
    public int Player_BasicDefaultHP;                  //기본_Default : 100
    public int Player_BasicPlusHP;                     //기본_가중치 : 3

    [Space(10f)]
    public int Player_EditDefaultHP;                   //보정값_Default : 0
    public int Player_EditPlusHP;                      //보정값_가중치 : 20

    [Space(10f)]
    public int Player_BasicCorLevel_HP;                //보정레벨_기본 : 1
    public int Player_EditCorLevel_HP;                 //보정레벨_보정값 : 10

    [Space(10f)]
    public int Player_maxHP;                           //최댓값 : 2000

    [Space(10f)]
    [Header("Player_ATK")]
    public float Player_BasicDefaultATK;               //기본_Default : 30
    public float Player_BasicPlusATK;                  //기본_가중치 : 0

    [Space(10f)]
    public float Player_EditDefaultATK;                //보정값_Default : 0
    public float Player_EditPlusATK;                   //보정값_가중치 : 15

    [Space(10f)]
    public int Player_BasicCorLevel_ATK;               //보정레벨_기본 : 1
    public int Player_EditCorLevel_ATK;                //보정레벨_보정값 : 10

    [Space(10f)]
    public float Player_maxATK;                        //최댓값 : 500

    [Space(10f)]
    [Header("Player_UG")]
    public float Player_UG;
    public int Player_UG_Level;                        //공격력 업그레이드 레벨

    [Space(10f)]
    public float Player_BasicDefaultUG;                //기본_Default : 1
    public float Player_BasicPlusUG;                   //기본_가중치 : 0.035

    [Space(10f)]
    public float Player_EditDefaultUG;                 //보정값_Default : 0
    public float Player_EditPlusUG;                    //보정값_가중치 : 0.16

    [Space(10f)]
    public int Player_BasicCorLevel_UG;                //보정레벨_기본 : 1
    public int Player_EditCorLevel_UG;                 //보정레벨_보정값 : 10

    [Space(10f)]
    public float Player_maxUG;                         //최댓값 : 3

    [Space(10f)]
    [Header("Player_ShieldCT")]
    public float Player_BasicDefault_ShieldCT;          //기본_Default : 3
    public float Player_BasicPlus_ShieldCT;             //기본_가중치 : 0

    [Space(10f)]
    public float Player_EditDefault_ShieldCT;           //보정값_Default : 0
    public float Player_EditPlus_ShieldCT;              //보정값_가중치 : -0.5

    [Space(10f)]
    public int Player_BasicCorLevel_ShieldCT;           //보정레벨_기본 : 1
    public int Player_EditCorLevel_ShieldCT;            //보정레벨_보정값 : 10

    [Space(10f)]
    public float Player_max_ShieldCT;                   //최댓값 : 1


    [Space(15f)]
    [Header("Dragon")]
    public Text Dragon_TotalHP_Text;
    public Text Dragon_NowHP_Text;

    [Space(5f)]
    public int Dragon_TotalHP;
    public int Dragon_NowHP;

    [Space(15f)]
    [Header("Com Obj")]
    public Text ComObj_Delay_Text;
    public Text ComObj_ATK_Text;
    public Text ComObj_Speed_Text;

    [Space(5f)]
    public float ComObj_Delay;
    public float ComObj_ATK;
    public float ComObj_Speed;

    [Space(15f)]
    [Header("Stage")]
    public Text Stage_Text;
    public int Stage;

    void Start()
    {
        //Player_Level = ScoreManager.GetPlayerLevel();
        // #1 플레이어 HP 계산
        if (Player_Level == 1)
            Player_TotalHP = Player_BasicDefaultHP;
        else
            Player_TotalHP = Player_BasicDefaultHP + ScoreManager.totalIntFormula(Player_Level-1, Player_BasicPlusHP, Player_BasicCorLevel_HP,
            Player_EditDefaultHP, Player_EditPlusHP, Player_EditCorLevel_HP);

        // #1 현재 hp에 대입
        Player_NowHP = Player_TotalHP;

        // #1 텍스트 출력
        Player_TotalHP_Text.text = $"TotalHP : {Player_TotalHP}";
        Player_NowHP_Text.text = $"NowHP : {Player_NowHP}";

        // #2 플레이어 ATK 계산 (최종 공격력 = 공격력 + 업그레이드 공격력)
        if (Player_Level == 1)
            Player_ATK = Player_BasicDefaultATK;
        else
            Player_ATK = ScoreManager.totalFloatFormula(Player_Level - 1, Player_BasicPlusATK, Player_BasicCorLevel_ATK,
                Player_EditDefaultATK, Player_EditPlusATK, Player_EditCorLevel_ATK) +
                ScoreManager.totalFloatFormula(Player_Level - 1, Player_BasicPlusUG, Player_BasicCorLevel_UG,
                Player_EditDefaultUG, Player_EditPlusUG, Player_EditCorLevel_UG);

        // #2 텍스트 출력
        Player_ATK_Text.text = $"ATK : {Player_ATK}";

        // #3 플레이어 ShieldCT 계산
        if (Player_Level == 1)
            Player_ShieldCT = Player_BasicDefault_ShieldCT;
        //else
            //Player_ShieldCT = ScoreManager.totalFloatFormula(Player_UG_Level - 1, Player_BasicPlus_ShieldCT )
    }

    void Update()
    {
        
    }

}
