namespace HealthSystem
{
    public interface IHealthSystem
    {
        void ApplyDamage(int damage);

        void Recovery(int health);

        void Revival();
    }
}