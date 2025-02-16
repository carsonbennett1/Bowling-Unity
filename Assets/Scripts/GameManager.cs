using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float score = 0;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    private GameObject pinObjects;
    private FallTrigger[] pins;
    private FallTrigger[] fallTriggers;

    private void Start()
    {
        pins = FindObjectsByType<FallTrigger>((FindObjectsSortMode)FindObjectsInactive.Include);
        foreach(FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();

    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        if (pinObjects)
        {
            foreach(Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }

            Destroy(pinObjects);
        }

        pinObjects = Instantiate(pinCollection,
                                    pinAnchor.transform.position,
                                    Quaternion.identity, transform);

        // fallTriggers = FindAnyObjectByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
