using System;
using Mobile_Proiect.Data;
using System.IO;

namespace Mobile_Proiect;

public partial class App : Application
{
    static AppDatabase database;
    public static AppDatabase Database 
	{ 
		get 
		{ if (database == null) 
			{ database = new AppDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
				LocalApplicationData), "ShoppingList.db3")); 
			} 
			return database; 
		} 
	}
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
