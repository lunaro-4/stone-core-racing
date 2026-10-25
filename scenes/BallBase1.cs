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
		private MeshInstance3D _csgMesh;
		private Texture2D texture = ResourceLoader.Load<CompressedTexture2D>("res://icon.svg");

		public override void _Ready()
		{
			_collisionShape = FindChild("CollisionShape3D") as CollisionShape3D;
			_csgMesh = FindChild("MeshInstance3D") as MeshInstance3D;
			makeAppearance();
			updateSize();
		}


		private void updateSize()
		{
			if (_collisionShape == null) return;
			if (_csgMesh == null) {
				GD.Print("MeshInstance3D not found");
				return;
			}


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


		protected void makeAppearance()
		{
			SphereMesh newMesh = new SphereMesh();
			StandardMaterial3D newMaterial = new StandardMaterial3D();
			// newMaterial.AlbedoColor = Colors.Red;
			newMaterial.AlbedoTexture = texture;

			newMesh.Material = newMaterial;
			_csgMesh.Mesh = newMesh;

		}

	}
}
