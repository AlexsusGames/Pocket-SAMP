using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemInfo 
{
    private string[] names =  {"������", "˸�","������ �����","���������","��������� �������� ��������","������","�����","������","�������","������",
    "������ ��� ����","������ ��� ����","���-������","������� ����","��������","��������","����� � �������","����� � ������ �������","������ ��� ����������",
    "����������� ��������","����������","���������","����������� �������","���������������� ����","������","���������","�����","����� � �������������","���������������� ����",
    "��������(improve)", "���(improve)","�����������(improve)", "���������������(improve)", "��������(sport)","���(sport)", "�����������(sport)", "���������������(sport)",
    "��������(sport+)", "���(sport+)", "�����������(sport+)", "���������������(sport+)","Car-Box","����� � �������","Supercar-Box", "LuxuryCar-Box","����� � �������������","��������� ������","Best Car Box" };

    public string GetItemName(ItemId index)
    {
        return names[(int)index];
    }

    public string GetItemDescription(ItemId index)
    {
        switch (index)
        {
            case ItemId.None: return "";
            case ItemId.Linen: return "����� ������ ������� �� <color=green>�����</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Cotton: return "����� ������ ������� �� <color=green>�����</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.OldCloth: return "����� ������ ������� �� <color=green>�����</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Wood: return "����� ������ ������� �� <color=green>���������</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.BestWood: return "����� ������ ������� �� <color=green>���������</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Stone: return "����� ������ ������� �� <color=green>�����</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Metal: return "����� ������ ������� �� <color=green>�����</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Bronze: return "����� ������ ������� �� <color=green>�����</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Silver: return "����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Gold: return "����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Detail1: return "����� ������ ������� �� <color=green>���</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Detail2: return "����� ������ ������� �� <color=green>���</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.StageDetail: return "����� ������ ������� �� <color=green>���</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Wrench: return "����� ������ ������� �� <color=green>�������</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Wiring: return "����� ������ ������� �� <color=green>�������</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Aluminum: return "����� ������ ������� �� <color=green>�������</color>. \n����� ������� ��� ������ �� <color=green>����������� �����</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Cloth: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n��������, ����� �������� ����.\n<color=green>����� ����� ��������� � ���� ����.";
            case ItemId.EliteCloth: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n��������, ����� �������� ����.\n<color=green>����� ����� ��������� � ���� ����.";
            case ItemId.Lubricant: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.";
            case ItemId.Cooling: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.";
            case ItemId.Videocard: return "����� �������� � <color=green>��������</color>. \n����� ������� � <color=green>��������</color>.";
            case ItemId.Matterial: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Bottle: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.DistilledWater: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n������������ � ������� �� �������� � ����� ����.";
            case ItemId.Rake: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n���� � ���������, �� ��������� �2������� �� <color=green>�����</color>.";
            case ItemId.Chainsaw: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n���� � ���������, �� ��������� �2������� �� <color=green>���������</color>.";
            case ItemId.Pick: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n���� � ���������, �� ��������� �2 ������� �� <color=green>�����</color>.";
            case ItemId.InstrumentBag: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n���� � ���������, �� ��������� �2 ������� �� <color=green>���</color>.";
            case ItemId.AdditionalHands: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n���� � ���������, �� ��������� �2 ������� �� <color=green>�������</color>.";
            case ItemId.KppImprove: 
            case ItemId.KolenvalImprove: 
            case ItemId.NagnetatelImprove: 
            case ItemId.TurbocompressorImprove: 
            case ItemId.KppSport: 
            case ItemId.KolenvalSport:
            case ItemId.NagnetatelSport: 
            case ItemId.TurbocompressorSport: 
            case ItemId.KppSportPlus: 
            case ItemId.KolenvalSportPlus: 
            case ItemId.NagnetatelSportPlus: 
            case ItemId.TurbocompressorSportPlus: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n������������ ��� ��������� ������������� ������ ����.";
            case ItemId.BoxSimpleCar:
            case ItemId.BoxWithBonus:
            case ItemId.BoxSuperCar:
            case ItemId.BoxLuxury: return "����� �������� �������� � ������. \n����� ������� � <color=green>��������</color>.\n��������, ����� �������� ����.\n<color=green>����� ����� ��������� � ���� ����";
            case ItemId.ToolBox: return "����� ������� � ������� ������ ����. \n����� ������� � <color=green>��������</color>.\n��������, ����� �������� ����.\n<color=green>����� ����� ��������� � ���� ����.";
            case ItemId.RandonCarBox: return "����� ������ �� <color=yellow>AZ</color>. \n����� ������� � <color=green>��������</color>.\n��������, ����� �������� ����.\n<color=green>����� ����� ��������� � ���� ����.";
            case ItemId.BestCarsBox: return "����� �������� �� <color=yellow>�������</color>. \n����� ������� � <color=green>��������</color>.\n��������, ����� �������� ����.\n<color=green>����� ����� ��������� � ���� ����.";
            default: return "���������� �� ����� �������� ����������!";
        }
    }
}
