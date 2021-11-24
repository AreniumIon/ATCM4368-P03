using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GameConstants;

public class FoeActionIndicator : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI amountText;

    FoeMan fm;

    Vector2 basePos;
    Vector2 targetPos;
    ActionInfo currentAction;

    static float MOVE_SPEED = 1.6f;

    public void SetParams(FoeMan fm)
    {
        this.fm = fm;

        basePos = transform.position;

        fm.FoeActions.changeNextActionEvent += PlayAudio;
        fm.FoeActions.changeNextActionEvent += UpdateIcon;
        fm.FoeActions.changeNextActionEvent += UpdateAmountText;
        fm.FoeActions.changeNextActionEvent += UpdateTarget;
        fm.FoeActions.changeNextActionEvent += ResetPosition;

        FoeTurnState.FoeTurnBegan += Activate;
    }

    private void OnDestroy()
    {
        FoeTurnState.FoeTurnBegan -= Activate;
    }

    private void PlayAudio(ActionInfo actionInfo)
    {
        if (currentAction != null)
            AudioHelper.PlayClip2D(AudioLibrary.audioDict[currentAction.commandID], AudioLibrary.AUDIO_VOLUME);

        currentAction = actionInfo;
    }

    private void UpdateIcon(ActionInfo actionInfo)
    {
        icon.sprite = GameConstants.commandSprites[actionInfo.commandID];
    }

    private void UpdateAmountText(ActionInfo actionInfo)
    {
        amountText.text = actionInfo.value.ToString();
    }

    private void UpdateTarget(ActionInfo actionInfo)
    {
        Attackable target = GetTarget(actionInfo.commandID);
        targetPos = target.transform.position;
    }

    private void ResetPosition(ActionInfo actionInfo)
    {
        transform.position = basePos;
    }

    public void Activate()
    {
        StartCoroutine(MathFunctions.MoveToKick(transform, targetPos, MOVE_SPEED));
    }

    private Attackable GetTarget(CommandID commandID)
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();

        switch (commandID)
        {
            default:
            case CommandID.Attack:
                if (gameMan.PlayerMan != null)
                    return gameMan.PlayerMan.PlayerHealth;
                else
                    return null;
            case CommandID.Defend:
                return gameMan.FoeMan.FoeHealth;
            case CommandID.Heal:
                return gameMan.FoeMan.FoeHealth;
        }
    }
}
