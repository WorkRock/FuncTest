using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IG_BtnManager : MonoBehaviour
{
    [Space(15f)]
    [Header("Player")]
    public Text Player_NowHP_T;
    public Text Player_TotalHP_T;

    public Text Player_ATK_T;
    public Text Player_ShieldCT_T;

    public float Player_NowHP;
    public float Player_TotalHP;

    public float Player_ATK;
    public float Player_ShieldCT;

    [Space(15f)]
    [Header("Dragon")]
    public Text Dragon_TotalHP_Text;
    public Text Dragon_NowHP_Text;

    [Space(5f)]
    public float Dragon_TotalHP;
    public float Dragon_NowHP;

    [Space(10f)]
    public float Dragon_BasicDefault_HP;          //기본_Default : 100
    public float Dragon_BasicPlus_HP;             //기본_가중치 : 15

    [Space(10f)]
    public float Dragon_EditDefault_HP;           //보정값_Default : 0
    public float Dragon_EditPlus_HP;              //보정값_가중치 : 40

    [Space(10f)]
    public int Dragon_BasicCorStage_HP;           //보정스테이지_기본 : 1
    public int Dragon_EditCorStage_HP;            //보정스테이지_보정값 : 10

    [Space(10f)]
    public float Dragon_max_HP;                   //최댓값 : 6000

    [Space(15f)]
    [Header("Com Obj")]
    public Text ComObj_Delay_Text;
    public Text ComObj_ATK_Text;
    public Text ComObj_Speed_Text;

    [Space(5f)]
    public float ComObj_Delay;
    public float ComObj_ATK;
    public float ComObj_Speed;

    [Space(5f)]
    [Header("Com Obj Speed")]
    public float BasicDefault_ComObj_Speed;     //기본_Default : 5
    public float BasicPlus_ComObj_Speed;        //기본_가중치 : 0

    [Space(10f)]
    public float EditDefault_ComObj_Speed;      //보정값_Default : 0
    public float EditPlus_ComObj_Speed;         //보정값_가중치 : 1.5

    [Space(10f)]
    public int BasicCorStage_ComObj_Speed;      //보정스테이지_기본 : 1
    public int EditCorStage_ComObj_Speed;       //보정스테이지_보정값 : 10

    [Space(10f)]
    public float max_ComObj_Speed;              //최대(or최소)값 : 15

    [Space(5f)]
    [Header("Com Obj ATK")]
    public float BasicDefault_ComObj_ATK;     //기본_Default : 40
    public float BasicPlus_ComObj_ATK;        //기본_가중치 : 2.5

    [Space(10f)]
    public float EditDefault_ComObj_ATK;      //보정값_Default : 0
    public float EditPlus_ComObj_ATK;         //보정값_가중치 : 20

    [Space(10f)]
    public int BasicCorStage_ComObj_ATK;      //보정스테이지_기본 : 1
    public int EditCorStage_ComObj_ATK;       //보정스테이지_보정값 : 10

    [Space(10f)]
    public float max_ComObj_ATK;              //최대(or최소)값 : 99999

    [Space(5f)]
    [Header("Com Obj Delay")]
    public float BasicDefault_ComObj_Delay;     //기본_Default : 6
    public float BasicPlus_ComObj_Delay;        //기본_가중치 : -0.1

    [Space(10f)]
    public float EditDefault_ComObj_Delay;      //보정값_Default : 0
    public float EditPlus_ComObj_Delay;         //보정값_가중치 : -0.5

    [Space(10f)]
    public int BasicCorStage_ComObj_Delay;      //보정스테이지_기본 : 1
    public int EditCorStage_ComObj_Delay;       //보정스테이지_보정값 : 10

    [Space(10f)]
    public float max_ComObj_Delay;              //최대(or최소)값 : 1

    [Space(15f)]
    [Header("Stage")]
    public Text Stage_Text;
    public int Stage;

    void Start()
    {
        Stage = 1;
        Stage_Text.text = $"Stage : {Stage}";

        // #1 hp초기화
        Player_TotalHP = ScoreManager.GetPlayerHP();
        Player_NowHP = Player_TotalHP;

        Player_TotalHP_T.text = $"TotalHp : {Player_TotalHP}";
        Player_NowHP_T.text = $"NowHp : {Player_NowHP}";

        // #2 공격력
        Player_ATK = ScoreManager.GetPlayerTotalAtk();
        Player_ATK_T.text = $"ATK : {Player_ATK}";

        // #3 쉴드 쿨타임
        Player_ShieldCT = ScoreManager.GetShieldCT();
        Player_ShieldCT_T.text = $"Shield CT : {Player_ShieldCT}";


        // #4-1 드래곤 HP 초기화
        Dragon_TotalHP = Dragon_BasicDefault_HP;
        Dragon_NowHP = Dragon_TotalHP;

        Dragon_TotalHP_Text.text = $"TotalHp : {Dragon_TotalHP}";
        Dragon_NowHP_Text.text = $"NowHp : {Dragon_TotalHP}";

        // #5 오브젝트 스피드, 공격력, 딜레이 초기화
        ComObj_ATK = BasicDefault_ComObj_ATK;
        ComObj_Speed = BasicDefault_ComObj_Speed;
        ComObj_Delay = BasicDefault_ComObj_Delay;

        ComObj_Delay_Text.text = $"ComObj_Delay : {ComObj_Delay}";
        ComObj_ATK_Text.text = $"ComObj_ATK : {ComObj_ATK}";
        ComObj_Speed_Text.text = $"ComObj_Speed : {ComObj_Speed}";
}

    void Update()
    {
       
    }

    public void Dragon_Hit()
    {
        Dragon_NowHP -= Player_ATK;
        Dragon_NowHP_Text.text = $"NowHP : {Dragon_NowHP}";

        if(Dragon_NowHP <= 0)
        {
            Stage++;
            Stage_Text.text = $"Stage : {Stage}";

            // #4 드래곤 체력 증가
            Dragon_TotalHP = Dragon_BasicDefault_HP + ScoreManager.totalFloatFormula(Stage - 1, Dragon_BasicPlus_HP, Dragon_BasicCorStage_HP,
                Dragon_EditDefault_HP, Dragon_EditPlus_HP, Dragon_EditCorStage_HP);

            Dragon_NowHP = Dragon_TotalHP;

            //텍스트 변경
            Dragon_TotalHP_Text.text = $"TotalHp : {Dragon_TotalHP}";
            Dragon_NowHP_Text.text = $"NowHp : {Dragon_NowHP}";

            // # 5 오브젝트 공격력, 스피드, 딜레이 증감
            ComObj_ATK = BasicDefault_ComObj_ATK + ScoreManager.totalFloatFormula(Stage - 1, BasicPlus_ComObj_ATK, BasicCorStage_ComObj_ATK,
                EditDefault_ComObj_ATK, EditPlus_ComObj_ATK, EditCorStage_ComObj_ATK);
            ComObj_ATK_Text.text = "ComObj_ATK : " + ComObj_ATK.ToString();

            ComObj_Speed = BasicDefault_ComObj_Speed + ScoreManager.totalFloatFormula(Stage - 1, BasicPlus_ComObj_Speed, BasicCorStage_ComObj_Speed,
                EditDefault_ComObj_Speed, EditPlus_ComObj_Speed, EditCorStage_ComObj_Speed);
            ComObj_Speed_Text.text = "ComObj_Speed : " + ComObj_Speed.ToString();

            ComObj_Delay = BasicDefault_ComObj_Delay + ScoreManager.totalFloatFormula(Stage - 1, BasicPlus_ComObj_Delay, BasicCorStage_ComObj_Delay,
                EditDefault_ComObj_Delay, EditPlus_ComObj_Delay, EditCorStage_ComObj_Delay);
            ComObj_Delay_Text.text = "ComObj_Delay : " + ComObj_Delay.ToString();
        }
    }

    public void Player_Hit()
    {
        Player_NowHP -= ComObj_ATK;
        Player_NowHP_T.text = $"NowHp : {Player_NowHP}";

        if (Player_NowHP <= 0)
        {
            ScoreManager.SetBStage(Stage);
            SceneManager.LoadScene("Result");
        }
    }
}
