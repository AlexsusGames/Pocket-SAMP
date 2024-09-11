using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SkinDataChanger 
{
    private SkinData data = new SkinData();
    private const string Key = "SkinDataSave";

    private void SaveData()
    {
        string save = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(Key, save);
    }

    private void LoadData()
    {
        if(PlayerPrefs.HasKey(Key))
        {
            string save = PlayerPrefs.GetString(Key);
            data = JsonUtility.FromJson<SkinData>(save);
        }
        else CreateData();
    }

    private void CreateData()
    {
        for (int i = 0; i < 11; i++)
        {
            data.progress.Add(new SkinProgress());
        }
        data.progress[0].Name = "����";
        data.progress[0].Price = 0;
        data.progress[0].IsOpen = true;
        data.progress[0].Character = "- ������.";
        data.progress[1].Name = "������";
        data.progress[1].Price = 1000;
        data.progress[1].IsOpen = false;
        data.progress[1].Character = "- ����� �������� �� �����.";
        data.progress[2].Name = "��������";
        data.progress[2].Price = 2500;
        data.progress[2].IsOpen = false;
        data.progress[2].Character = "- ����� �������� �� ���������.";
        data.progress[3].Name = "������";
        data.progress[3].Price = 10000;
        data.progress[3].IsOpen = false;
        data.progress[3].Character = "- ����� �������� �� �����.";
        data.progress[4].Name = "�������";
        data.progress[4].Price = 150000;
        data.progress[4].IsOpen = false;
        data.progress[4].Character = "- ����� �������� � ���.";
        data.progress[5].Name = "���������";
        data.progress[5].Price = 500000;
        data.progress[5].IsOpen = false;
        data.progress[5].Character = "- ����� �������� �� �������.";
        data.progress[6].Name = "��������� ����";
        data.progress[6].Price = 10000;
        data.progress[6].IsOpen = false;
        data.progress[6].Character = "- �� ������\n- ������� � ������.";
        data.progress[7].Name = "������";
        data.progress[7].Price = 50000;
        data.progress[7].IsOpen = false;
        data.progress[7].Character = "- ��������.\n- ������.\n- ������.\n- ���� �� ������� ������� � ��������� ��������.";
        data.progress[8].Name = "���������";
        data.progress[8].Price = 120000;
        data.progress[8].IsOpen = false;
        data.progress[8].Character = "- ���� �� ������� ������� � ��������� ��������.\n- ���� �� ������� ������� � ��������� ��������.";
        data.progress[9].Name = "������";
        data.progress[9].Price = 5000000;
        data.progress[9].IsOpen = false;
        data.progress[9].Character = "- ���� �� ������� ������� � ��������� ��������.\n- ���� �� ������� ������� � ��������� ��������.\n- ���� ������ � ��� ���� ����.";
        data.progress[10].Name = "����������";
        data.progress[10].Price = 10000000;
        data.progress[10].IsOpen = false;
        data.progress[10].Character = "- ���� �� ������� ������� � ��������� ��� ��������.\n- ���� �� ������� ������� � ��������� ��������.\n- ���� ������ � ��� ���� ����.\n- ������� �������� �2 �������.";
    }

    public SkinData GetSkinData()
    {
        LoadData();
        return data;
    }
    public void ChangeProgress(int index, bool progress)
    {
        LoadData();
        data.progress[index].IsOpen = progress;
        SaveData();
    }
    public (bool value, int moneyCount, string name) UnlockRandomSkin(bool isWorkSkin)
    {
        int random = isWorkSkin ? Random.Range(1, 6) : Random.Range(6, 11);
        LoadData();
        if (data.progress[random].IsOpen) return (false, data.progress[random].Price, data.progress[random].Name);
        else
        {
            data.progress[random].IsOpen = true;
            SaveData();
            return (true, 0, data.progress[random].Name);
        }
    }
}
