using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoeActionIndicator : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI amountText;

    FoeMan fm;

    public void SetParams(FoeMan fm)
    {
        this.fm = fm;

        fm.FoeActions.changeNextActionEvent += UpdateIcon;
        fm.FoeActions.changeNextActionEvent += UpdateAmountText;
    }

    private void UpdateIcon(ActionInfo actionInfo)
    {
        icon.sprite = GameConstants.commandSprites[actionInfo.commandID];
    }

    private void UpdateAmountText(ActionInfo actionInfo)
    {
        amountText.text = actionInfo.value.ToString();
    }

}
