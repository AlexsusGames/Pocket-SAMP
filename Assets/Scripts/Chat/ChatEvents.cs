using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatEvents 
{
    private ChatActions data = new ChatActions();
    private List<string> events = new List<string>();
    private int index;
    public List<string> GetEvent(List<string> names)
    {
        data.SetNamesList(names);
        index = Random.Range(0, 11);
        Debug.Log(index);
        switch (index)
        {
            default:
            case 0: Generate1Event(); return events;
            case 1: Generate2Event(); return events;
            case 2: Generate3Event(); return events;
            case 3: Generate4Event(); return events;
            case 4: Generate5Event(); return events;
            case 5: Generate6Event(); return events;
            case 6: Generate7Event(); return events;
            case 7: Generate8Event(); return events;
            case 8: Generate9Event(); return events;
            case 9: Generate10Event(); return events;
            case 10: Generate11Event(); return events;
        }
    }
    private void Generate1Event()
    {
        events.Clear();
        events.Add($"<color=#32CD32>Игрок {data.GetPlayerName()} выбил грядку для собственного выращивания льна");
        events.Add($"{data.GetPlayerNameWithPref()} гц!");
        events.Add($"{data.GetPlayerNameWithPref()} gc!");
        events.Add($"{data.GetPlayerNameWithPref()} гц!");
        events.Add($"{data.GetPlayerNameWithPref()} продай грядку пж");
    }
    private void Generate2Event()
    {
        events.Clear();
        events.Add($"<color=#32CD32>Игрок {data.GetPlayerName()} выбил грядку для собственного выращивания хлопка");
        events.Add($"{data.GetPlayerNameWithPref()} гц!");
        events.Add($"{data.GetPlayerNameWithPref()} gc!");
        events.Add($"{data.GetPlayerNameWithPref()} 30кк куплю грядку, {data.GetNumber()}");
    }
    private void Generate3Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"<color=#32CD32>{player} испытал удачу при использовнии '{data.GetCarBox()}' и выиграл транспорт: {data.GetCar()}");
        events.Add($"{data.GetVipPref()}{player}: с {Random.Range(1, 100)} кайф");
        events.Add($"{data.GetPlayerNameWithPref()} gc");
        events.Add($"{data.GetPlayerNameWithPref()} окуп");
    }
    private void Generate4Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"<color=#32CD32>{player} испытал удачу при использовнии '{data.GetCarBox()}' и выиграл транспорт: {data.GetCar()}");
        events.Add($"{data.GetPlayerNameWithPref()} ne gc");
        events.Add($"{data.GetPlayerNameWithPref()} окуп");
        events.Add($"{data.GetVipPref()}{player}: не окуп");
    }
    private void Generate5Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"<color=yellow>[Новости штата] <color=white>{player}</color> пожертвовал <color=white>{data.GetDonate()}</color> в благотворительный фонд штата.");
        events.Add($"{data.GetPlayerNameWithPref()} лучше бы мне отдал");
        events.Add($"{data.GetPlayerNameWithPref()} скинь мне немного");
    }
    private void Generate6Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"{data.GetVipPref()}{player}: ухожу с сервера!!");
        events.Add($"<color=yellow>[Новости штата] <color=white>{player}</color> пожертвовал <color=white>{data.GetDonate()}</color> в благотворительный фонд штата.");
        events.Add($"<color=yellow>[Новости штата] <color=white>{player}</color> пожертвовал <color=white>{data.GetDonate()}</color> в благотворительный фонд штата.");
        events.Add($"{data.GetPlayerNameWithPref()} лучше бы мне отдал");
        events.Add($"<color=yellow>[Новости штата] <color=white>{player}</color> пожертвовал <color=white>{data.GetDonate()}</color> в благотворительный фонд штата.");
        events.Add($"{data.GetPlayerNameWithPref()} скинь мне немного");
    }
    private void Generate7Event()
    {
        string admin = data.GetAdminName();
        events.Clear();
        events.Add($"{data.GetAdminVip()}{admin}: ку от Павлова");
        events.Add($"<color=red>А: {admin} {data.adminActions[1]}" +
            $" {data.GetPlayerName()} на 30 дней. Причина: {data.funnyReasons[Random.Range(0, data.funnyReasons.Count)]}");
        events.Add($"<color=red>А: {admin} {data.adminActions[1]}" +
            $" {data.GetPlayerName()} на 30 дней. Причина: {data.funnyReasons[Random.Range(0, data.funnyReasons.Count)]}");
        events.Add($"<color=red>А: {data.GetAdminName()} забанил игрока {admin}. Причина: передан/взломан");
    }
    private void Generate8Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"{data.GetVipPref()}{player}: НА ЦР СКУПАЮ ДОРОГО В ПЕРВОЙ ЛАВКЕ!!");
        events.Add($"<color=red>А: {data.GetAdminName()} заглушил игрока {player}. Причина: капс");
    }
    private void Generate9Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"{data.GetVipPref()}{player}: УРАААААА!! УРАА! УРААААААА!!! УРААААААА!!");
        events.Add($"<color=red>А: {data.GetAdminName()} заглушил игрока {player}. Причина: капс");
    }
    private void Generate10Event()
    {
        events.Clear();
        events.Add($"<color=red>А: {data.GetAdminName()} забанил игрока {data.GetPlayerName()} на 2000 дней. Причина: продажа вирт");
        events.Add($"{data.GetPlayerNameWithPref()}: туда");
        events.Add($"{data.GetPlayerNameWithPref()}: туда");
    }
    private void Generate11Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"{data.GetVipPref()}{player}: mqmqmqmqmqmqmq!");
        events.Add($"<color=red>А: {data.GetAdminName()} забанил игрока {player} на 30 дней. Причина: оск.родни");
        events.Add($"{data.GetPlayerNameWithPref()}: туда");
    }
}
