/// playgames v1.3.0 Para UndertaleModTool
/// @author Booker-Mcarthur
/// @version v1.0

void Thecakeisalie()
{
	var extension = new UndertaleExtension()
	{
		ClassName = Data.Strings.MakeString("YYGooglePlayServices"),
		FolderName = Data.Strings.MakeString(""),
		Name = Data.Strings.MakeString("GooglePlayServices"),
		Version = Data.Strings.MakeString("1.3.0"),
		Files = new UndertalePointerList<UndertaleExtensionFile>()
	};
	
	extension.Files.Add(
		new UndertaleExtensionFile()
		{
			Filename = Data.Strings.MakeString("GooglePlayServices.ext"),
			InitScript = Data.Strings.MakeString(""),
			CleanupScript = Data.Strings.MakeString(""),
			Kind = UndertaleExtensionKind.Generic,
			Functions = new UndertalePointerList<UndertaleExtensionFunction>()
			{
				new UndertaleExtensionFunction()
				{
					ID = 98,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Achievements_Show"),
					Kind = 98,
					Name = Data.Strings.MakeString("googleplayservices_achievements_Show"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.Double
				},
			    new UndertaleExtensionFunction()
				{
					ID = 99,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Achievements_Increment"),
					Kind = 99,
					Name = Data.Strings.MakeString("googleplayservices_achievements_Increment"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
					{
						new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
						new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
					},
					RetType = UndertaleExtensionVarType.Double
				},
			    new UndertaleExtensionFunction()
				{
					ID = 100,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Achievements_Reveal"),
					Kind = 100,
					Name = Data.Strings.MakeString("googleplayservices_achievements_Reveal"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
					{
						new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
					},
					RetType = UndertaleExtensionVarType.Double
				},
			    new UndertaleExtensionFunction()
				{
					ID = 101,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Achievements_SetSteps"),
					Kind = 101,
					Name = Data.Strings.MakeString("googleplayservices_achievements_SetSteps"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
					{
						new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                        new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
					},
					RetType = UndertaleExtensionVarType.Double
				},
                new UndertaleExtensionFunction()
				{
					ID = 102,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Achievements_Unlock"),
					Kind = 102,
					Name = Data.Strings.MakeString("googleplayservices_achievements_Unlock"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
					{
						new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
    
					},
					RetType = UndertaleExtensionVarType.Double
				},
                  new UndertaleExtensionFunction()
				{
					ID = 103,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Achievements_GetStatus"),
					Kind = 103,
					Name = Data.Strings.MakeString("googleplayservices_achievements_GetStatus"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
					{
						new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
    
					},
					RetType = UndertaleExtensionVarType.String
				},
                  new UndertaleExtensionFunction()
				{
					ID = 104,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Leaderboard_ShowAll"),
					Kind = 104,
					Name = Data.Strings.MakeString("googleplayservices_leaderboard_ShowAll"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.Double
				},
                  new UndertaleExtensionFunction()
				{
					ID = 105,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Leaderboard_Show"),
					Kind = 105,
					Name = Data.Strings.MakeString("googleplayservices_leaderboard_Show"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                new UndertaleExtensionFunction()
				{
					ID = 106,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Leaderboard_SubmitScore"),
					Kind = 106,
					Name = Data.Strings.MakeString("googleplayservices_leaderboard_SubmitScore"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                 new UndertaleExtensionFunction()
				{
					ID = 107,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Leaderboard_LoadPlayerCenteredScores"),
					Kind = 107,
					Name = Data.Strings.MakeString("googleplayservices_leaderboard_LoadPlayerCenteredScores"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                new UndertaleExtensionFunction()
				{
					ID = 108,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Leaderboard_LoadTopScores"),
					Kind = 108,
					Name = Data.Strings.MakeString("googleplayservices_leaderboard_LoadTopScores"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                    },
					RetType = UndertaleExtensionVarType.String
				},
                new UndertaleExtensionFunction()
				{
					ID = 109,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SavedGames_ShowSavedGamesUI"),
					Kind = 109,
					Name = Data.Strings.MakeString("googleplayservices_savedGames_ShowSavedGamesUI"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                new UndertaleExtensionFunction()
				{
					ID = 110,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SavedGames_CommitAndClose"),
					Kind = 110,
					Name = Data.Strings.MakeString("googleplayservices_savedGames_CommitAndClose"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                new UndertaleExtensionFunction()
				{
					ID = 111,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SavedGames_Load"),
					Kind = 111,
					Name = Data.Strings.MakeString("googleplayservices_savedGames_Load"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                new UndertaleExtensionFunction()
				{
					ID = 112,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SavedGames_Delete"),
					Kind = 112,
					Name = Data.Strings.MakeString("googleplayservices_savedGames_Delete"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                new UndertaleExtensionFunction()
				{
					ID = 113,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SavedGames_DiscardAndClose"),
					Kind = 113,
					Name = Data.Strings.MakeString("googleplayservices_savedGames_DiscardAndClose"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                  new UndertaleExtensionFunction()
				{
					ID = 114,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SavedGames_Open"),
					Kind = 114,
					Name = Data.Strings.MakeString("googleplayservices_savedGames_Open"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                   new UndertaleExtensionFunction()
				{
					ID = 115,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SavedGames_ResolveConflict"),
					Kind = 115,
					Name = Data.Strings.MakeString("googleplayservices_savedGames_ResolveConflict"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.Double
				},
                  new UndertaleExtensionFunction()
				{
					ID = 116,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SavedGames_CommitNew"),
					Kind = 116,
					Name = Data.Strings.MakeString("googleplayservices_savedGames_CommitNew"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                  new UndertaleExtensionFunction()
				{
					ID = 117,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Player_Current"),
					Kind = 117,
					Name = Data.Strings.MakeString("googleplayServices_player_Current"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.String
				},
                  new UndertaleExtensionFunction()
				{
					ID = 118,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Player_CurrentID"),
					Kind = 118,
					Name = Data.Strings.MakeString("googleplayServices_player_CurrentID"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.String
				},
                 new UndertaleExtensionFunction()
				{
					ID = 119,
					ExtName = Data.Strings.MakeString("GooglePlayServices_UriToPath"),
					Kind = 119,
					Name = Data.Strings.MakeString("googlePlayServices_UriToPath"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.Double
				},
                  new UndertaleExtensionFunction()
				{
					ID = 120,
					ExtName = Data.Strings.MakeString("GooglePlayServices_IsAvailable"),
					Kind = 120,
					Name = Data.Strings.MakeString("googlePlayServices_IsAvailable"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.Double
				},
                  new UndertaleExtensionFunction()
				{
					ID = 121,
					ExtName = Data.Strings.MakeString("GooglePlayServices_SignIn"),
					Kind = 121,
					Name = Data.Strings.MakeString("googlePlayServices_SignIn"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.Double
				},
                 new UndertaleExtensionFunction()
				{
					ID = 122,
					ExtName = Data.Strings.MakeString("GooglePlayServices_IsAuthenticated"),
					Kind = 122,
					Name = Data.Strings.MakeString("googlePlayServices_IsAuthenticated"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>(),
					RetType = UndertaleExtensionVarType.Double
				},
                 new UndertaleExtensionFunction()
				{
					ID = 123,
					ExtName = Data.Strings.MakeString("GooglePlayServices_RequestServerSideAccess"),
					Kind = 123,
					Name = Data.Strings.MakeString("googlePlayServices_RequestServerSideAccess"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },   
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                 new UndertaleExtensionFunction()
				{
					ID = 124,
					ExtName = Data.Strings.MakeString("GooglePlayServices_PlayerStats_LoadPlayerStats"),
					Kind = 124,
					Name = Data.Strings.MakeString("googleplayServices_playerStats_LoadPlayerStats"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },   
                    },
					RetType = UndertaleExtensionVarType.Double
				},
                 new UndertaleExtensionFunction()
				{
					ID = 125,
					ExtName = Data.Strings.MakeString("GooglePlayServices_Leaderboard_LoadTopScores"),
					Kind = 125,
					Name = Data.Strings.MakeString("googleplayservices_leaderboard_LoadTopScores"),
					Arguments = new UndertaleSimpleList<UndertaleExtensionFunctionArg>()
                    {
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.String },
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },   
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },   
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },   
                     new UndertaleExtensionFunctionArg() { Type = UndertaleExtensionVarType.Double },      
                    },
					RetType = UndertaleExtensionVarType.Double
				},
            }
		});		
		
	Data.Extensions.Add(extension);
	// generate "function" entries for every extension function EXCEPT THE HIDDEN ONES!
	foreach (var function in extension.Files[0].Functions)
	{
		if (function.Name.Content == "GooglePlayServices_Achievements_Show" || function.Name.Content == "GooglePlayServices_Achievements_Show") continue;
		Data.Functions.Add(new UndertaleFunction()
		{
			Name = function.Name
		});
	}
	// add productId
	if (Data.IsGameMaker2() || Data.GeneralInfo.Build == 9999)
	{
		byte[] throwawayData = System.Text.Encoding.ASCII.GetBytes("BOOKPRLIBSASDEFL");
		Data.FORM.EXTN.productIdData.Add(throwawayData);
	}
}
if (!ScriptQuestion("Google Play Juegos Android")) return;
Thecakeisalie();
ScriptMessage("Hecho");