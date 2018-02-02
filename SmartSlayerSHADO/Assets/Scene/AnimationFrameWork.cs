using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationFrameWork : MonoBehaviour, IPointerEnterHandler
{
    // private int AnimationFlag;
    public Animator _TitleAnimationDelta;
    public Animator _StageSelectAnimationDelta;
    private AnimationFlag _AnimationFlag;

    enum AnimationFlag
    {
        START,
        STAGESELECT,
        BLACKOUT,
    }

	void Awake()
    {
        _AnimationFlag = AnimationFlag.START;
    }

	void Update () {
        switch (_AnimationFlag)
        {
            case AnimationFlag.START:                 
                    _AnimationFlag = AnimationFlag.STAGESELECT;            
                break;
            case AnimationFlag.STAGESELECT:
                break;
            case AnimationFlag.BLACKOUT:
                break;
            default:
                break;
        }
    }

    void FlagCheck()
    {

    }

    public void OnPointerEnter(PointerEventData EventSystem)
    {

    }
}
