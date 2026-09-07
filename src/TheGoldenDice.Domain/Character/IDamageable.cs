namespace TheGoldenDice.Domain.Character;

public interface IDamageable
{
	int MaxHp { get; set; }
	int CurrentHp { get; set; }

	void TakeDamage(int damagePoints);
	void Heal(int healPoints);

}