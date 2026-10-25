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
		private MeshInstance3D _csgMesh;

		public override void _Ready()
		{
			_collisionShape = FindChild("CollisionShape3D") as CollisionShape3D;
			_csgMesh = FindChild("BoxMesh") as MeshInstance3D;
			_csgMesh.Mesh = new BoxMesh();

			updateSize();
		}


		private void updateSize()
		{
			if (_collisionShape == null) {
				GD.Print("CollisionShape not found");
				return;
			};
			if (_csgMesh == null) {
				GD.Print("MeshInstance3D not found");
				return;
			};

			BoxShape3D boxShape = _collisionShape.Shape as BoxShape3D;
			BoxMesh boxMesh =  _csgMesh.Mesh as BoxMesh;
			Vector3 shapeSize = boxShape.Size;
			Vector3 size = new Vector3 (_x, _y, _z);
			boxShape.Size = size;
            boxMesh.Size = size;

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
