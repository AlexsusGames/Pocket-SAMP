using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button clickButton;
    [SerializeField] private CharacterNeeds needs;
    private WorkPayment payment;

    public void SetData(WorkPayment payment)
    {
        this.payment = payment;
        clickButton.onClick.AddListener(Click);
    }
    private void Click()
    {
        payment.Click();
        needs.DoAction();
    }
}
