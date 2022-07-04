using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public string charName = "";
    public float health = 100;
    public float maxHealth = 100;
    public float mana = 100;
    public float maxMana = 100;
    public float defence = 10;
    public float speed = 1;

    public List<Ability> abilities;

    protected float turnTimer = 0;
    protected float turnTimerMax = 100;
    protected bool isTurnTimerActive = false;

    public delegate void HealthEventHandler(float health);
    public event HealthEventHandler OnHealthChanged;
    public delegate void TurnTimerEventHandler(float time);
    public event TurnTimerEventHandler OnTurnTimeChanged;
    public delegate void ManaEventHandler(float mana);
    public event ManaEventHandler OnManaChanged;

    public delegate void PlayerEventTakeTurn(Hero hero);
    public event PlayerEventTakeTurn OnTakeActiveTurn;
    public delegate void PlayerEventEndTurn();
    public event PlayerEventEndTurn OnEndTurn;

    private void Start()
    {
        isTurnTimerActive = true;
        if (FindObjectOfType<BattleManager>())
        {
            BattleManager.OnActiveTurn += ToggleTurnTimer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTurnTimerActive)
            ChargeTurnTimer();
    }
    public virtual void ToggleTurnTimer(bool value)
    {
        isTurnTimerActive = !value;
    }
    public virtual void Attack(Enemy enemy)
    {
        Debug.Log(gameObject.name + " attacked " + enemy.gameObject.name);
        enemy.TakeDamage(10); //placeholder damage
        EndTurn();
    }

    public virtual void UseAbility(Enemy enemy, Ability ability)
    {
        ability.TriggerAbility(this, enemy);
        mana -= ability.manaCost;
        if (OnTurnTimeChanged != null)
            OnManaChanged.Invoke(mana);
    }

    public virtual void Defend()
    {
        defence *= 2;
        Debug.Log(gameObject.name + " defends.");
        EndTurn();
    }

    public virtual void TakeDamage(float rawDamage)
    {
        float damage = rawDamage - defence;
        if (damage < 0)
            damage = 0;
        health -= damage;
        if (OnHealthChanged != null)
            OnHealthChanged.Invoke(health);
    }

    //Charges character's turn meter based on it's speed.
    public virtual void ChargeTurnTimer()
    {
        if (turnTimer < turnTimerMax)
        {
            turnTimer += Time.deltaTime * speed;
            if (OnTurnTimeChanged != null)
                OnTurnTimeChanged.Invoke(turnTimer);
        }
        else if (turnTimer > turnTimerMax)
        {
            TakeTurn();
            Debug.Log(gameObject.name + " has reached it's turn.");
        }
    }

    public virtual void TakeTurn()
    {
        //BattleManager.Instance.TakeActiveTurn(this);
        OnTakeActiveTurn.Invoke(this);
    }

    public virtual void EndTurn()
    {
        turnTimer = 0;
        //BattleManager.Instance.EndTurn();
        OnEndTurn.Invoke();
    }

}