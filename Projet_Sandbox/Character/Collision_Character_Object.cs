void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        // Appliquer 10 points de dégâts
        GetComponent<HealthSystem>().TakeDamage(10);
    }
}