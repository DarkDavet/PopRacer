using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : Singleton<LogicManager>
{
    [SerializeField]
    AbstractGameEvent m_WinEvent;

    [SerializeField]
    AbstractGameEvent m_LoseEvent;

    public void Win()
    {
        m_WinEvent.Raise();
    }

    public void Lose()
    {
        m_LoseEvent.Raise();

    }
}

