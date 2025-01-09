
using System;
using Newtonsoft.Json;
using Godot;


public static class SaveManager
{
    public static SaveData Data { get; private set; }
    public static void Save()
	{
		using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write); 

        string jsonString = JsonConvert.SerializeObject(Data);

        GD.Print(jsonString);

		saveFile.StoreLine(jsonString);
	}

	public static void Load()
	{
		using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);

    	string jsonString;
	    var json = new Json(); 

        try
        {
            jsonString = saveFile.GetLine();
            var parseResult = json.Parse(jsonString);

            Data = JsonConvert.DeserializeObject<SaveData>(jsonString);

        }catch(Exception)
        {
        }

        if(Data is null)
        {
            Data = new SaveData();
            Save();
            Load();
            return;
        }

	}
}