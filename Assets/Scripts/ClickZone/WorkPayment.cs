using System;

public class WorkPayment 
{
    public static Action<int> spriteID;
    public static Action<int, ItemId> Payment;
    private ChatLog chatLog;
    private ItemsData itemsData = new ItemsData();
    private Wallet wallet = new Wallet();
    private WorkDataChanger data = new WorkDataChanger();
    public ClickFactor factor;
    private SoWork currentWork;


    public void SetData(SoWork work, ChatLog chat)
    {
        currentWork = work;
        chatLog = chat;
        factor = new(work.WorkId);
    }
    public void Click()
    {
        if (!currentWork.IsCanEmploy) GetResource();
        else GetMoney();
    }
    private void GetMoney()
    {
        int currentRang = data.GetRang(currentWork.WorkId);
        float bonusByRang = (float)currentRang / 10 + 1;
        wallet.MoneyOperation((int)(currentWork.GetPaiment() * bonusByRang));
        spriteID.Invoke(17);
        if (UnityEngine.Random.Range(1, 301) == 300 && currentRang < 10)
        {
            data.UpRang(currentWork.WorkId);
            chatLog.AddMesage($"<color=purple>Вас повысили!");
        }
    }
    private void GetResource()
    {
        var result = currentWork.GetItem();
        int count = factor.Factor;
        itemsData.ChangeRes(result, count);
        Payment?.Invoke(count, result);
        spriteID?.Invoke((int)result + 1);
    }
}
