using Sandbox;
using Sandbox.Internal;
using System;

namespace MyGame;

public class PawnAnimator : EntityComponent<Pawn>, ISingletonComponent
{
	public void Simulate()
	{
		var helper = new CitizenAnimationHelper( Entity );
		helper.WithVelocity( Entity.Velocity );
		helper.WithLookAt( Entity.EyePosition + Entity.EyeRotation.Forward * 100 );
		helper.HoldType = CitizenAnimationHelper.HoldTypes.None;
		helper.IsGrounded = Entity.GroundEntity.IsValid();

		if ( Entity.Controller.HasEvent( "jump" ) )
		{
			helper.TriggerJump();
		}

		if( Entity.Controller.HasEvent( "crouch" ) )
		{
			helper.DuckLevel = 1f;
		}

		if ( Entity.Controller.HasEvent( "uncrouch" ) )
		{
			helper.DuckLevel = 0f;
		}
	}
}
