using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementEvent m_onBeginMove = new MovementEvent();
    public MovementEvent GetOnBeginMove { get { return m_onBeginMove; } }

    [SerializeField] private MovementEvent m_onMove = new MovementEvent();
    public MovementEvent GetOnMove { get { return m_onMove; } }

    [SerializeField] private UnityEvent m_onEndMove = new UnityEvent();
    public UnityEvent GetOnEndMove { get { return m_onEndMove; } }

    [SerializeField] private LayerMask m_movementMask = 0;
    public LayerMask GetMovementMask { get { return m_movementMask; } }

    [SerializeField] private float m_speed = 10f;
    public float speed { get { return m_speed; } }

    [SerializeField, NaughtyAttributes.ReorderableList] PlayerMovementStrategy[] m_mouvementStrat = { };

    private PlayerMovementStrategy m_activeStrat = null;

    private void Update()
    {
        foreach (PlayerMovementStrategy strat in m_mouvementStrat)
        {
            if (strat.CanUseStrat(this))
            {
                if (strat != m_activeStrat)
                {
                    if (m_activeStrat != null)
                    {
                        m_activeStrat.OnEndUseStrat(this);
                    }

                    m_activeStrat = strat;
                    m_activeStrat.OnBeginUseStrat(this);
                }

                strat.UpdateMovement(this, Time.deltaTime);
                break;
            }
        }
    }
}