using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum eMovement
{
    M_STOP = 0,
    M_WALK,
    M_RUN
}

interface iMovement
{
    Vector3 GetFaceDirection();
    void    Move();
    void    CollectSound();
    void    UseSound();
}

enum eSoundPokect
{
    SP_EMPTY = 0,
    SP_RECEIVING,
    SP_FREE,
    SP_USING
}

interface iSoundPokect
{
    eSoundPokect CheckSoundPokectStatus();
    ref cSound   GetSound();
    void         ReceiveSound(ref cSound sound);
    void         ReleaseSound();
}

enum eSoundOperate
{
    SO_ENABLE = 0,
    SO_DISABLE
}

interface iSoundOperate
{
    eSoundOperate CheckSoundOperateStatus(ref GameObject obj);
    void          UseSound(ref GameObject obj);
}

enum ePropertyType
{
    PT_ENERGY = 0,
}

interface iPropertyManager
{
    float GetCurrentValue(ePropertyType type);
    float GetMaxValue(ePropertyType type);
    float AddValue(ePropertyType type);
    float ReduceValue(ePropertyType type);
}

interface iColliderResponse
{
    void GetListOfEventInRange(ref List<GameObject> list);
}

enum eInputStatus
{
    IS_RECEIVE = 0x1,
    IS_USE = 0x2,
    IS_RELEASE = 0x4,
}

interface iInput
{
    Vector2 GetInputVector2D();
    Vector3 GetInputVector3D();
    void GetInputStream();
}