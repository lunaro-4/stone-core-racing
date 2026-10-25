using Godot;
using System;

namespace StoneCoreRacing
{

	[Tool]
	public partial class GuardedSegment : Node3D
	{

		private float _x = 1f;
		[Export(PropertyHint.Range, "0.01,30,or_greater")]
		public float XSize
		{
			get { return _x; }
			set { setX(value); }
		}
		
		private float _y = 1f;
		[Export(PropertyHint.Range, "0.01,30,or_greater")]
		public float YSize
		{
			get { return _y; }
			set { setY(value); }
		}

		private float _z = 1f;
		[Export(PropertyHint.Range, "0.01,30,or_greater")]
		public float ZSize
		{
			get { return _z; }
			set { setZ(value); }
		}

		private FlatBox Bottom;
		private FlatBox Left;
		private FlatBox Right;

		private const float GUARD_SIZE = 0.5f;

		public override void _Ready()
		{
            Bottom = FindChild("Bottom") as FlatBox;
            Left = FindChild("Left") as FlatBox;
            Right = FindChild("Right") as FlatBox;

			updateSize();
		}


		private void updateSize()
		{
			if (Bottom == null) {
                GD.Print("Bottom not found");
				return;
			}

			if (Left == null) {
                GD.Print("Left not found");
                return;
			}

			if (Right == null) {
                GD.Print("Right not found");
				return;
			}

			Vector3 leftPos = new Vector3(-_x/2 + GUARD_SIZE/2, _y/2, 0);
			Vector3 rightPos = new Vector3(_x/2 - GUARD_SIZE/2, _y/2, 0);

            Left.Position = leftPos;
            Right.Position = rightPos;

		
            Bottom.XSize = _x;
			Bottom.ZSize = _z;
			Left.YSize = _y;
			Left.XSize = GUARD_SIZE;
			Left.ZSize = _z;
            Right.YSize = _y;
            Right.XSize = GUARD_SIZE;
			Right.ZSize = _z;

		}

		protected void setX(float newX)
		{
			_x = newX;
			updateSize();
		}
		protected void setY(float newY)
		{
			_y = newY;
			updateSize();
		}

		protected void setZ(float newZ)
		{
			_z = newZ;
			updateSize();
		}



		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
	}
}
