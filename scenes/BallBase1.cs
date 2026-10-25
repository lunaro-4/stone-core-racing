using Godot;
using System;

namespace StoneCoreRacing
{

	[Tool]
	public partial class BallBase1 : RigidBody3D
	{

		private float _r = 1f;
		[Export(PropertyHint.Range, "0.01,30,or_greater")]
		public float Radius
		{
			get { return _r; }
			set { setRadius(value); }
		}
		

		private CollisionShape3D _collisionShape;
		private CsgSphere3D _csgSphere;
		private MeshInstance3D _csgMesh;

		public override void _Ready()
		{
			_collisionShape = FindChild("CollisionShape3D") as CollisionShape3D;
			_csgSphere = FindChild("CSGSphere3D") as CsgSphere3D;
			_csgMesh = FindChild("MeshInstance3D") as MeshInstance3D;
			updateSize();
		}


		private void updateSize()
		{
			if (_collisionShape == null) return;
			if (_csgSphere == null) return;
			if (_csgMesh == null) {
				GD.Print("MeshInstance3D not found");
				return;
			}

			//_csgSphere.Radius = _r;

			SphereShape3D sphereShape = _collisionShape.Shape as SphereShape3D;
			sphereShape.Radius = _r;
			SphereMesh sphereMesh =  _csgMesh.Mesh as SphereMesh;
			sphereMesh.Radius = _r;
			sphereMesh.Height = _r*2;

		}

		protected void setRadius(float newR)
		{
			_r = newR;
			updateSize();
		}


		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
	}
}
