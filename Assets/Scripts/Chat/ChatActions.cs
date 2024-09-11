using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatActions 
{
    private List<string> PlayersList = new List<string>();
    private List<string> playersNames = new List<string>
    {
        "Miron_Sacura[24]", "Hanry_Butch[1]","Wesley_Mouch[777]", "Gavin_Zhukov[2]",
        "Aaron_Filippov[6]", "Jason_Belov[7]","Hunter_Antonov[8]","Adam_Bogdanov[71]",
        "Ethan_Black[29]", "Lucas_Morgan[223]","Victoria_Cruz[87]", "Blake_Garcia[66]",
        "Zoe_Ramirez[561]", "Maya_Gonzalez[901]","Leo_Johnson[991]","Roy_Shellby[228]",
        "Max_Ward[431]", "David_Gonzalez[90]", "Oliver_Moore[870]", "Zoe_Hayes[92]","Nicolas_Gepa[117]",
        "Brandon_Rodriguez[146]", "Angel_Ramirez[454]"
    };
    public List<string> playersNamesForStats = new List<string>
    {
        "Miron_Sacura", "Hanry_Butch","Wesley_Mouch", "Gavin_Zhukov",
        "Aaron_Filippov", "Jason_Belov","Hunter_Antonov","Adam_Bogdanov",
        "Ethan_Black", "Lucas_Morgan","Victoria_Cruz", "Blake_Garcia",
        "Zoe_Ramirez", "Maya_Gonzalez","Leo_Johnson","Roy_Shellby",
        "Max_Ward", "David_Gonzalez", "Oliver_Moore", "Zoe_Hayes","Nicolas_Gepa","Roy_Shelby", "Conor", "Sam_Mason", "Farmer",
        "Maras_Shakur","Yuki_Lane", "Bogdan_Strelkov", "Mike_Watson",
        "Andrei_Moroz","Sebastian_Disney", "Diana_Mironova",
        "Marco_Bee", "Leonardo_Toren", "Aleksandr_Rencov",
        "Brandon_Rodriguez", "Angel_Ramirez"
    };
    private List<string> adminsNames = new List<string>
    {
        "Roy_Shelby[0]", "Conor[808]", "Sam_Mason[404]", "Farmer[9]",
        "Maras_Shakur[13]","Yuki_Lane[100]", "Bogdan_Strelkov[200]", "Mike_Watson[43]",
        "Andrei_Moroz[97]","Sebastian_Disney[27]", "Diana_Mironova[133]",
        "Marco_Beer[954]", "Leonardo_Toren[213]", "Aleksandr_Rencov[591]",
    };
    private List<string> vipPrefs = new List<string>
    {
       "<color=yellow>[ADMIN]</color>", "<color=red>[VIP ADV]</color>", "<color=#FF14EB>[FOREVER]</color>",
        "<color=#FF14EB>[PREMIUM]</color>","<color=#0494ff>[VIP]</color>"
    };
    private List<string> playersActions = new List<string>
    {
        "����� ���", "����� ������ �� 80��", "����� �� 100�: ������78", "��� ������� ������� 77", "������� ������, �������",
        "������ � �������", "����� ��� � ������� ������", "��� �����", "��� ������ �� ������ '�����'","����� BMW", "������ � ����",
        "����� ����", "������ ����� � ������� �����", "�������� ����� � �� ������","����� ����� ������","������� ����� ��� -90?",
        "������ � ������ ��� -90", "������ ������� ��� +12","������� � �����","���� ������ ����-��?","��� ����� ������� ��?",
        "�������� �� ��� 245 ���", "������ ��������� ������", "������ �� ������� ���?","���� �����","�������� ����� � ���������",
        "�������� ����� � ����� ��","�������� ����� � �������������", "�� �4 ������", "������ ���� ������","������ ��",
        "������ ��","���� ������","����� '�����������' ���� ����� ����������","���� ������ � ����?","����� � �������, ������ ID",
        "���","�������� � ��, ������� 895", "����� ���� 911","������� ������ �� ���� ������","��������� � ����","�������� � ���� ������!!",
        "������� ����� �� ����", "������ �����","����� ���������","������ ���������. �������","���� ���� � ��� ���"
    };
    public List<string> adminActions = new List<string>
    {
        "�������� ������", "������� ������", "����� ��� ������� ������", "������� � �������� ������"
    };
    public List<string> funnyReasons = new List<string>
    {
        "������","����","�����","�����","������"
    };

    private List<string> banReasons = new List<string>
    {
        "�� 60 �����. �������: ���","�� 120 ���. �������: ���","�� 300 �����. �������: ���.���", "�� 300 �����. �������: ���.�������",
        "�� 5 ����. �������: ���� ��", "�� 30 ����. �������: ���", "�� 30 ����. �������: ���.���", "�� 30 ����. �������: �������",
        "�� 60 �����. �������: ������", "�� 120 �����. �������: ���", "�� 300 �����. �������: ���������", "�� 30 �����. �������: ������",
        "�� 30 �����. �������: �����", "�� 60 �����. �������: ����", "�� 120 �����. �������: ��","�� 120 �����. �������: ��",
        "�� 300 �����. �������: ���� ��", "�� 300 �����. �������: ���� ��"
    };
    private List<string> adActions = new List<string>
    {
        "�����", "�����", "�������","�������", "������", "������", "���� � ������", "���� � ������", "���������", "����� � ���","�������� �� ���",
        "�������� �� ���", "����� � ������� ����"
    };
    private List<string> property = new List<string>
    {
        "����� ������","ADD VIP","���������","����� �����","������","������","�����","������ ���", "����","���","�������", "����", "����","�������",
        "�����������","������","������","Infernus","Bullet","Turismo","Bus","NRG-500","Maverick","Tropic","DFT-30","Shamal",
        "Manana","BMW M5 E60","BMW M5 F90","Porsche Panamera","BMW 530i E39","Mercedes-Benz E 55 AMG","Range Rover","Audi R8","Lexus LX600",
        "BMX","Fiat 500","Luxor","BMW X5m","BMW X7","Bentley Balacar","Bentley","Bugatti Chiron","Delorean","Ferrari F40","LADA Priora",
        "Lamborghini","Mazda 6","Mercedes E63","Mercedes S63 AMG","Nissan 350Z","Nissan GTR 2017","Toyota GR"
    };
    private List<string> carboxes = new List<string>
    {
        "����� � �������","����� �����������","����� �������������","����� ��������","Super Car Box",
    };
    private List<string> Donates = new List<string>
    {
        "1000000$","5000000$","7777777$","10000000$","50000000$",
    };

    public void GeneratePlayerList()
    {
        for (int i = 0; i < playersNames.Count; i++)
        {
            PlayersList.Add($"{GetVipPref()}{playersNames[i]}");
        }
    }
    public void SetNamesList(List<string> namesList)
    {
        PlayersList = namesList;
    }
    public List<string> GetNamesList()
    {
        return PlayersList;
    }
    public string GetPlayerName()
    {
        return playersNames[Random.Range(0, playersNames.Count)];
    }
    public string GetPlayerNameWithPref()
    {
        return PlayersList[Random.Range(0, PlayersList.Count)];
    }
    public string GetAdminName()
    {
        return adminsNames[Random.Range(1, adminsNames.Count)];
    }
    public string GetAdminVip()
    {
        return vipPrefs[0];
    }
   public string GetVipPref()
    {
        return vipPrefs[Random.Range(2,vipPrefs.Count)];
    }
    private string GetPlayerAction()
    {
        string msg = $"{GetPlayerNameWithPref()}: {playersActions[Random.Range(0,playersActions.Count)]}";
        return msg;
    }
    private string GetAdminAction()
    {
        int randomNum1 = Random.Range(0, 4);
        int randomNum2 = Random.Range(0, 4);
        string msg = $"<color=red>�: {GetAdminName()} {adminActions[randomNum1]} {GetPlayerName()} {banReasons[randomNum1 * 4 + randomNum2]}</color>";
        return msg;
    }
    private string GetProperty()
    {
        return property[Random.Range(0, property.Count)];
    }
    public string GetCar()
    {
        return property[Random.Range(17,property.Count)];
    }
    public string GetCarBox()
    {
        return carboxes[Random.Range(0, carboxes.Count)];
    }
    public string GetDonate()
    {
        return Donates[Random.Range(0, Donates.Count)];
    }
    private string GetAd()
    {
        return adActions[Random.Range(0, adActions.Count)];
    }
    public string GetNumber()
    {
        string result = $"������� {Random.Range(1111111,9999999)}";
        return result;
    }
    private string GetAdMsg()
    {
        string number = Random.Range(1,11) > 4? "" : GetNumber();
        string msg = $"{vipPrefs[1]}{GetPlayerName()}: {GetAd()} {GetProperty()} {number}";
        return msg;
    }
    public string GetMsg()
    {
        int random = Random.Range(0, 11);
        if (random > 7) return GetPlayerAction();
        else if (random < 6) return GetAdMsg();
        else return GetAdminAction();
    }
}
