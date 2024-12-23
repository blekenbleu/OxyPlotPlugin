﻿namespace blekenbleu.OxyScope
{
	/// <summary>
	/// Settings class, make sure it can be correctly serialized using JSON.net
	/// </summary>
	public class Settings
	{
		public double FilterX = 1, FilterY = 1;
		public ushort Refresh = 0, LinFit = 0;
		public bool Plot = true;
		public string Xprop = "DataCorePlugin.GameData.AccelerationHeave",
					  Xprop1 = "", Xprop2 = "",
					  Yprop = "DataCorePlugin.GameData.GlobalAccelerationG";
	}
}
