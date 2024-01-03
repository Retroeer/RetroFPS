using Sandbox;
using System.Collections.Generic;
public sealed class ButtonComponent : Component, IUsable
{
	[Property] List<GameObject> ToTrigger { get; set; }
	[Property] bool TriggerOnce { get; set; } = true;


	bool Used = false;
	public void OnUse(bool value, GameObject go )
	{
		if ( TriggerOnce && !Used || !TriggerOnce )
		{
			foreach ( GameObject g in ToTrigger )
			{
				foreach ( var comp in g.Components.GetAll<IUsable>() )
				{
					comp.OnUse(true, g);
				}
			}
			Used = true;
			Sound.Play( "button.pressed", Transform.Position );
		}
	}

	public void OnToggled(bool value)
	{ }

	protected override void OnUpdate()
	{

	}


}
