using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayDayManager 
{
    private Wallet wallet = new Wallet();
    private ProfitCalculater bank = new ProfitCalculater();
    private PersonalStats personalStats = new PersonalStats();
    private ChatLog chatLog;
    private AzMining azMining = new AzMining();
    private WaitForSeconds waitTime = new(60);

    public IEnumerator PayDayTimer()
    {
        while (true)
        {
            yield return waitTime;
            GivePayDay();
        }
    }
    public void FindChat()
    {
        try
        {
            chatLog = GameObject.Find("Chat").GetComponent<ChatLog>();
        }
        catch
        {
            chatLog = null;
        }
    }
    private void GivePayDay()
    {
        var vip = new VipStatus();
        var skinLevel = PlayerPrefs.GetInt("Avatar");
        var prifitInPayDay = skinLevel == 10? bank.GetProfit() * 2 : bank.GetProfit();
        int respectCount = 1;
        int donateCount = vip.GetVip() ? 5 : 1;
        if (chatLog == null) FindChat();
        bank.BankOperation(bank.GetProfit());
        wallet.RespectsOperation(respectCount);
        wallet.DonateOperation(donateCount);
        personalStats.ChangeStats(1, personalStats.TimePlayed);
        if(chatLog != null)
        {
            chatLog.AddMesage($"<color=#6de100>------------------------------------------------</color>");
            chatLog.AddMesage($"<color=#6de100>-------------Банковская выписка-----------------</color>");
            chatLog.AddMesage($" Сумма к выплате: {prifitInPayDay}$");
            chatLog.AddMesage($" Получено PS-coins: <color=yellow>{donateCount}");
            chatLog.AddMesage($" Получено респектов: <color=#7884cd>{respectCount}");
            chatLog.AddMesage($"<color=#6de100>------------------------------------------------</color>");
        }
        azMining.VideocardsWorking();
    }
}
