using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float _Speed = 200.0f;
	private const float _JumpVelocity = -270.0f;
	
	private AnimatedSprite2D _animatedSprite;
	
	public override void _Ready() {
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add gravity
		if(!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle jump
		if(Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = _JumpVelocity;
		}
		
		// Get input direction
		Vector2 dir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		
		// Flip sprite
		if(dir.x > 0)
		{
			_animatedSprite.flip_h = false;
		} 
		else if(dir.x < 0) 
		{
			_animatedSprite.flip_h = true;
		}
		
		// Jump?
		if(IsOnFloor())
		{
			_animatedSprite.play("jump");
		}
		else
		{
			// Run or idle?
			if(dir.x == 0)
			{
				_animatedSprite.play("idle");
			} 
			else 
			{
				_animatedSprite.play("run");
			}
		}
		
		// Handle movement
		if (dir != Vector2.Zero)
		{
			velocity.X = dir.X * _Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, _Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
