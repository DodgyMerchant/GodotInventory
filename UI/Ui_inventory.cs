using Godot;
using System;

[Tool]

public partial class Ui_inventory : Control
{
	GridContainer gridContainer;
	PackedScene UIInvPacked = ResourceLoader.Load<PackedScene>("res://UI/ui_inventory_slot.tscn");

	public override void _EnterTree()
	{

	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gridContainer = GetNode<GridContainer>("NinePatchRect/MarginContainer/GridContainer");


		if (Engine.IsEditorHint())
		{

		}
		else
		{

		}

		Resized += GenerateSlots;

		GenerateSlots();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Engine.IsEditorHint())
		{
			//in editor

		}
		else
		{


		}
	}

	public void GenerateSlots()
	{
		Ui_inventory_slot child;
		if (GetChildCount(false) == 0)
		{
			child = UIInvPacked.Instantiate<Ui_inventory_slot>();
			gridContainer.AddChild(child);
		}
		else
			child = gridContainer.GetChild<Ui_inventory_slot>(0);

		var h = gridContainer.GetThemeConstant("h_separation");
		var v = gridContainer.GetThemeConstant("V_separation");

		GD.Print(gridContainer.Size.X / child.Size.X);
	}
}
