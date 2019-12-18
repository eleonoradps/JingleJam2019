using UnityEngine;

public class ShootingTurret : MonoBehaviour
{

    [SerializeField] GameObject prefabShoot;

    [SerializeField] Transform shootSpawnPointL;

    [SerializeField] Transform shootSpawnPointR;

    private float shootSpeed = 8;

    private Rigidbody2D rb2d;

    private float timeLeft = 6.0f;

    private float timeLeftAirStrike = 10.0f;

    private float posXMin = -8f;

    private float posXMax = 8f;

    private float posY = 13f;

    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftAirStrike -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Shoot();
            timeLeft = 20.0f;
        }
        if (timeLeftAirStrike < 0)
        {
            airStrike();
            timeLeftAirStrike = 20.0f;
        }
    }

    void Shoot()
    {
        audioSource.Play();
        GameObject snowball1 = Instantiate(prefabShoot, shootSpawnPointL);

        GameObject snowball2 = Instantiate(prefabShoot, shootSpawnPointR);


        snowball1.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1) * shootSpeed;
        snowball2.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * shootSpeed;
        Destroy(snowball1, 7);
        Destroy(snowball2, 7);
    }

    void airStrike()
    {
        float posX = Random.Range(posXMin, posXMax);

        GameObject airStrike1 = Instantiate(prefabShoot, new Vector2(posX, posY), transform.rotation);
        posX = Random.Range(posXMin, posXMax);

        GameObject airStrike2 = Instantiate(prefabShoot, new Vector2(posX, posY), transform.rotation);
        posX = Random.Range(posXMin, posXMax);

        GameObject airStrike3 = Instantiate(prefabShoot, new Vector2(posX, posY), transform.rotation);

        airStrike1.GetComponent<Rigidbody2D>().velocity = Vector2.down * shootSpeed;
        airStrike2.GetComponent<Rigidbody2D>().velocity = Vector2.down * shootSpeed;
        airStrike3.GetComponent<Rigidbody2D>().velocity = Vector2.down * shootSpeed;

        Destroy(airStrike1, 5);
        Destroy(airStrike2, 5);
        Destroy(airStrike3, 5);
    }


}
