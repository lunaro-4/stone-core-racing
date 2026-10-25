using Godot;
using System;

namespace StoneCoreRacing
{

	[Tool]
	public partial class FlatBox : StaticBody3D
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

		private CollisionShape3D _collisionShape;
		private CsgBox3D _csgBox;

		public override void _Ready()
		{
			_collisionShape = FindChild("CollisionShape3D") as CollisionShape3D;
			_csgBox = FindChild("CSGBox3D") as CsgBox3D;
			updateSize();
		}


		private void updateSize()
		{
			if (_collisionShape == null) return;
			BoxShape3D boxShape = _collisionShape.Shape as BoxShape3D;
			Vector3 shapeSize = boxShape.Size;
			if (_csgBox == null) return;
			Vector3 size = _csgBox.Size;

			if (shapeSize != null)
				shapeSize = new Vector3 (_x, _y, _z);
			if (_csgBox != null)
				size = new Vector3 (_x, _y, _z);
			boxShape.Size = shapeSize;
			// _collisionShape.Shape = boxShape;
			_csgBox.Size = size;

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
