using UnityEngine;
public class Player : MonoBehaviour
{
   private WayPointChanger _wayPointChanger;
   private ActorData _actorData;
   private UserInput _userInput;
   private Camera _camera;
   private Weapon _weapon;
   private void Start()
   {
      _actorData=GetComponent<ActorData>();
      _wayPointChanger=GetComponent<WayPointChanger>();
      _userInput = GetComponent<UserInput>();
      _weapon = GetComponent<Weapon>();
      _camera=Camera.main;
      _userInput.OnTouch += Shoot;
      Move();
   }
   public void Move()
   {
      _actorData.ActorAnimator.Play(_actorData.Run);
      _wayPointChanger.MoveToWayPoint(transform,_actorData.MoveSpeed);
   }

   private void Shoot(Vector2 position)
   {
      var ray = _camera.ScreenPointToRay (position);
      if (Physics.Raycast(ray, out var hit))
      {
        _weapon.Shoot(hit.point);
      }
   }
   public void Idle()
   {
      _actorData.ActorAnimator.Play(_actorData.Idle);
   }
   

}
