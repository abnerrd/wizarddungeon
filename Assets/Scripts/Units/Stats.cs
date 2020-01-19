using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Health = 15;

    [SerializeField]
    private int Attack = 1;

    [SerializeField]
    private int Magic = 1;

    [SerializeField]
    private int PhyDefense = 1;

    [SerializeField]
    private int MagDefense = 1;

    [SerializeField]
    private int Accuracy = 1;

    [SerializeField]
    private int _speed = 15;
    public int Speed => _speed;

    [SerializeField]
    private int Evasion = 1;
    [SerializeField]
    private int AttackSpeed = 1;
}

public enum Statistic
{
    None = -1,

    //  Base Stats
    Health,
    PhyAttack,
    MagAttack,
    PhyDefense,
    MagDefense,
    Accuracy,
    Speed,
    Evasion,
    AttackSpeed
}