using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemInfo 
{
    private string[] names =  {"Хлопок", "Лён","Редкая Ткань","Древесина","Древесина хорошего качество","Камень","Метал","Бронза","Серебро","Золото",
    "Деталь для авто","Деталь для авто","Чип-тюнинг","Гаечный ключ","Проводка","Алюминий","Ларец с одеждой","Ларец с редкой одеждой","Смазка для видеокарты",
    "Охлаждающая жидкость","Видеокарта","Материалы","Алюминиевая бутылка","Дистиллированная вода","Грабли","Бензопила","Кирка","Сумка с инструментами","Роботизированные руки",
    "Коленвал(improve)", "КПП(improve)","Нагнетатель(improve)", "Турбокомпрессов(improve)", "Коленвал(sport)","КПП(sport)", "Нагнетатель(sport)", "Турбокомпрессор(sport)",
    "Коленвал(sport+)", "КПП(sport+)", "Нагнетатель(sport+)", "Турбокомпрессор(sport+)","Car-Box","Ларец с премией","Supercar-Box", "LuxuryCar-Box","Ларец с инструментами","Случайная машина","Best Car Box" };

    public string GetItemName(ItemId index)
    {
        return names[(int)index];
    }

    public string GetItemDescription(ItemId index)
    {
        switch (index)
        {
            case ItemId.None: return "";
            case ItemId.Linen: return "Можно добыть работая на <color=green>Ферме</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Cotton: return "Можно добыть работая на <color=green>Ферме</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.OldCloth: return "Можно добыть работая на <color=green>Ферме</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Wood: return "Можно добыть работая на <color=green>Лесопилке</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.BestWood: return "Можно добыть работая на <color=green>Лесопилке</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Stone: return "Можно добыть работая на <color=green>Шахте</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Metal: return "Можно добыть работая на <color=green>Шахте</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Bronze: return "Можно добыть работая на <color=green>Шахте</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Silver: return "Можно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Gold: return "Можно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Detail1: return "Можно добыть работая на <color=green>СТО</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Detail2: return "Можно добыть работая на <color=green>СТО</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.StageDetail: return "Можно добыть работая на <color=green>СТО</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Wrench: return "Можно добыть работая на <color=green>Стройке</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Wiring: return "Можно добыть работая на <color=green>Стройке</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Aluminum: return "Можно добыть работая на <color=green>Стройке</color>. \nМожно продать или купить на <color=green>Центральном рынке</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Cloth: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nОткройте, чтобы получить приз.\n<color=green>Ларцы можно открывать в меню дома.";
            case ItemId.EliteCloth: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nОткройте, чтобы получить приз.\n<color=green>Ларцы можно открывать в меню дома.";
            case ItemId.Lubricant: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.";
            case ItemId.Cooling: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.";
            case ItemId.Videocard: return "Можно обменять в <color=green>Ломбарде</color>. \nМожно продать в <color=green>Ломбарде</color>.";
            case ItemId.Matterial: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Bottle: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.DistilledWater: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nИспользуется в крафтах на верстаке в вашем доме.";
            case ItemId.Rake: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nПока в инвентаре, вы добываете х2ресурсы на <color=green>Ферме</color>.";
            case ItemId.Chainsaw: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nПока в инвентаре, вы добываете х2ресурсы на <color=green>Лесопилке</color>.";
            case ItemId.Pick: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nПока в инвентаре, вы добываете х2 ресурсы на <color=green>Шахте</color>.";
            case ItemId.InstrumentBag: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nПока в инвентаре, вы добываете х2 ресурсы на <color=green>СТО</color>.";
            case ItemId.AdditionalHands: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nПока в инвентаре, вы добываете х2 ресурсы на <color=green>Стройке</color>.";
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
            case ItemId.TurbocompressorSportPlus: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nИспользуется для улучшения характеристик вашего авто.";
            case ItemId.BoxSimpleCar:
            case ItemId.BoxWithBonus:
            case ItemId.BoxSuperCar:
            case ItemId.BoxLuxury: return "Можно получить участвуя в гонках. \nМожно продать в <color=green>Ломбарде</color>.\nОткройте, чтобы получить приз.\n<color=green>Ларцы можно открывать в меню дома";
            case ItemId.ToolBox: return "Можно создать в подвале вашего дома. \nМожно продать в <color=green>Ломбарде</color>.\nОткройте, чтобы получить приз.\n<color=green>Ларцы можно открывать в меню дома.";
            case ItemId.RandonCarBox: return "Можно купить за <color=yellow>AZ</color>. \nМожно продать в <color=green>Ломбарде</color>.\nОткройте, чтобы получить приз.\n<color=green>Ларцы можно открывать в меню дома.";
            case ItemId.BestCarsBox: return "Можно получить за <color=yellow>Задания</color>. \nМожно продать в <color=green>Ломбарде</color>.\nОткройте, чтобы получить приз.\n<color=green>Ларцы можно открывать в меню дома.";
            default: return "Информация по этому предмету отсутсвует!";
        }
    }
}
