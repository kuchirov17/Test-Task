using Cinemachine;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _horizontalMovement = 0f;
    private float _verticalMovement = 0f;
    [SerializeField]
    private Rigidbody _movableBody;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Ui _uiManager;
    

    public float Distance;
    public float Timer = 0;

    [SerializeField]
    private CinemachineVirtualCamera _distanceCheckCamera;
    [SerializeField]
    private CinemachineTrackedDolly _distanceTrackComponent;
    [SerializeField]
    private CinemachinePath _path;
    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (GameManager.GameStarted)
        {
            _horizontalMovement = Input.GetAxis("Horizontal");
            _verticalMovement = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(
                -_verticalMovement * _speed * Time.deltaTime, 
                0f,
                _horizontalMovement * _speed * Time.deltaTime);
            _movableBody.MovePosition(transform.position+dir);
            Distance = _distanceTrackComponent.m_PathPosition;
            Timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.Escape))
            {
                GameManager.Reload(false,Timer,Distance);
                _uiManager.OpenMainScreen();
                _distanceCheckCamera.Follow = null;
                _distanceTrackComponent.m_PathPosition = 0;
            }
        }
        
    }

    public void InitializePlayerTracking()
    {
        _distanceTrackComponent = _distanceCheckCamera.AddCinemachineComponent<CinemachineTrackedDolly>();
        _distanceTrackComponent.m_Path = _path;
        _distanceTrackComponent.m_PathPosition = 0f;
        _distanceCheckCamera.Follow = gameObject.transform;
        _distanceTrackComponent.m_PositionUnits = CinemachinePathBase.PositionUnits.Distance;
        _distanceTrackComponent.m_AutoDolly.m_Enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "FinishPosition":
            {
                GameManager.Reload(true,Timer,Distance);
                _distanceCheckCamera.Follow = null;
                _distanceTrackComponent.m_PathPosition = 0;
                break;
            }

            case "Bottom":
            {
                GameManager.Reload(false,Timer,Distance);
                _distanceCheckCamera.Follow = null;
                _distanceTrackComponent.m_PathPosition = 0;
                break;
            }

        }
    }
}
