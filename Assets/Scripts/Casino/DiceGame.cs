using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceGame : MonoBehaviour
{
    [SerializeField] private List<Sprite> dicesSprites = new List<Sprite>();
    [SerializeField] private GameObject infopanel;
    [SerializeField] private List<Image> playerDices = new List<Image>();
    [SerializeField] private List<Image> enemyDices = new List<Image>();
    [SerializeField] private InfoTabCaller infoTab;
    [SerializeField] private Sprite nullSprite;
    private List<int> playerScore = new List<int> { 0, 0 };
    private List<int> enemyScore = new List<int> { 0, 0 };
    [Space]
    [SerializeField] private TMP_Text enemyScoreText;
    [SerializeField] private TMP_Text playerScoreText;
    [SerializeField] private TMP_Text enemyNick;
    [SerializeField] private GameObject betTab;
    [SerializeField] private MoneyPrinter moneyPrinter;
    [SerializeField] private InfoLineCaller infoLine;
    [Space]
    private ChatActions chatActions = new ChatActions();
    private PersonalStats stats = new PersonalStats();
    private Wallet wallet = new Wallet();
    private int playerWin;
    private int enemyWin;

    private void Awake()
    {
        CalculateScore();
        enemyNick.text = chatActions.GetPlayerName();
    }
    public void Play(int bet)
    {
        if (wallet.GetMoney() >= bet)
            StartCoroutine(Game(bet));
        else infoTab.CallInfoPanel("Не хватает <color=green>$</color> на балансе");
    }
    private void Dice(List<Image> dices, List<int> score)
    {
        for (int i = 0; i < dices.Count; i++)
        {
            int random = Random.Range(0,dicesSprites.Count);
            dices[i].sprite = dicesSprites[random];
            score[i] = random + 1;
        }
    }
    private void CalculateScore()
    {
        playerWin = playerScore[0] + playerScore[1];
        playerScoreText.text = playerWin.ToString();
        enemyWin = enemyScore[0] + enemyScore[1];
        enemyScoreText.text = enemyWin.ToString();
    }
    private IEnumerator Game(int bet)
    {
        betTab.SetActive(false);
        infopanel.SetActive(true);
        UpdateInfo();
        yield return new WaitForSeconds(1);
        Dice(enemyDices,enemyScore); 
        CalculateScore();
        yield return new WaitForSeconds(2);
        Dice(playerDices, playerScore); 
        CalculateScore();
        yield return new WaitForSeconds(1);
        if (playerWin > enemyWin)
        {
            stats.ChangeStats(bet, stats.CasinoWinKey);
            wallet.MoneyOperation(bet);
            infoTab.CallInfoPanel($"Вы выиграли <color=green>{bet}$</color>!");
            moneyPrinter.UpdateInfo();
            infoLine.CallInfoLine($"+{bet}$", true);
        }         
        else if (playerWin == enemyWin)
        {
            wallet.MoneyOperation(0);
            infoTab.CallInfoPanel($"Ничья!");
        }
        else
        {
            stats.ChangeStats(bet, stats.CasinoLostKey);
            wallet.MoneyOperation(-bet);
            infoTab.CallInfoPanel($"Вы проиграли <color=green>{bet}$</color>!");
            moneyPrinter.UpdateInfo();
            infoLine.CallInfoLine($"-{bet}$", false);
        }    
        yield return new WaitForSeconds(1);
        betTab.SetActive(true);
        infopanel.SetActive(false);
    }
    private void UpdateInfo()
    {
        ResetDice(playerDices,playerScore);
        ResetDice(enemyDices, enemyScore);
        CalculateScore();
    }
    private void ResetDice(List<Image> dices, List<int> score)
    {
        for (int i = 0; dices.Count > i; i++)
        {
            dices[i].sprite = nullSprite;
            score[i] = 0;
        }
    }
}
