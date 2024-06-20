
using UnityEngine;

public class CharacterStarts : MonoBehaviour
{
    [Header("Major start")]
    public Start strength;  // 1 điểm sẽ tăng 1 damage và 1% chí mạng
    public Start agility;   // 1 điểm sẽ tăng 1 điểm khả năng né tránh và 1% cơ hội chí mạng
    public Start intelligence;  // 1 điểm sẽ tăng 1 magic damage và 3% kháng phép
    public Start vitality;  // 1 điểm sẽ tăng 3 - 5 máu

    [Header("Defensive start")]
    public Start maxHealth;
    public Start armor;
    public Start evasion;
    
    public Start damage;
    

    [SerializeField] private int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();

       
    }

    public virtual void DoDamage(CharacterStarts _targetStarts)
    {
        if (TargetCanAvoidAttack(_targetStarts))
            return;

        int totalDamage = damage.GetValue() + strength.GetValue();
        totalDamage = CheckTargetArmor(_targetStarts, totalDamage);
        _targetStarts.TakeDamage(totalDamage);
    }


    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        Debug.Log(_damage);

        if (currentHealth < 0)
            Die();
    }

    protected virtual void Die()
    {
        //throw new NotImplementedException();
    }
    private int CheckTargetArmor(CharacterStarts _targetStarts, int totalDamage)
    {
        totalDamage -= _targetStarts.armor.GetValue();
        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }
    private bool TargetCanAvoidAttack(CharacterStarts _targetStarts)
    {
        int totalEvasion = _targetStarts.evasion.GetValue() + _targetStarts.agility.GetValue();

        if (Random.Range(0, 100) < totalEvasion)
        {
            
            return true;
        }
        return false;
    }
}
