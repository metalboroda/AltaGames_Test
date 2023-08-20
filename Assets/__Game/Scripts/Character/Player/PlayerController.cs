using Assets.__Game.Scripts.Character.Player.States;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerController : CharacterControllerRoot
  {
    public Player Player { get; private set; }
    public PlayerShoot PlayerShoot { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerCollider PlayerCollider { get; private set; }

    protected override void Awake()
    {
      Player = GetComponent<Player>();
      PlayerShoot = GetComponent<PlayerShoot>();
      PlayerMovement = GetComponent<PlayerMovement>();
      PlayerCollider = GetComponentInChildren<PlayerCollider>();

      base.Awake();

      StateMachineController.Initialize(new PlayerIdleState(this));

      Init();
    }

    private void Start()
    {
      StateMachineController.ChangeState(new PlayerCombatState(this));
    }

    protected override void Update()
    {
      base.Update();
    }

    private void Init()
    {
      Player.Init(this);
      PlayerShoot.Init(this);
      PlayerCollider.Init(this);
    }
  }
}