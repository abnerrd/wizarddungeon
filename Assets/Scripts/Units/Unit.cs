using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, iSelectableUnit
{
    //  TODO create modifiable Model and Base Model for stats
    private Stats _stats;

    private NavMeshAgent _navigation;
    private Vector3 _destination;
    //private bool _reachedDestination = true;
    private bool _isDestinationSet = true;

    private void Awake()
    {
        _navigation = GetComponent<NavMeshAgent>();
        _stats = _stats ?? GetComponent<Stats>() ?? gameObject.AddComponent<Stats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _navigation.speed = _stats.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateUnit();
    }

    protected void UpdateUnit()
    {
        if (!_isDestinationSet)
        {
            _navigation.SetDestination(_destination);
            _isDestinationSet = true;
        }

        /*var remainingDistance = _navigation.remainingDistance;
        if(remainingDistance != Mathf.Infinity 
            && _navigation.pathStatus == NavMeshPathStatus.PathComplete 
            && remainingDistance == 0)
        {
            _reachedDestination = true;
        }*/
    }

    public void SetDestination(Vector3 destination)
    {
        //_reachedDestination = false;
        _isDestinationSet = false;
        _destination = destination;

        UpdateUnit();
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public BuffDelivery AddBuff(InputParameters input)
    {
        var newBuff = gameObject.AddComponent<BuffDelivery>();
        newBuff.assignSpell(input.Caster, input.SpellInstance);
        return newBuff;
    }

    public void ReceiveDamage(int damage)
    { 
        _stats.Health -= damage;
    }

    public void ReceiveHealing(int restoredHealth)
    {
        //  TODO limit to caps
        _stats.Health += restoredHealth;
    }

}
