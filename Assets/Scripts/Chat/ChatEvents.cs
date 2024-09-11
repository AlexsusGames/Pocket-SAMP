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
        events.Add($"<color=#32CD32>����� {data.GetPlayerName()} ����� ������ ��� ������������ ����������� ����");
        events.Add($"{data.GetPlayerNameWithPref()} ��!");
        events.Add($"{data.GetPlayerNameWithPref()} gc!");
        events.Add($"{data.GetPlayerNameWithPref()} ��!");
        events.Add($"{data.GetPlayerNameWithPref()} ������ ������ ��");
    }
    private void Generate2Event()
    {
        events.Clear();
        events.Add($"<color=#32CD32>����� {data.GetPlayerName()} ����� ������ ��� ������������ ����������� ������");
        events.Add($"{data.GetPlayerNameWithPref()} ��!");
        events.Add($"{data.GetPlayerNameWithPref()} gc!");
        events.Add($"{data.GetPlayerNameWithPref()} 30�� ����� ������, {data.GetNumber()}");
    }
    private void Generate3Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"<color=#32CD32>{player} ������� ����� ��� ������������ '{data.GetCarBox()}' � ������� ���������: {data.GetCar()}");
        events.Add($"{data.GetVipPref()}{player}: � {Random.Range(1, 100)} ����");
        events.Add($"{data.GetPlayerNameWithPref()} gc");
        events.Add($"{data.GetPlayerNameWithPref()} ����");
    }
    private void Generate4Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"<color=#32CD32>{player} ������� ����� ��� ������������ '{data.GetCarBox()}' � ������� ���������: {data.GetCar()}");
        events.Add($"{data.GetPlayerNameWithPref()} ne gc");
        events.Add($"{data.GetPlayerNameWithPref()} ����");
        events.Add($"{data.GetVipPref()}{player}: �� ����");
    }
    private void Generate5Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"<color=yellow>[������� �����] <color=white>{player}</color> ����������� <color=white>{data.GetDonate()}</color> � ����������������� ���� �����.");
        events.Add($"{data.GetPlayerNameWithPref()} ����� �� ��� �����");
        events.Add($"{data.GetPlayerNameWithPref()} ����� ��� �������");
    }
    private void Generate6Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"{data.GetVipPref()}{player}: ����� � �������!!");
        events.Add($"<color=yellow>[������� �����] <color=white>{player}</color> ����������� <color=white>{data.GetDonate()}</color> � ����������������� ���� �����.");
        events.Add($"<color=yellow>[������� �����] <color=white>{player}</color> ����������� <color=white>{data.GetDonate()}</color> � ����������������� ���� �����.");
        events.Add($"{data.GetPlayerNameWithPref()} ����� �� ��� �����");
        events.Add($"<color=yellow>[������� �����] <color=white>{player}</color> ����������� <color=white>{data.GetDonate()}</color> � ����������������� ���� �����.");
        events.Add($"{data.GetPlayerNameWithPref()} ����� ��� �������");
    }
    private void Generate7Event()
    {
        string admin = data.GetAdminName();
        events.Clear();
        events.Add($"{data.GetAdminVip()}{admin}: �� �� �������");
        events.Add($"<color=red>�: {admin} {data.adminActions[1]}" +
            $" {data.GetPlayerName()} �� 30 ����. �������: {data.funnyReasons[Random.Range(0, data.funnyReasons.Count)]}");
        events.Add($"<color=red>�: {admin} {data.adminActions[1]}" +
            $" {data.GetPlayerName()} �� 30 ����. �������: {data.funnyReasons[Random.Range(0, data.funnyReasons.Count)]}");
        events.Add($"<color=red>�: {data.GetAdminName()} ������� ������ {admin}. �������: �������/�������");
    }
    private void Generate8Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"{data.GetVipPref()}{player}: �� �� ������ ������ � ������ �����!!");
        events.Add($"<color=red>�: {data.GetAdminName()} �������� ������ {player}. �������: ����");
    }
    private void Generate9Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"{data.GetVipPref()}{player}: ��������!! ����! ���������!!! ���������!!");
        events.Add($"<color=red>�: {data.GetAdminName()} �������� ������ {player}. �������: ����");
    }
    private void Generate10Event()
    {
        events.Clear();
        events.Add($"<color=red>�: {data.GetAdminName()} ������� ������ {data.GetPlayerName()} �� 2000 ����. �������: ������� ����");
        events.Add($"{data.GetPlayerNameWithPref()}: ����");
        events.Add($"{data.GetPlayerNameWithPref()}: ����");
    }
    private void Generate11Event()
    {
        string player = data.GetPlayerName();
        events.Clear();
        events.Add($"{data.GetVipPref()}{player}: mqmqmqmqmqmqmq!");
        events.Add($"<color=red>�: {data.GetAdminName()} ������� ������ {player} �� 30 ����. �������: ���.�����");
        events.Add($"{data.GetPlayerNameWithPref()}: ����");
    }
}
